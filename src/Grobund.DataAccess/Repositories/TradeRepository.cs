using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.DataAccess.Repositories
{
    public class TradeRepository : IRepository<Trade>
    {
        public int Create(Trade model)
        {
            throw new NotImplementedException();
        }

        public Trade ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Trade> FindTrades(int certificateId)
        {
            throw new NotImplementedException();
        }
    }
}
