using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.Data.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        public int? SellerId { get; set; }
        public Member Seller { get; set; }
        public int BuyerId { get; set; }
        public Member Buyer { get; set; }
        public DateTime Date { get; set; }
    }
}
