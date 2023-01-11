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
    public class TradeRepository
    {
        public int Create(Trade trade)
        {
            string query = "INSERT INTO dbo.trades " +
                            "(CertificateId, SellerId, BuyerId, Date)" +
                            "VALUES (@CertificateId, @SellerId, @BuyerId, @Date)" +
                            "SELECT @id = SCOPE_IDENTITY();";

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CertificateId", trade.CertificateId);
                p.Add("@SellerId", trade.SellerId);
                p.Add("@BuyerId", trade.BuyerId);
                p.Add("@Date", trade.Date);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute(query, p, commandType: CommandType.Text);
                trade.Id = p.Get<int>("@id");

                return trade.Id;
            }
        }
    }
}
