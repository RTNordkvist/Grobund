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
using System.Diagnostics.Metrics;

namespace Grobund.DataAccess.Repositories
{
    public class TradeRepository
    {
        public int Create(Trade trade)
        {
            string query = "INSERT INTO Trades " +
                            "(CertificateId, SellerId, BuyerId, Date)" +
                            "VALUES (@CertificateId, @SellerId, @BuyerId, @Date);";

            string idQuery = "SELECT LAST_INSERT_ID();";

            using (IDbConnection connection = new MySqlConnection(GlobalConfig.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CertificateId", trade.CertificateId);
                p.Add("@SellerId", trade.SellerId);
                p.Add("@BuyerId", trade.BuyerId);
                p.Add("@Date", trade.Date);
                //p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute(query, p, commandType: CommandType.Text);

                var id = connection.ExecuteScalar(idQuery);
                int intId = Convert.ToInt32(id);
                trade.Id = intId;

                return trade.Id;
            }
        }
    }
}
