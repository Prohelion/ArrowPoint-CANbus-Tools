using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArrowPointCANBusTool.Configuration;
using ArrowPointCANBusTool.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrowPointCANBusTest.Configuration
{
    [TestClass]
    public class ConfigurationTest
    {

        private static string GetTestDataFolder(string testDataFolder)
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
            var pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
            string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - pos - 1));
            return Path.Combine(projectPath, "Test-Data", testDataFolder);
        }

        [TestMethod]
        public void TestLoad()
        {
            string path = GetTestDataFolder("Configuration");

            ConfigManager configManager = ConfigManager.Instance;
            configManager.LoadConfig(path + "\\CanConfig.xml");

            Assert.IsNotNull(configManager.Configuration);
        }

        [TestMethod]
        public void TestMessagesFromNode()
        {
            string path = GetTestDataFolder("Configuration");

            ConfigManager configManager = ConfigManager.Instance;
            configManager.LoadConfig(path + "\\CanConfig.xml");

            Assert.IsNotNull(configManager.Configuration);

            Node node = configManager.Configuration.Node[0];
            List<Message> messages = configManager.MessagesFromNode(node);

            Assert.IsNotNull(messages);
            Assert.AreEqual(messages.Count,1);
        }
    }
}
