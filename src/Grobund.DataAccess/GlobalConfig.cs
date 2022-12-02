using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.DataAccess
{
    public static class GlobalConfig
    {
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string GetConnectionString()
        {
            return GetConnectionString("GrobundDB");
        }
    }
}
