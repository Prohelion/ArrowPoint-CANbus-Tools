using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Transfer;
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
    public class CanRecordReplayDebugService : CanReceivingNode
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
                await ReadCanLogFile(fileStream, true, false);
            else
                throw (new FileNotFoundException());
        }

        public async Task StartReplaying(Stream ioStream)
        {
            await ReadCanLogFile(ioStream, true, false);
        }

        public DataLogger LoadConfig(Stream ioStream)
        {
            StreamReader file = new StreamReader(ioStream);
            JsonSerializer serializer = new JsonSerializer();
            DataLogger dataLoggerConfig = (DataLogger)serializer.Deserialize(file, typeof(DataLogger));
            file.Close();            
            return (dataLoggerConfig);
        }

        public void SaveConfig(string fileName, DataLogger config)
        {
            // serialize JSON to a string and then write string to a file
            File.WriteAllText(fileName, JsonConvert.SerializeObject(config));
        }

        public async Task StartErrorTrace(string fileName)
        {
            Stream fileStream = File.OpenRead(fileName);
            if (fileStream != null)
                await ReadCanLogFile(fileStream, false, true);
            else
                throw (new FileNotFoundException());
        }

        public async Task StartErrorTrace(Stream ioStream)
        {
            await ReadCanLogFile(ioStream, false, true);
        }

        private async Task ReadCanLogFile(Stream ioStream, bool replayMode, bool logErrors)
        {
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

                                        await Task.Delay(timeDiff);

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
                await Task.Delay(100);

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



        private string LogFileName(DataLogger dataLoggerConfig)
        {
            string proposedName = dataLoggerConfig.LocalDirectory + @"\" + "RawDataLog-" + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt";
            int index = 0;

            while (File.Exists(@proposedName))
            {
                proposedName = dataLoggerConfig.LocalDirectory + @"\" + "RawDataLog-" + DateTime.Now.ToString("yyyyMMdd-HHmm") + "-" + index + ".txt";
                index++;
            }

            return proposedName;
        }


        private void CompressionManager()
        {

        }


        private void TransferManager(DataLogger dataLoggerConfig)
        {
            TransferBase transferUtil = new FTPTransfer();

            if (dataLoggerConfig.IsLogToFTP()) transferUtil = new FTPTransfer();
            if (dataLoggerConfig.IsLogToSFTP()) transferUtil = new SFTPTransfer();

            transferUtil.Host = dataLoggerConfig.RemoteHost;
            transferUtil.Port = dataLoggerConfig.RemotePort;
            transferUtil.Username = dataLoggerConfig.Username;
            transferUtil.Password = dataLoggerConfig.Password;
            transferUtil.SourceDirectory = dataLoggerConfig.LocalDirectory;
            transferUtil.DestinationDirectory = dataLoggerConfig.RemoteDirectory;

            transferUtil.UploadFileCompressed(currentLogFile);

        }


        private void ArchiveManager()
        {

        }



        private void RollLogAndManage()
        {
            StopRecording();

            // Compress the data if necessary

            // Transfer the data if necessary
            if (currentDataLoggerConfig.IsLogRemote())
                TransferManager(currentDataLoggerConfig);

            // Archive the data if necessary

            currentLogFile = LogFileName(currentDataLoggerConfig);
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

            currentDataLoggerConfig = dataLoggerConfig;
            currentLogFile = LogFileName(dataLoggerConfig);

            StreamWriter fileStream = new System.IO.StreamWriter(currentLogFile);
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

    }
}
