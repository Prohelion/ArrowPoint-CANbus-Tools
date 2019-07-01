using ArrowPointCANBusTool.Configuration;
using ArrowPointCANBusTool.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Configuration
{
    public sealed class ConfigManager
    {

        private static readonly ConfigManager instance = new ConfigManager();

        public NetworkDefinition Configuration { get; private set; }
        public Dictionary<string, Form> forms = new Dictionary<string, Form>();

        static ConfigManager()
        {
        }

        private ConfigManager()
        {
        }

        public static ConfigManager Instance
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

        public List<Configuration.Message> MessagesFromNode(Node node)
        {

            List<Configuration.Message> messages = new List<Configuration.Message>();

            foreach (Bus bus in Configuration.Bus)
            {
                foreach (Configuration.Message message in bus.Message)
                {
                    foreach (NodeRef nodeRefId in message.Producer)
                    {
                        if (nodeRefId.id.Equals(node.id))
                            messages.Add(message);
                    }
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

    }
}