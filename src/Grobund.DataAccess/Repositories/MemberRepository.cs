using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace Grobund.DataAccess.Repositories
{
    public class MemberRepository : IRepository<Member>
    {
        public int Create(Member member)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Name", member.Name);
                p.Add("@Email", member.Email);
                p.Add("@PhoneNumber", member.PhoneNumber);
                //p.Add("@MobileNumber", member.MobileNumber); TODO add to database
                //p.Add("@Registered", DateTime.Now); TODO add to database
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spMembers_Insert", p, commandType: CommandType.StoredProcedure);

                member.Id = p.Get<int>("@id");

                return member.Id;
            }
        }

        public Member ReadById(int id)
        {
            string query = "SELECT * FROM Members WHERE Id = @id";

            var p = new DynamicParameters();
            p.Add("@id", id);

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString()))
            {
                var member = connection.QueryFirstOrDefault<Member>(query, p, commandType: CommandType.Text);
                return member;
            }
        }
    }
}
