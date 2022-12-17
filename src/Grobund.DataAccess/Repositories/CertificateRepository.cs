using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.DataAccess.Repositories
{
    public class CertificateRepository : IRepository<Certificate>
    {
        public int Create(Certificate model)
        {
            throw new NotImplementedException();
        }

        public Certificate ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Certificate FindCertificate(int associationId, int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
