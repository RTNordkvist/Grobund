
using Dapper;
using Grobund.Data.Models;
using Grobund.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Grobund.DataAccess.Repositories
{
    public class MemberRepository : IRepository<Member,int>
    {
        private readonly IDbConnection _connection;

        public MemberRepository()
        {
        }
        public MemberRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            var output = await _connection.QueryAsync<Member>("dbo.spMembers_GetAll", commandType: CommandType.StoredProcedure);
            return output;
        }

        public async Task<Member> GetById(int id)
        {
            var output = await _connection.QueryAsync<Member>("dbo.spMembers_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
            return output.FirstOrDefault();
        }

        public async Task<Member> Insert(Member member)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("GrobundDB")))
            {
                var p = new DynamicParameters();
                p.Add("@Name", member.Name);
                p.Add("@Email", member.Email);
                p.Add("@PhoneNumber", member.PhoneNumber);
                p.Add("@MobileNumber", member.MobileNumber);
                p.Add("@Registered", member.Registered);
                p.Add("@Address1", member.Address1);
                p.Add("@Address2", member.Address2);
                p.Add("@City", member.City);
                p.Add("@PostalCode", member.PostalCode);
                p.Add("@LandCertificate", member.LandCertificate);
                p.Add("@UserCertificate", member.UserCertificate);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                

                await connection.ExecuteAsync("dbo.spMembers_Insert", p, commandType: CommandType.StoredProcedure);

                member.Id = p.Get<int>("@id");

                return member;

            }
        }

        public async Task<Member> Update(Member member)
        {
            var output = await _connection.QueryAsync<Member>("dbo.spMembers_Update", new
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                PhoneNumber = member.PhoneNumber,
                MobileNumber = member.MobileNumber,
                Registered = member.Registered,
                Address1 = member.Address1,
                Address2 = member.Address2,
                City = member.City,
                PostalCode = member.PostalCode,
                Country = member.Country,
                UserCertificate = member.UserCertificate,
                LandCertificate = member.LandCertificate
            }, commandType: CommandType.StoredProcedure);
            return output.FirstOrDefault();
        }

        public async Task<Member> Delete(int id)
        {
            var output = await _connection.QueryAsync<Member>("dbo.spMembers_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
            return output.FirstOrDefault();
        }

        public async Task Save()
        {
            await _connection.ExecuteAsync("dbo.spMembers_Save", commandType: CommandType.StoredProcedure);
        }

    }
}


//public Member Create<Member>(Member model)
//{
//    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("GrobundDB")))
//    {
//        Data.Models.Member member = (Data.Models.Member)(object)model;
//        var p = new DynamicParameters();
//        p.Add("@Name", member.Name);
//        p.Add("@Email", member.Email);
//        p.Add("@PhoneNumber", member.PhoneNumber);
//        p.Add("@MobileNumber", member.MobileNumber);
//        p.Add("@Registered", member.Registered);
//        p.Add("@Address1", member.Address1);
//        p.Add("@Address2", member.Address2);
//        p.Add("@City", member.City);
//        p.Add("@PostalCode", member.PostalCode);
//        p.Add("@Country", member.Country);
//        p.Add("@UserCertificate", member.UserCertificate);
//        p.Add("@LandCertificate", member.LandCertificate);
//        p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

//        connection.Execute("dbo.spMembers_Insert", p, commandType: CommandType.StoredProcedure);

//        member.Id = p.Get<int>("@Id");

//        return (Member)(object)member; // Cast to Member
//    }
//}

//public Member Read<Member>(int id)
//{
//    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("GrobundDB")))
//    {
//        var p = new DynamicParameters();
//        p.Add("@Id", id);

//        var output = connection.Query<Member>("dbo.spMembers_GetById", p, commandType: CommandType.StoredProcedure).FirstOrDefault();

//        return (Member)(object)output;
//    }
//}

//public Member Update<Member>(Member model)
//{
//    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("GrobundDB")))
//    {
//        Data.Models.Member member = (Data.Models.Member)(object)model;
//        var p = new DynamicParameters();
//        p.Add("@Id", member.Id);
//        p.Add("@Name", member.Name);
//        p.Add("@Email", member.Email);
//        p.Add("@PhoneNumber", member.PhoneNumber);
//        p.Add("@MobileNumber", member.MobileNumber);
//        p.Add("@Registered", member.Registered);
//        p.Add("@Address1", member.Address1);
//        p.Add("@Address2", member.Address2);
//        p.Add("@City", member.City);
//        p.Add("@PostalCode", member.PostalCode);
//        p.Add("@Country", member.Country);
//        p.Add("@UserCertificate", member.UserCertificate);
//        p.Add("@LandCertificate", member.LandCertificate);

//        connection.Execute("dbo.spMembers_Update", p, commandType: CommandType.StoredProcedure);

//        return (Member)(object)member;
//    }
//}

//public bool Delete(int id)
//{
//    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("GrobundDB")))
//    {
//        var p = new DynamicParameters();
//        p.Add("@Id", id);

//        connection.Execute("dbo.spMembers_Delete", p, commandType: CommandType.StoredProcedure);
//    }

//    if (this.Read<Member>(id) == null)
//    {
//        return true;
//    }
//    else
//    {
//        return false;
//    }
//}