﻿using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Google.Protobuf.WellKnownTypes;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Grobund.DataAccess.Repositories
{
    public class MemberRepository : IRepository<Member>
    {
        public int Create(Member member)
        {
            //string query = "INSERT INTO Members (Name, Email, PhoneNumber, MobileNumber, Address1, Address2, PostalCode, City, Country, Registered) " +
            //    "VALUES (@Name, @Email, @PhoneNumber, @MobileNumber, @Address1, @Address2, @PostalCode, @City, @Country, @Registered);";

            //string idQuery = "SELECT LAST_INSERT_ID();";

            string query = "INSERT INTO Members (Name, Email, PhoneNumber, MobileNumber, Address1, Address2, PostalCode, City, Country) " +
                "OUTPUT INSERTED.id " +
                "VALUES (@Name, @Email, @PhoneNumber, @MobileNumber, @Address1, @Address2, @PostalCode, @City, @Country);";

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
                p.Add("@Registered", DateTime.Now);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                //connection.Execute(query, p, commandType: CommandType.Text);
                var id = connection.Query<int>(query, new { member.Name, member.Email, member.PhoneNumber, member.MobileNumber, member.Address1, member.Address2, member.PostalCode, member.City, member.Country});



                // member.Id = p.Get<int>("@id");
                member.Id = Convert.ToInt32(id);

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
