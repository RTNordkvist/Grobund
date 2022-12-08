using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.DataAccess.Repositories
{
    public interface IRepository<T1, T2> where T1 : class
    {
        Task<IEnumerable<T1>> GetAll();
        Task<T1> GetById(T2 id);

        Task<T1> Insert(T1 entity);

        Task<T1> Update(T1 entity);


        Task<T1> Delete(T2 id);

        Task Save();
    }
}


////Classes implementing this inerface should have CRUD functionality
//// they should return a generic type

////Create  
//public T Create<T>(T model);

////Read
//public T Read<T>(int id);

////Update
//public T Update<T>(T model);

////Delete
//public bool Delete(int id);

