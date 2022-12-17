using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.Data.Models
{
    public class Association
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int NoOfCertificates { get; set; }
        public decimal CertificatePrice { get; set; }
    }
}
