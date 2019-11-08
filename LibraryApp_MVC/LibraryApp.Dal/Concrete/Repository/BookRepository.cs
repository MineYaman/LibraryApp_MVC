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
    public class BookRepository : IBookDal
    {
        LibraryContext context = new LibraryContext();

        public Kitap Add(Kitap entity)
        {
            context.Kitap.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Delete(Kitap entity)
        {
            using (var context = new LibraryContext())
            {
                var result = context.Kitap.FirstOrDefault(x => x.KitapID == entity.KitapID);
                result.Silindi = Convert.ToBoolean(Edeleted.silindi);
                context.SaveChanges();
            }
            return true;
        }

        public bool DeletedById(int id)
        {
            var kitap = GetById(id);
            return Delete(kitap);
        }

        public List<Kitap> DynamicList(Expression<Func<Kitap, bool>> predicate)
        {
            return context.Kitap.Where(predicate).ToList();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<Kitap> GetAll()
        {
            return context.Kitap.AsNoTracking().ToList();
        }

        public Kitap GetById(int id)
        {
            return context.Kitap.Where(x => x.KitapID == id).SingleOrDefault();
        }

        public int Update(Kitap entity)
        {
            using (var context=new LibraryContext())
            {
                var result = context.Kitap.FirstOrDefault(x => x.KitapID == entity.KitapID);
                entity.Silindi = result.Silindi;
                entity.Stok = result.Stok;
                entity.Stok = result.Stok;
                entity.KitapNo = result.KitapNo;
            }
            context.Kitap.AddOrUpdate(entity);
            return context.SaveChanges();  //etkilenen satır sayısını döndürür
        }

        public int UpdateAlindi(int no)
        {
            using (var context = new LibraryContext())
            {
                var result = context.Kitap.FirstOrDefault(x => x.KitapNo == no);
                if(result.KitapDurum == Convert.ToBoolean(EReceived.alindi))
                {
                    return 0;
                }
                result.KitapDurum = Convert.ToBoolean(EReceived.alindi);
                context.Kitap.AddOrUpdate(result);
                return context.SaveChanges();
            } //etkilenen satır sayısını döndürür
        }

        public int UpdateAlinmadi(int no)
        {
            using (var context = new LibraryContext())
            {
                var result = context.Kitap.FirstOrDefault(x => x.KitapNo == no);
                result.KitapDurum = Convert.ToBoolean(EReceived.alinmadi);
                context.Kitap.AddOrUpdate(result);
                return context.SaveChanges();
            } //etkilenen satır sayısını döndürür
        }

        public List<Kitap> GetListID(int id)
        {
            return context.Kitap.Where(x => x.KitapID == id).ToList();
        }
    }
}
