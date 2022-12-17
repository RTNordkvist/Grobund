using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.Data.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string CertificateNumber { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }
        public int OwnerId { get; set; }
        public Member Owner { get; set; }
    }
}
