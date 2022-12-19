﻿using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Collections;

namespace Grobund.DataAccess.Repositories
{
    public class MemberRepository
    {
        public int Create(Member member)
        {
            string query = "INSERT INTO dbo.members " +
                "(Name, Email, PhoneNumber, MobileNumber, Address1, Address2, PostalCode, City, Country, Registered) " +
                "VALUES (@Name, @Email, @PhoneNumber, @MobileNumber, @Address1, @Address2, @PostalCode, @City, @Country, @Registered)" +
                " SELECT @id = SCOPE_IDENTITY();";

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString()))
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

                connection.Execute(query, p, commandType: CommandType.Text);

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

        public bool Delete(int id)
        {
            string query = "DELETE FROM Members WHERE id = @id;";
            int rowsAffected;

            var p = new DynamicParameters();
            p.Add("@id", id);

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString()))
            {
                rowsAffected = connection.Execute(query, p, commandType: CommandType.Text);
            }

            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Member Update(Member member)
        {
            Member updatedMember = new Member();
            // update query
            string query = "UPDATE Members " +
                "SET Name = @Name, Email = @Email, PhoneNumber = @PhoneNumber, MobileNumber = @MobileNumber, " +
                "Address1 = @Address1, Address2 = @Address2, PostalCode = @PostalCode, City = @City, Country = @Country " +
                "WHERE Id = @Id";
            
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString()))
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
                p.Add("@Id", member.Id);

                connection.Execute(query, p, commandType: CommandType.Text);

                updatedMember = ReadById(member.Id);

                return updatedMember;
            }
        }
    }
}
