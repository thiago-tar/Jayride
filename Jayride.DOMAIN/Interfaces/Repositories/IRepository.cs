using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        T Add(T entity);

        void Delete(int id);
    }
}
