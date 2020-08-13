using System;
using System.Collections.Generic;
using System.Configuration;

namespace RLJones.FraudInspectionDriver.Classes
{
    public class ConnectionStringManager
    {
        private readonly string ConnectionName;
        private readonly Configuration AppConfig;
        private Dictionary<string, string> Parameters;

        public ConnectionStringManager(string connectionName)
        {
            ConnectionName = connectionName;

            AppConfig = ConfigurationManager
                            .OpenExeConfiguration(ConfigurationUserLevel.None);

            string connStr = AppConfig.ConnectionStrings
                                      .ConnectionStrings[connectionName]
                                      .ConnectionString;

            Parse(connStr);
        }

        private Dictionary<string, string> Parse(string connStr)
        {
            Parameters = new Dictionary<string, string>();

            string[] splittedConnStr = connStr.Split(';');

            foreach (string param in splittedConnStr)
            {
                string[] paramSplit = param.Split('=');

                if (paramSplit.Length == 2)
                    Parameters.Add(paramSplit[0].ToUpper(), paramSplit[1]);
            }
            return Parameters;
        }

        public string GetParameter(string parameterName) 
        {
            parameterName = parameterName.ToUpper();

            if (Parameters.ContainsKey(parameterName))
                return Parameters[parameterName];

            return string.Empty;
        }

        public void SetParameter(string parameterName, string value)
        {
            parameterName = parameterName.ToUpper();

            if (!Parameters.ContainsKey(parameterName))
                Parameters.Add(parameterName, value);
            else
                Parameters[parameterName] = value;
        }

        public void RemoveParameter(string parameterName)
        {
            parameterName = parameterName.ToUpper();

            if (Parameters.ContainsKey(parameterName))
                Parameters.Remove(parameterName);
        }

        public string GetErrorMessages()
        {
            string errorsFound = string.Empty;

            foreach(KeyValuePair<string, string> kvp in Parameters)
            {
                if (kvp.Value == string.Empty)
                    errorsFound += string.Format("'{0}' cannot be empty.\n", kvp.Key);
            }

            return errorsFound;
        }

        public void Save()
        {
            AppConfig.ConnectionStrings
                     .ConnectionStrings[ConnectionName]
                     .ConnectionString = ToString();

            AppConfig.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public override string ToString()
        {
            string connectionString = string.Empty;

            foreach(KeyValuePair<string, string> kvp in Parameters)
            {
                connectionString += string.Format("{0}={1};", kvp.Key, kvp.Value);
            }
            return connectionString;
        }

    }
}
