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
    class CanRecordReplayService : CanReceivingNode
    {

        private static readonly CanRecordReplayService instance = new CanRecordReplayService();

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

        public bool IsReplaying { get { return isReplaying; } }
        public bool IsRecording { get { return isRecording; } }
        public string ReplayStatus {  get { return replayStatus;  } }
        public string RecordStatus { get { return recordStatus; } }
        public int FilterFrom { get; set; }
        public int FilterTo { get; set; }
        public int FilterType { get; set; }
        public bool LoopReplay { get; set; }

        public override string ComponentID => RECORD_REPLAY_ID;

        public override uint State
        {
            get {
                if (!IsReplaying && !IsRecording)
                    return CanReceivingNode.STATE_IDLE;
                else
                    return CanReceivingNode.STATE_ON;
            }
        }

        static CanRecordReplayService()
        {
        }

        public static CanRecordReplayService Instance
        {
            get
            {
                return instance;
            }
        }        

        private CanRecordReplayService() : base(uint.MinValue, uint.MaxValue, VALID_MILLI, false)
        {
            FilterType = FILTER_NONE;
        }

        public async Task StartReplaying(string fileName)
        {
            Stream fileStream = File.OpenRead(fileName);
            if (fileStream != null)
                await StartReplaying(fileStream);
            else
                throw (new FileNotFoundException());
        }

        public async Task StartReplaying(Stream ioStream)
        {
            isReplaying = true;

            StreamReader ioStreamReader = new StreamReader(ioStream);

            do
            {                
                double startTime = 0;
                string line;
                double timeStamp;
                int timeDiff;

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

                                    timeDiff = (int)(timeStamp - startTime);
                                    if (timeDiff < 0) timeDiff = 0;
                                    // This is now the start time for the next gap
                                    startTime = timeStamp;

                                    await Task.Delay(timeDiff);

                                    string rawBytesStr = components[4].Trim().Substring(2);
                                    byte[] rawBytes = MyExtensions.StringToByteArray(rawBytesStr);
                                    Array.Reverse(rawBytes, 0, rawBytes.Length);

                                    for (int i = 0; i <= 7; i++) cp.SetByte(i, rawBytes[i]);
                                    CanService.Instance.SendMessage(cp);

                                    replayStatus = "Sending Can Packet No : " + packetCount;
                                    packetCount++;
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
                if (recordStream != null)
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

                    newLine = newLine + MyExtensions.AlignLeft(DateTime.Now.ToString("HH:mm:ss.fff"), 14, false);
                    newLine = newLine + MyExtensions.AlignLeft(packetNumber.ToString(), 12, true);
                    newLine = newLine + MyExtensions.AlignLeft(canPacket.CanIdAsHex, 12, true);
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
