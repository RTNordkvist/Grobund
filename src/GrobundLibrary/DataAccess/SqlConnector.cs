using Dapper;
using Grobund.Data.Models;
using GrobundLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrobundLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
 

        public Member CreateMember(Member member)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("GrobundDB")))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", member.Name);
                p.Add("@Email", member.Email);
                p.Add("@PhoneNumber", member.PhoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                connection.Execute("dbo.spMembers_Insert",p, commandType: CommandType.StoredProcedure);

                member.Id = p.Get<int>("@id");

                return member;

            }
        }

    }
}
