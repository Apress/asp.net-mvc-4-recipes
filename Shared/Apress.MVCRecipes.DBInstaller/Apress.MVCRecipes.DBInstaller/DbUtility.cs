using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Smo;
using System.Data;
using Microsoft.SqlServer.Management.Common;
using System.Data.Sql;


namespace Apress.MVCRecipes.DBInstaller
{
    public class DbUtility
    {
        public static List<string> GetListOfAvailibleDatabaseServers()
        {
            var servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            //var servers = SmoApplication.EnumAvailableSqlServers(false);
            if (servers == null || servers.Rows==null || servers.Rows.Count==0)
            {
                return null;
            }
            List<string> ServerNames = new List<string>();
            foreach (DataRow row in servers.Rows)
            {
                // Instance information is only availible if SQL Browser is running
                if (!string.IsNullOrEmpty(row["InstanceName"].ToString()))
                {
                    ServerNames.Add(string.Concat(row["ServerName"].ToString(), @"\", row["InstanceName"].ToString()));
                }
                else
                {
                    ServerNames.Add(row["ServerName"].ToString());
                }
                
            }

            return ServerNames;

        }

        
    }
}
