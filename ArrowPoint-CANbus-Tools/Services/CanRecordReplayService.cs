using ArrowPointCANBusTool.Canbus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
{
    class CanRecordReplayService : CanReceivingComponent
    {
        public const int FILTER_NONE = 0;
        public const int FILTER_INCLUDE = 1;
        public const int FILTER_EXCLUDE = 2;

        private CanService canService;
        private StreamWriter recordStream;
        private int packetNumber = 0;
        private bool isReplaying = false;
        private bool isRecording = false;
        private string replayStatus = "Idle";
        private string recordStatus = "Idle";

        public bool IsReplaying { get { return isReplaying; } }
        public bool IsRecording { get { return isRecording; } }
        public string ReplayStatus {  get { return replayStatus;  } }
        public string RecordStatus { get { return recordStatus; } }
        public int FilterFrom { get; set; }
        public int FilterTo { get; set; }
        public int FilterType { get; set; }
        public bool LoopReplay { get; set; }

        public override string StateMessage => throw new NotImplementedException();

        public CanRecordReplayService(CanService canService) : base(canService, uint.MinValue, uint.MaxValue, false)
        {
            this.canService = canService;
            FilterType = FILTER_NONE;
        }

        public void StartReplaying(string fileName)
        {
            Stream fileStream = File.OpenRead(fileName);
            if (fileStream != null)
                StartReplaying(fileStream);
            else
                throw (new FileNotFoundException());
        }

        public async void StartReplaying(Stream ioStream)
        {
            isReplaying = true;

            StreamReader ioStreamReader = new StreamReader(ioStream);

            do
            {                
                Stopwatch stopwatch = new Stopwatch();
                double startTime = 0;
                string line;
                double timeStamp;
                int timeDiff;

                stopwatch.Start();

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

                                Boolean replayThis = false;

                                if (FilterType == FILTER_NONE)  replayThis = true;
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

                                    timeDiff = (int)(timeStamp - startTime - stopwatch.ElapsedMilliseconds);
                                    if (timeDiff < 0) timeDiff = 0;
                                    await Task.Delay(timeDiff);

                                    string rawBytesStr = components[4].Trim().Substring(2);
                                    byte[] rawBytes = MyExtensions.StringToByteArray(rawBytesStr);
                                    Array.Reverse(rawBytes, 0, rawBytes.Length);

                                    for (int i = 0; i <= 7; i++) cp.SetByte(i, rawBytes[i]);
                                    canService.SendMessage(cp);

                                    replayStatus = "Sending Can Packet No : " + components[1].Trim();
                                }
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

            ioStreamReader.Close();
            ioStream.Close();
            isReplaying = false;
        }

        public void StopReplaying()
        {
           isReplaying = false;
           replayStatus = "IDLE";
    }

        public void StartRecording(string fileName)
        {
            StreamWriter fileStream = new System.IO.StreamWriter(fileName);
            if (fileStream != null)
                StartRecording(fileStream);
            else
                throw (new FileNotFoundException());
        }

        public void StartRecording(StreamWriter ioStream)
        {
            recordStream = ioStream;
            recordStream.WriteLine("Recv time     , Packet num, ID        , flags, data              , float[1]     , float[0]     , sender addr");

            isRecording = true;
            packetNumber = 0;
            recordStatus = "Waiting for Message";
            StartReceivingCan();
        }

        public void StopRecording()
        {
            try
            {
                recordStream.Close();
            }
            catch { }

            isRecording = false;
            recordStatus = "Idle";
            StopReceivingCan();
        }

        public override void CanPacketReceived(CanPacket canPacket)
        {            
            try
            {
                if (isRecording)
                {
                    string newLine = "";
                    packetNumber++;

                    newLine = newLine + MyExtensions.AlignLeft(DateTime.Now.ToString("HH:mm:ss:fff"), 14, false);
                    newLine = newLine + MyExtensions.AlignLeft(packetNumber.ToString(), 12, true);
                    newLine = newLine + MyExtensions.AlignLeft("0x" + canPacket.CanIdAsHex, 12, true);
                    newLine = newLine + MyExtensions.AlignLeft(canPacket.Flags, 7, true);

                    byte[] dataBytes = canPacket.DataBytes;
                    Array.Reverse(dataBytes, 0, dataBytes.Length);

                    newLine = newLine + MyExtensions.AlignLeft("0x" + MyExtensions.ByteArrayToString(dataBytes), 20, true);
                    newLine = newLine + MyExtensions.AlignLeft(canPacket.Float1.ToString(), 15, true);
                    newLine = newLine + MyExtensions.AlignLeft(canPacket.Float0.ToString(), 15, true);
                    newLine = newLine + MyExtensions.AlignLeft(canPacket.SourceIPAddress.ToString(), 7, true);

                    recordStream.WriteLine(newLine);

                    recordStatus = "Recording Can Packet No : " + packetNumber;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

    }
}
