using LibraryApp.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;
using static LibraryApp.Dal.Concrete.Repository.Validation_Enum;

namespace LibraryApp.Dal.Concrete.Repository
{
    public class StudentRepository : IStudentDal
    {
        LibraryContext context = new LibraryContext();

        public Ogrenci Add(Ogrenci entity)
        {
            context.Ogrenci.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Delete(Ogrenci entity)
        {
            using (var context = new LibraryContext())
            {
                var result = context.Ogrenci.FirstOrDefault(x => x.OgrenciID == entity.OgrenciID);
                result.Silindi = Convert.ToBoolean(Edeleted.silindi);
                context.SaveChanges();
            }
            return true;
        }

        public bool DeletedById(int id)
        {
            var ogrenci = GetById(id);
            return Delete(ogrenci);
        }

        public List<Ogrenci> DynamicList(Expression<Func<Ogrenci, bool>> predicate)
        {
            return context.Ogrenci.Where(predicate).ToList();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<Ogrenci> GetAll()
        {
            return context.Ogrenci.AsNoTracking().ToList();
        }

        public Ogrenci GetById(int id)
        {
            return context.Ogrenci.Where(x => x.OgrenciID == id).SingleOrDefault();
        }

        public int Update(Ogrenci entity)
        {
            using (var context = new LibraryContext())
            {
                var result = context.Ogrenci.FirstOrDefault(x => x.OgrenciID == entity.OgrenciID);
                entity.Silindi = result.Silindi;
                entity.OgrenciCezaPuani = result.OgrenciCezaPuani;
                entity.OgrenciNo = result.OgrenciNo;
            }
            context.Ogrenci.AddOrUpdate(entity);
            return context.SaveChanges(); //etkilenen satır sayısını döndürür
        }

        public List<Ogrenci> GetListID(int id)
        {
            return context.Ogrenci.Where(x => x.OgrenciID == id).ToList();
        }

        public Ogrenci GetByNo(int no)
        {
            return context.Ogrenci.Where(x => x.OgrenciNo == no).SingleOrDefault();
        }

        public int UpdateCeza(int id, int ceza)
        {
            using (var context = new LibraryContext())
            {
                var result = context.Ogrenci.FirstOrDefault(x => x.OgrenciID == id);
                result.OgrenciCezaPuani += ceza;
                context.Ogrenci.AddOrUpdate(result);
                return context.SaveChanges();
            } 
        }
    }
}
