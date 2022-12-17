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
        public AssociationTypeEnum AssociationType { get; set; }
        public int? MaximumMembers { get; set; }
        public decimal Price { get; set; }
    }
}
