using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Core
{
    public interface IRepository<T>
    {
        List<T> SelectAll();
        T SelectById(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(long id);
    }
}
