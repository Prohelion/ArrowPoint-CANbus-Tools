﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArrowPointCANBusTool.Configuration;
using NUnit.Framework;
using ArrowPointCANBusTool.Services;
using System.Globalization;

namespace ArrowPointCANBusTest.Configuration
{
    [TestFixture]
    public class ConfigurationTest
    {

        private static string GetTestDataFolder(string testDataFolder)
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
            var pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
            string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(CultureInfo.CurrentCulture), pathItems.Take(pathItems.Length - pos - 1));
            return Path.Combine(projectPath, "Test-Data", testDataFolder);
        }

        [Test]
        public void TestLoad()
        {
            string path = GetTestDataFolder("Configuration");

            ConfigService configManager = ConfigService.Instance;
            configManager.LoadConfig(path + "\\CanConfig.xml");

            Assert.IsNotNull(configManager.Configuration);
        }

        [Test]
        public void TestMessagesFromNode()
        {
            string path = GetTestDataFolder("Configuration");

            ConfigService configManager = ConfigService.Instance;
            configManager.LoadConfig(path + "\\CanConfig.xml");

            Assert.IsNotNull(configManager.Configuration);

            Bus bus = configManager.Configuration.Bus[0];
            Node node = configManager.Configuration.Node[0];
            List<Message> messages = configManager.MessagesFromNodeOnBus(node, bus);

            Assert.IsNotNull(messages);
            Assert.AreEqual(messages.Count,1);
        }
    }
}
