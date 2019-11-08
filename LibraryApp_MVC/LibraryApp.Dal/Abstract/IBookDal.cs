using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Dal.Abstract
{
    public interface IBookDal : IDisposable
    {
        Kitap Add(Kitap entity);
        int Update(Kitap entity);
        List<Kitap> GetAll();
        List<Kitap> GetListID(int id);
        List<Kitap> DynamicList(Expression<Func<Kitap, bool>> predicate);// Dinamik Filtreleme 
        Kitap GetById(int id);
        bool DeletedById(int id);
        bool Delete(Kitap entity);
        int UpdateAlindi(int no);
        int UpdateAlinmadi(int no);
    }
}
