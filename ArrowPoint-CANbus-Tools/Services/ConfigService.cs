using ArrowPointCANBusTool.Configuration;
using ArrowPointCANBusTool.Forms;
using System;
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
                case "BMU": return new BatteryViewerForm(new Services.CanService());
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
                id = "0x" + canId
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