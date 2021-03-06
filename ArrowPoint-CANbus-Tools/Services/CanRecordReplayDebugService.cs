﻿using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Transfer;
using ArrowPointCANBusTool.Utilities.Compression;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Services
{
    public class CanRecordReplayDebugService : CanReceivingNode, IDisposable
    {

        //private static readonly CanRecordReplayDebugService instance = new CanRecordReplayDebugService();

        public const int FILTER_NONE = 0;
        public const int FILTER_INCLUDE = 1;
        public const int FILTER_EXCLUDE = 2;

        private const uint VALID_MILLI = 1000;

        public const string RECORD_REPLAY_ID = "RECORD_REPLAY";

        private StreamWriter recordStream;
        private int packetNumber = 0;
        private bool isReplaying = false;
        private bool isRecording = false;        
        private string replayStatus = "Idle";
        private string recordStatus = "Idle";
        private string currentLogFile;        
        private DataLogger currentDataLoggerConfig;

        public bool IsReplaying { get { return isReplaying; } }
        public bool IsRecording { get { return isRecording; } }
        public string ReplayStatus {  get { return replayStatus;  } }
        public string RecordStatus { get { return recordStatus; } }
        public int FilterFrom { get; set; }
        public int FilterTo { get; set; }
        public int FilterType { get; set; }
        public bool LoopReplay { get; set; }

        public override string ComponentID => RECORD_REPLAY_ID;

        private Timer timer;

        public override uint State
        {
            get {
                if (!IsReplaying && !IsRecording)
                    return CanReceivingNode.STATE_IDLE;
                else
                    return CanReceivingNode.STATE_ON;
            }
        }

        static CanRecordReplayDebugService()
        {
        }

        /* Service is not thread safe as you can only log one thing at a time per service
         * Hence you can only create a new instance
         * public static CanRecordReplayDebugService Instance
        {
            get
            {
                return instance;
            }
        }*/

        public static CanRecordReplayDebugService NewInstance
        {
            get
            {
                return new CanRecordReplayDebugService();
            }
        }

        private CanRecordReplayDebugService() : base(uint.MinValue, uint.MaxValue, VALID_MILLI, false)
        {
            FilterType = FILTER_NONE;
        }

        public async Task StartReplaying(string fileName)
        {
            Stream fileStream = File.OpenRead(fileName);
            if (fileStream != null)
                await ReadCanLogFile(fileStream, true, false).ConfigureAwait(false);
            else
                throw (new FileNotFoundException());
        }

        public async Task StartReplaying(Stream ioStream)
        {
            if (ioStream == null) throw new ArgumentNullException(nameof(ioStream));

            await ReadCanLogFile(ioStream, true, false).ConfigureAwait(false);
        }

        public static DataLogger LoadConfig(Stream ioStream)
        {
            if (ioStream == null) throw new ArgumentNullException(nameof(ioStream));

            StreamReader file = new StreamReader(ioStream);
            JsonSerializer serializer = new JsonSerializer();
            DataLogger dataLoggerConfig = (DataLogger)serializer.Deserialize(file, typeof(DataLogger));
            file.Close();            
            return (dataLoggerConfig);
        }

        public static void SaveConfig(string fileName, DataLogger config)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(config));
            if (fileName == null) throw new ArgumentNullException(nameof(config));

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(fileName, JsonConvert.SerializeObject(config));
        }

        public async Task StartErrorTrace(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            Stream fileStream = File.OpenRead(fileName);
            if (fileStream != null)
                await ReadCanLogFile(fileStream, false, true).ConfigureAwait(false);
            else
                throw (new FileNotFoundException());
        }

        public async Task StartErrorTrace(Stream ioStream)
        {
            if (ioStream == null) throw new ArgumentNullException(nameof(ioStream));

            await ReadCanLogFile(ioStream, false, true).ConfigureAwait(false);
        }

        private async Task ReadCanLogFile(Stream ioStream, bool replayMode, bool logErrors)
        {
            if (ioStream == null) throw new ArgumentNullException(nameof(ioStream));

            isReplaying = true;

            StreamReader ioStreamReader = new StreamReader(ioStream);

            do
            {                
                double startTime = 0;
                string line;
                double timeStamp;
                int timeDiff;

                string lastErrorMsg = "";

                int packetCount = 0;

                // read from the start, if we are looping this may not be the start of the file
                // as we may have already run though before
                ioStream.Position = 0;
                ioStreamReader.DiscardBufferedData();

                while (isReplaying && (line = ioStreamReader.ReadLine()) != null)
                {
                    try
                    {
                        string[] components = line.Split(',');

                        if (!components[0].StartsWith("Recv time"))
                        {

                            if (DateTime.TryParseExact(components[0].Trim(), "HH:mm:ss.fff", new CultureInfo("en-US"), DateTimeStyles.None, out DateTime loggedTime))
                            {
                                CanPacket cp = new CanPacket
                                {
                                    CanId = Convert.ToUInt32(components[2].Trim(), 16)
                                };


                                if (replayMode)
                                {
                                    Boolean replayThis = false;

                                    if (FilterType == FILTER_NONE) replayThis = true;
                                    if (FilterType == FILTER_INCLUDE)
                                        if (cp.CanId >= FilterFrom && cp.CanId <= FilterTo) replayThis = true;
                                    if (FilterType == FILTER_EXCLUDE)
                                        if (cp.CanId < FilterFrom || cp.CanId > FilterTo) replayThis = true;

                                    if (replayThis)
                                    {
                                        timeStamp = (loggedTime - DateTime.MinValue).TotalMilliseconds;

                                        if (startTime == 0)
                                        {
                                            startTime = timeStamp;
                                        }

                                        timeDiff = (int)(timeStamp - startTime);
                                        if (timeDiff < 0) timeDiff = 0;
                                        // This is now the start time for the next gap
                                        startTime = timeStamp;

                                        await Task.Delay(timeDiff).ConfigureAwait(false);

                                        string rawBytesStr = components[4].Trim().Substring(2);
                                        byte[] rawBytes = CanUtilities.StringToByteArray(rawBytesStr);
                                        Array.Reverse(rawBytes, 0, rawBytes.Length);

                                        for (int i = 0; i <= 7; i++) cp.SetByte(i, rawBytes[i]);
                                        CanService.Instance.SendMessage(cp);

                                        replayStatus = "Sending Can Packet No : " + packetCount;
                                        packetCount++;
                                    }
                                }

                                if (logErrors)
                                {
                                    replayStatus = "Checking Can Packet No : " + packetCount;
                                    packetCount++;
                                    Application.DoEvents();

                                    string rawBytesStr = components[4].Trim().Substring(2);
                                    byte[] rawBytes = CanUtilities.StringToByteArray(rawBytesStr);
                                    Array.Reverse(rawBytes, 0, rawBytes.Length);

                                    for (int i = 0; i <= 7; i++) cp.SetByte(i, rawBytes[i]);
                                    CanService.Instance.SendMessage(cp);

                                    foreach (BMU bmu in BatteryService.Instance.BatteryData.GetBMUs())
                                    {
                                        if (!bmu.StateMessage.Equals(lastErrorMsg))
                                        {
                                            lastErrorMsg = bmu.StateMessage;
                                            Debug.WriteLine(components[0].Trim() + " : " + bmu.StateMessage);
                                        }
                                    }
                                }

                            } else
                            {
                                isReplaying = false;
                                replayStatus = "Error Reading File";
                            }
                        }
                    }
                    catch
                    {
                        isReplaying = false;
                    };
                   
                }

                // Sleep for 1/10th of a second, this also helps if we are trying to loop on a file
                // that doesn't contain any data or is filtered right out
                await Task.Delay(100).ConfigureAwait(false);

            } while (isReplaying && LoopReplay);

            if (ioStreamReader != null) ioStreamReader.Close();
            if (ioStream != null) ioStream.Close();
            isReplaying = false;
        }

        public void StopReplaying()
        {
           isReplaying = false;
           replayStatus = "IDLE";
        }



        private static string LogFileName()
        {
            string proposedName = "RawDataLog-" + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt";
            int index = 0;

            while (File.Exists(@proposedName))
            {
                proposedName = "RawDataLog-" + DateTime.Now.ToString("yyyyMMdd-HHmm") + "-" + index + ".txt";
                index++;
            }

            return proposedName;
        }


        private string CompressionManager(string logFile)
        {
            if (currentDataLoggerConfig.CompressLogs)
            {
                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(currentDataLoggerConfig.LocalDirectory, logFile);
                string rollLogFile = Path.GetFileNameWithoutExtension(logFile) + ".zip";
                string destFile = System.IO.Path.Combine(currentDataLoggerConfig.LocalDirectory, rollLogFile);

                // Send to zip file and 
                // overwrite the destination file if it already exists.
                Compress.FileToCompress(sourceFile, destFile);

                // Remove the old file
                if (File.Exists(@sourceFile))
                {
                    File.Delete(@sourceFile);
                }

                return rollLogFile;
            }

            return logFile;
        }

        private void TransferManager(string logFile)
        {
            if (currentDataLoggerConfig.IsLogRemote())
            {
                TransferBase transferUtil = new FTPTransfer();

                if (currentDataLoggerConfig.IsLogToFTP()) transferUtil = new FTPTransfer();
                if (currentDataLoggerConfig.IsLogToSFTP()) transferUtil = new SFTPTransfer();

                transferUtil.Host = currentDataLoggerConfig.RemoteHost;
                transferUtil.Port = currentDataLoggerConfig.RemotePort;
                transferUtil.Username = currentDataLoggerConfig.Username;
                transferUtil.Password = currentDataLoggerConfig.Password;
                transferUtil.SourceDirectory = currentDataLoggerConfig.LocalDirectory;
                transferUtil.DestinationDirectory = currentDataLoggerConfig.RemoteDirectory;

                transferUtil.UploadFile(logFile);
            }                
        }


        private void ArchiveManager(string logFile)
        {         
            if (currentDataLoggerConfig.ArchiveLogs)
            {
                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(currentDataLoggerConfig.LocalDirectory, logFile);
                string destFile = System.IO.Path.Combine(currentDataLoggerConfig.ArchiveDirectory, logFile);

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                System.IO.File.Move(sourceFile, destFile);
            }

            // If we are limiting the number of files then cull them as per the limit.
            if (currentDataLoggerConfig.LimitArchive)
            {
                foreach (FileInfo fileInfo in new DirectoryInfo(@currentDataLoggerConfig.ArchiveDirectory).
                    GetFiles().OrderByDescending(x => x.LastWriteTime).Skip(currentDataLoggerConfig.LimitArchiveFileNum))
                    fileInfo.Delete();
            }
        }


        private void RollLogAndManage()
        {
            StopRecording();

            // Compress the data if necessary
            // The file name may change during this process so we use rollLogFile
            string rollLogFile = CompressionManager(currentLogFile);

            // Transfer the data if necessary
            TransferManager(rollLogFile);

            // Archive the data if necessary
            ArchiveManager(rollLogFile);

            // Roll log file is only used during the rolling process            
            currentLogFile = LogFileName();
            StartRecording(currentDataLoggerConfig);
        }

        private void RollLogTimerTick(object sender, EventArgs e)
        {
            RollLogAndManage();
        }

        private void StartFileRollTimer(int minuteInterval)
        {
            timer = new Timer
            {
                Interval = (minuteInterval * 60 * 1000)
            };
            timer.Tick += new EventHandler(RollLogTimerTick);
            timer.Start();
        }

        public void StartRecording(DataLogger dataLoggerConfig)
        {
            if (dataLoggerConfig != null)
            {
                currentDataLoggerConfig = dataLoggerConfig;
                currentLogFile = LogFileName();

                StreamWriter fileStream = new System.IO.StreamWriter(System.IO.Path.Combine(dataLoggerConfig.LocalDirectory, currentLogFile));
                recordStream = fileStream ?? throw new FileNotFoundException();

                recordStream.WriteLine("Recv time     , Packet num, ID        , flags, data              , float[1]     , float[0]     , sender addr");

                isRecording = true;
                packetNumber = 0;
                recordStatus = "Waiting for Message";
                StartReceivingCan();

                if (dataLoggerConfig.IsRotateByMin())
                {
                    StartFileRollTimer(dataLoggerConfig.RotateMinutes);
                }
            } else
                throw (new FileNotFoundException());
        }

        public void StopRecording()
        {
            try
            {
               recordStream?.Close();
            }
            catch { }

            isRecording = false;
            recordStatus = "Idle";
            StopReceivingCan();

            timer?.Stop();
        }

        public override void CanPacketReceived(CanPacket canPacket)
        {

            if (canPacket == null) throw new ArgumentNullException(nameof(canPacket));

            try
            {
                if (isRecording)
                {
                    string newLine = "";
                    packetNumber++;

                    newLine += CanUtilities.AlignLeft(DateTime.Now.ToString("HH:mm:ss.fff"), 14, false);
                    newLine += CanUtilities.AlignLeft(packetNumber.ToString(), 12, true);
                    newLine += CanUtilities.AlignLeft(canPacket.CanIdAsHex, 12, true);
                    newLine += CanUtilities.AlignLeft(canPacket.Flags, 7, true);

                    byte[] dataBytes = canPacket.DataBytes;
                    Array.Reverse(dataBytes, 0, dataBytes.Length);

                    newLine += CanUtilities.AlignLeft("0x" + CanUtilities.ByteArrayToString(dataBytes), 20, true);
                    newLine += CanUtilities.AlignLeft(canPacket.Float1.ToString(), 15, true);
                    newLine += CanUtilities.AlignLeft(canPacket.Float0.ToString(), 15, true);
                    newLine += CanUtilities.AlignLeft(canPacket.SourceIPAddress.ToString(), 7, true);

                    recordStatus = "Recording Can Packet No : " + packetNumber;

                    recordStream.WriteLine(newLine);
                    recordStream.Flush();

                    if (currentDataLoggerConfig.IsRotateByMB())
                    {                        
                        if (recordStream.BaseStream.Length > currentDataLoggerConfig.RotateBytes()) RollLogAndManage();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    recordStream?.Close();
                    recordStream?.Dispose();

                    timer?.Stop();
                    timer?.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
