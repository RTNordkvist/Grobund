using Dapper;
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
        /// <summary>
        /// Saves a Member to the database
        /// </summary>
        /// <param name="memberModel">Member information</param>
        /// <returns>The member information including the member ID</returns>
        /// 

        public MemberModel CreateMember(MemberModel memberModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("GrobundDB")))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", memberModel.FirstName);
                p.Add("@LastName", memberModel.LastName);
                p.Add("@Email", memberModel.Email);
                p.Add("@PhoneNumber", memberModel.PhoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                connection.Execute("dbo.spMembers_Insert",p, commandType: CommandType.StoredProcedure);

                memberModel.Id = p.Get<int>("@id");

                return memberModel;

            }
        }

    }
}
