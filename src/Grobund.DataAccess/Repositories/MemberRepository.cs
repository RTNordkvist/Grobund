using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Grobund.DataAccess.Repositories
{
    public class MemberRepository : IRepository<Member>
    {
        public int Create(Member member)
        {
            string query = "INSERT INTO Members (Name, Email, PhoneNumber, MobileNumber, Address1, Address2, PostalCode, City, Country) " +
                "VALUES (@Name, @Email, @PhoneNumber, @MobileNumber, @Address1, @Address2, @PostalCode, @City, @Country);";

            string idQuery = "SELECT LAST_INSERT_ID();";

            using (IDbConnection connection = new MySqlConnection(GlobalConfig.GetConnectionString("matrikel")))
            {
                var p = new DynamicParameters();
                p.Add("@Name", member.Name);
                p.Add("@Email", member.Email);
                p.Add("@PhoneNumber", member.PhoneNumber);
                p.Add("@MobileNumber", member.MobileNumber);
                p.Add("@Address1", member.Address1);
                p.Add("@Address2", member.Address2);
                p.Add("@PostalCode", member.PostalCode);
                p.Add("@City", member.City);
                p.Add("@Country", member.Country);
                //p.Add("@Registered", DateTime.Now);
                
                connection.Execute(query, p, commandType: CommandType.Text);
                var id = connection.ExecuteScalar(idQuery);
                int intId = Convert.ToInt32(id);
                member.Id = intId;



                // member.Id = p.Get<int>("@id");
                //member.Id = id.

                return member.Id;
            }
        }

        public Member ReadById(int id)
        {
            string query = "SELECT * FROM Members WHERE id = @id";

            var p = new DynamicParameters();
            p.Add("@id", id);

            using (IDbConnection connection = new MySqlConnection(GlobalConfig.GetConnectionString("matrikel")))
            {
                var member = connection.QueryFirstOrDefault<Member>(query, p, commandType: CommandType.Text);
                return member;
            }
        }
    }
}
