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
    public interface IStudentDal : IDisposable
    {
        Ogrenci Add(Ogrenci entity);
        int Update(Ogrenci entity);
        List<Ogrenci> GetAll();
        List<Ogrenci> GetListID(int id);
        List<Ogrenci> DynamicList(Expression<Func<Ogrenci, bool>> predicate);// Dinamik Filtreleme 
        Ogrenci GetById(int id);
        bool DeletedById(int id);
        bool Delete(Ogrenci entity);
        Ogrenci GetByNo(int no);
        int UpdateCeza(int id, int ceza);
    }
}
