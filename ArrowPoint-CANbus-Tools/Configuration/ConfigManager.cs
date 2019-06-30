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
        public Dictionary<string,Form> forms = new Dictionary<string,Form>();

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
            
            return (null);
        }
        
        public void LoadConfig(string filename)
        {        
            Configuration = NetworkDefinition.LoadFromFile(filename);            
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

    }
}
