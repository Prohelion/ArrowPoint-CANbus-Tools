using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Configuration;
using ArrowPointCANBusTool.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Services
{
    public sealed class ConfigService
    {

        private static readonly ConfigService instance = new ConfigService();

        public NetworkDefinition Configuration { get; private set; }
        public Dictionary<string, Form> forms = new Dictionary<string, Form>();

        static ConfigService()
        {            
        }

        private ConfigService()
        {         
        }

        public static ConfigService Instance
        {
            get
            {
                return instance;
            }
        }

        public Form FormForNode(Node node)
        {
            if (node == null) return (null);

            switch (node.name)
            {
                case "BMU": return new BatteryViewerForm();
                default: return null;
            }
        }

        public void LoadConfig(string filename)
        {
            Configuration = NetworkDefinition.LoadFromFile(filename);
        }

        public void SaveConfig(string filename)
        {
            Configuration.SaveToFile(filename);
        }


        public void LoadDBCFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            const int VERSION = 0;
            const int BS = 1;
            const int BU = 2;
            const int BO = 3;
            const int SG = 4;
            const int CM = 5;
            const int BA_DEF = 6;
            const int BA_DEF_DEF = 7;
            const int BA = 8;
            const int VAL = 9;
            const int VAL_TABLE = 10;

            int parseState = -1;

            Configuration = new NetworkDefinition();

            foreach (string line in lines)
            {

                int marker = line.IndexOf(' ');
                if (marker < 3) marker = 3;
                string checktag = line.Trim().Substring(0, marker);

                switch (checktag)
                {
                    case "VERSION": parseState = VERSION; break;
                    case "BS_": parseState = BS; break;
                    case "BU_": parseState = BU; break;
                    case "BO_": parseState = BO; break;
                    case "SG_": parseState = SG; break;
                    case "CM_": parseState = CM; break;
                    case "BA_DEF_": parseState = BA_DEF; break;
                    case "BA_DEF_DEF_": parseState = BA_DEF_DEF; break;
                    case "BA_": parseState = BA; break;
                    case "VAL_": parseState = VAL; break;
                    case "VAL_TABLE_": parseState = VAL_TABLE; break;
                }

                switch (parseState)
                {
                    case VERSION: Configuration.Document.version = line.Substring(9); break;
                    case BS: Configuration.Bus[0].baudrate = line.Substring(4); break;
                    case BU: break;
                    case BO: break;
                    case SG: break;
                    case CM: break;
                    case BA_DEF: break;
                    case BA_DEF_DEF: break;
                    case BA: break;
                    case VAL: break;
                    case VAL_TABLE: break;
                }
            }
        }



        public List<CanPacket> UnknownCanIds(Bus bus)
        {
            List<CanPacket> unknownPackets = null;

            Dictionary<String,Configuration.Message> messages = new Dictionary<String,Configuration.Message>();

            foreach (Configuration.Message message in bus.Message)            
                if (message.id != null) messages.Add(message.id, message);                            

            foreach (DictionaryEntry pair in CanService.Instance.LatestCanPacket)
            {
                CanPacket canPacket = (CanPacket)pair.Value;

                if (!messages.ContainsKey(canPacket.CanIdAsHex))
                {
                    if (unknownPackets == null) unknownPackets = new List<CanPacket>();
                    unknownPackets.Add(canPacket);
                } 
            }

            return unknownPackets;
        }

        public List<Configuration.Message> MessagesFromNodeOnBus(Node node, Bus bus)
        {

            List<Configuration.Message> messages = new List<Configuration.Message>();

            foreach (Configuration.Message message in bus.Message)
            {
                foreach (NodeRef nodeRefId in message.Producer)
                {
                    if (nodeRefId.id.Equals(node.id))
                       messages.Add(message);
                }
            }

            return (messages);
        }

        public int NextAvailableNodeId()
        {
            List<Configuration.Node> nodes = Configuration.Node;

            int nextIndex = 1;

            if (Configuration.Node != null)
                foreach (Node node in Configuration.Node)
                    if (Int32.TryParse(node.id, out int parsedId))
                        if (parsedId >= nextIndex) nextIndex = parsedId + 1;

            return nextIndex;
        }

        public Node AddNode(string nodeName)
        {
            Node node = new Node
            {
                name = nodeName,
                id = ConfigService.Instance.NextAvailableNodeId().ToString()
            };

            ConfigService.Instance.Configuration.Node.Add(node);

            return node;
        }

        public void DeleteNode(Node node)
        {
            List<Configuration.Message> messages = new List<Configuration.Message>();

            foreach (Bus bus in Configuration.Bus)
            {
                foreach (Configuration.Message message in bus.Message)
                {
                    foreach (NodeRef nodeRefId in message.Producer)
                    {
                        if (nodeRefId.id.Equals(node.id))
                            messages.Remove(message);
                    }
                }
            }
        }


        public Configuration.Message AddMessage(string messageName, string canId, Configuration.Node node, Configuration.Bus parentBus)
        {
            Configuration.Message message = new Configuration.Message
            {
                name = messageName,
                id = "0x" + CanUtilities.Trim0x(canId)
            };

            NodeRef nodeRef = new NodeRef
            {
                id = node.id
            };

            message.Producer.Add(nodeRef);
            parentBus.Message.Add(message);

            return message;
        }


        public void DeleteMessage(Configuration.Message messageToDelete)
        {
            List<Configuration.Message> messages = new List<Configuration.Message>();

            foreach (Bus bus in Configuration.Bus)
            {
                bus.Message.Remove(messageToDelete);
            }
        }

        public Signal AddSignal(Signal signal, Configuration.Message parentMessage)
        {
            parentMessage.Signal.Add(signal);        
            return signal;
        }

        public void DeleteSignal(Signal signal, Configuration.Message parentMessage)
        {
            parentMessage.Signal.Remove(signal);
        }

    }
}