using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        int Create(T model);

        T ReadById(int id);
    }
}
