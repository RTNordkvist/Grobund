using Dapper;
using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.DataAccess.Repositories
{
    public class CertificateRepository
    {
        public Certificate GetById(int id)
        {
            string query = @"SELECT * 
                           FROM Certificates c
                           LEFT OUTER JOIN Associations a ON c.AssociationId = a.Id
                           LEFT OUTER JOIN Members m ON c.OwnerId = m.Id
                           LEFT OUTER JOIN Trades t ON c.Id = t.CertificateId
                           LEFT OUTER JOIN Members s ON t.SellerId = s.Id
                           LEFT OUTER JOIN Members b ON t.BuyerId = b.Id
                           WHERE c.Id = @id";

            var p = new DynamicParameters();
            p.Add("@id", id);

            Dictionary<int, Certificate> cerMap = new Dictionary<int, Certificate>();

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString()))
            {
                var certificate = connection.Query<Certificate, Association, Member, Trade, Member, Member, Certificate>(query,
                    (c, a, m, t, s, b) =>
                    {
                        if (cerMap.TryGetValue(c.Id, out var existingCer))
                        {
                            c = existingCer;
                        }
                        else
                        {
                            c.Trades = new();
                            cerMap.Add(c.Id, c);
                        }

                        c.Association = a;
                        c.Owner = m;

                        if (t != null)
                        {
                            t.CertificateId = c.Id;
                            t.Seller = s;
                            t.Buyer = b;
                            c.Trades.Add(t);
                        }

                        return c;
                    },
                    p, commandType: CommandType.Text, splitOn: "Id,Id");
                return certificate.FirstOrDefault();
            }
        }
    }
}
