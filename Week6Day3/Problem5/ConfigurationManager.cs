using System;

namespace Problem5
{
    public sealed class ConfigurationManager
    {
        private static ConfigurationManager _instance;

        private static readonly object _lock = new object();

        public string ApplicationName
        {
            get;
            private set;
        }

        public string Version
        {
            get;
            private set;
        }

        public string DatabaseConnectionString
        {
            get;
            private set;
        }

        private ConfigurationManager()
        {
            ApplicationName = "Inventory Management System";
            Version = "1.0.0";
            DatabaseConnectionString = "Server=localhost;Database=InventoryDB;";
        }

        public static ConfigurationManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }
    }
}