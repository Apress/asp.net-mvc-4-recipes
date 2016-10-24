using System;
using System.Collections.Generic;
using System.Text;

namespace JCBF.Util {
    /// <summary>
    /// helper class that simplifies reading of configuration data and supplies defualt values in the case that a
    /// configuration value is missing
    /// </summary>
    public class Config {
        /// <summary>
        /// Gets a value from the Application Settings file. If the value does not exist an empty string will be returned
        /// </summary>
        /// <param name="configName">The name of the item in the appsettings</param>
        /// <returns>The value from the configuration file</returns>
        public static String getStringValueFromAppSettings(String configName) {
            string val = string.Empty;
            try {
                val = new System.Configuration.AppSettingsReader().GetValue(configName, typeof(string)).ToString();
            }
            catch {
            }
            return val;
        }

        /// <summary>
        /// Gets a comma delimited string from the application settings file and returns it as an array
        /// </summary>
        /// <param name="configName">The name of the item in the appsettings</param>
        /// <returns>An array of values or null is the config item does not exist</returns>
        public static String[] getArrayFromAppSettings(string configName)
        {
            string delimitedString = getStringValueFromAppSettings(configName);
            if (string.IsNullOrEmpty(delimitedString))
            {
                return null;
            }
            else
            {
                char[] delims = {','};
                string[] retval = delimitedString.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                return retval;
            }
        }

        /// <summary>
        /// Gets a value from the Application Settings file. If the value does not exist then the defualt value will be returned
        /// </summary>
        /// <param name="configName">The name of the item in the appsettings</param>
        /// <param name="defaultValue">Value returned is config value does not exist</param>
        /// <returns>The value from the configuration file</returns>
        public static String getStringValueFromAppSettings(String configName, String defaultValue) {
            string val = defaultValue;
            try {
                val = new System.Configuration.AppSettingsReader().GetValue(configName, typeof(string)).ToString();
            }
            catch {
            }
            return val;
        }
        /// <summary>
        /// Gets a value from the Application Settings file. If the value does not exist false will be returned
        /// </summary>
        /// <param name="configName">The name of the item in the appsettings</param>
        /// <returns>The value from the configuration file</returns>
        public static bool getBoolValueFromAppSettings(String configName) {
            bool val = false;
            try {
                val =ToolChest.convertToBoolean(new System.Configuration.AppSettingsReader().GetValue(configName, typeof(string)).ToString());
            }
            catch {
            }
            return val;
        }
        /// <summary>
        /// Gets a connection string from the application settings file
        /// </summary>
        /// <param name="configName">The name of the item in the appsettings</param>
        /// <returns>The value from the configuration file</returns>
        public static string getConnStrFromAppSettings(String configName) {
            string val = string.Empty;
            if (Config.ApplicationType.Equals("WEB")) {
                try {
                    val = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[configName].ConnectionString;
                }
                catch {
                }
            }
            else {
                try {
                    val = System.Configuration.ConfigurationManager.ConnectionStrings[configName].ConnectionString;
                }
                catch {
                }
            }
            
            return val;
        }

        /// <summary>
        /// is useful for letting app know if it is a web application "WEB" or a service application
        /// </summary>
        public static String ApplicationType {
            get {
                string appType = Config.getStringValueFromAppSettings("ApplicationType");
                if (string.IsNullOrEmpty(appType)) {
                    appType = "WEB";
                }
                return appType;
            }
        }
    }
}
