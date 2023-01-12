using Dapper;
using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Grobund.DataAccess.Repositories
{
    public class AssociationRepository
    {
        public int Create(Association association)
        {
            string query = "INSERT INTO Associations " +
                "(Name, MaxNoOfCertificates, CertificatePrice)" +
                "VALUES (@Name, @MaxNoOfCertificates, @CertificatePrice);";

            string idQuery = "SELECT LAST_INSERT_ID();";

            using (IDbConnection connection = new MySqlConnection(GlobalConfig.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Name", association.Name);
                p.Add("@MaxNoOfCertificates", association.MaxNoOfCertificates);
                p.Add("@CertificatePrice", association.CertificatePrice);
                //p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute(query, p, commandType: CommandType.Text);
                var id = connection.ExecuteScalar(idQuery);
                int intId = Convert.ToInt32(id);

                association.Id = intId;

                return association.Id;
            }
        }


        public Association GetById(int id)
        {
            string query = @"SELECT * 
                           FROM Associations a
                           LEFT OUTER JOIN Certificates c ON a.Id = c.AssociationId 
                           LEFT OUTER JOIN Members m ON c.OwnerId = m.Id
                           WHERE a.Id = @id";

            var p = new DynamicParameters();
            p.Add("@id", id);

            Dictionary<int, Association> assMap = new Dictionary<int, Association>();

            using (IDbConnection connection = new MySqlConnection(GlobalConfig.GetConnectionString()))
            {
                var association = connection.Query<Association, Certificate, Member, Association>(query,
                    (a, c, m) =>
                    {
                        if (c != null)
                        {
                            c.AssociationId = a.Id;
                        }

                        if (assMap.TryGetValue(a.Id, out var existingAss))
                        {
                            a = existingAss;
                        }
                        else
                        {
                            a.Certificates = new();
                            assMap.Add(a.Id, a);
                        }

                        if (c != null)
                        {
                            c.Owner = m;

                            a.Certificates.Add(c);
                        }
                        return a;
                    },
                    p, commandType: CommandType.Text, splitOn: "Id,Id");
                return association.FirstOrDefault();
            }
        }

        public List<Association> GetAll()
        {
            string query = "SELECT * FROM Associations";

            using (IDbConnection connection = new MySqlConnection(GlobalConfig.GetConnectionString()))
            {
                var associations = connection.Query<Association>(query, commandType: CommandType.Text);
                return associations.ToList();
            }
        }
    }
}
