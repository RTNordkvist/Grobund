using Grobund.Data.Models;
using Grobund.DataAccess.Repositories;
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
        public static List<IRepository<Member, int>> MemberRepositories { get; private set; } = new List<IRepository<Member, int>>();

        public static void InitializeConnection(IRepository<Member, int> repository)
        {
            MemberRepositories.Add(repository);
        }
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}