using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection.Metadata;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Collections;

namespace Grobund.DataAccess.Repositories
{
    public class MemberRepository
    {
        public int Create(Member member)
        {
            string query = "INSERT INTO dbo.members " +
                "(Name, MemberNo, Email, PhoneNumber, MobileNumber, Address1, Address2, PostalCode, City, " +
                "Country, Registered) " +
                "VALUES (@Name, @MemberNo, @Email, @PhoneNumber, @MobileNumber, @Address1, @Address2, " +
                "@PostalCode, @City, @Country, @Registered)" +
                " SELECT @id = SCOPE_IDENTITY();";

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@MemberNo", member.MemberNo);
                p.Add("@Name", member.Name);
                p.Add("@Email", member.Email);
                p.Add("@PhoneNumber", member.PhoneNumber);
                p.Add("@MobileNumber", member.MobileNumber);
                p.Add("@Address1", member.Address1);
                p.Add("@Address2", member.Address2);
                p.Add("@PostalCode", member.PostalCode);
                p.Add("@City", member.City);
                p.Add("@Country", member.Country);
                p.Add("@Registered", member.Registered != DateTime.MinValue ? member.Registered : DateTime.Now);
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

        public int GetIdByMemberNo(int memberNo)
        {
            string query = "SELECT Id FROM Members WHERE MemberNo = @memberNo";

            var p = new DynamicParameters();
            p.Add("@memberNo", memberNo);

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString()))
            {
                var id = connection.QueryFirstOrDefault<int>(query, p, commandType: CommandType.Text);
                return id;
            }
        }

        public IEnumerable<Member> Search(string searchText)
        {
            string query = "SELECT * FROM Members WHERE Id = @id OR Name LIKE @name OR Email LIKE @email OR PhoneNumber LIKE @phoneNumber";

            DataTable dataTable = new DataTable();

            string connStr = GlobalConfig.GetConnectionString();

            /*using (SqlConnection cn = new SqlConnection(connStr))
            {
                int.TryParse(searchText, out int SearchID);

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", SearchID);
                cmd.Parameters.AddWithValue("@name", searchText);
                cmd.Parameters.AddWithValue("@email", searchText);
                cmd.Parameters.AddWithValue("@phoneNumber", searchText);

                cn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query the database and return the result to the datatable
                da.Fill(dataTable);
                cn.Close();
                da.Dispose();
            }

            var result = new List<Member>();
            foreach (var rw in dataTable.AsEnumerable())
            {
                result.Add(ConvertToMember(rw));
            }
            return result;*/


            int.TryParse(searchText, out int IdSearch);

            //string connStr = GlobalConfig.GetConnectionString();
            List<Member> members = null;
            
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", IdSearch);
                cmd.Parameters.AddWithValue("@name", "%" + searchText + "%");
                cmd.Parameters.AddWithValue("@email", "%" + searchText + "%");
                cmd.Parameters.AddWithValue("@phoneNumber", "%" + searchText + "%");
                var dataReader=cmd.ExecuteReader();
                members=GetList<Member>(dataReader);
            }

            return members; 
        }

        private Member ConvertToMember(DataRow rw)
        {
            Member member = new();
            member.Id = Convert.ToInt32(rw["Id"]);
            member.Name = Convert.ToString(rw["Name"]);
            member.Email = Convert.ToString(rw["Email"]);
            member.PhoneNumber = Convert.ToString(rw["Phonenumber"]);
            member.MobileNumber = Convert.ToString(rw["MobileNumber"]);
            member.Address1 = Convert.ToString(rw["Address1"]);
            member.Address2 = Convert.ToString(rw["Address2"]);
            member.PostalCode = Convert.ToString(rw["PostalCode"]);
            member.City = Convert.ToString(rw["City"]);
            member.Country = Convert.ToString(rw["Country"]);
            member.Registered = Convert.ToDateTime(rw["Registered"]);

            return member;
        }



        private List<T> GetList<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                var type = typeof(T);
                T obj=(T)Activator.CreateInstance(type);
                foreach(var prop in type.GetProperties())
                {
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                }
                list.Add(obj);
            }
            return list;
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
