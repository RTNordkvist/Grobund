using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.Data.Models
{
    public class AssociationMembership
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public Member Member { get; set; }
        public int? AssociationId { get; set; }
        public Association Association { get; set; }
        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }
    }
}
