using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces
{
    public interface IGenericService<T> : IDisposable
    {
        bool Add(T entity);
        bool Update(T entity);
        List<T> GetAll();
        List<T> GetListID(int id);
        List<T> DynamicList(Expression<Func<T, bool>> predicate); //Dinamik Filtreleme 
        T GetById(int id);
        bool DeletedById(int id);
        bool Delete(T entity);
    }
}
