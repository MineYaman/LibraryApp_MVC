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
using LibraryApp.Interfaces.Abstract;

namespace LibraryApp.Dal.Concrete.Repository
{
    public class EntrustRepository : IEntrustDal
    {
        LibraryContext context = new LibraryContext();

        public Emanet Add(Emanet entity)
        {
            context.Emanet.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Received(Emanet entity)
        {
            using (var context = new LibraryContext())
            {
                var result = context.Emanet.FirstOrDefault(x => x.KtpNo == entity.KtpNo && x.OgrNo == entity.OgrNo);
                result.KtpDurum = Convert.ToBoolean(EReceived.alindi);
                context.SaveChanges();
            }
            return true;
        }

        public bool ReceivedByID(int id)
        {
            var emanet = GetById(id);
            return Received(emanet);
        }

        public List<Emanet> DynamicList(Expression<Func<Emanet, bool>> predicate)
        {
            return context.Emanet.Where(predicate).ToList();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<Emanet> GetAll()
        {
            return context.Emanet.AsNoTracking().ToList();
        }

        public Emanet GetById(int id)
        {
            return context.Emanet.Where(x => x.EmanetID == id).SingleOrDefault();
        }

        public int Update(Emanet entity)
        {
            context.Emanet.AddOrUpdate(entity);
            return context.SaveChanges(); //etkilenen satır sayısını döndürür
        }

        public List<Emanet> GetListID(int id)
        {
            return context.Emanet.Where(x => x.EmanetID == id).ToList();
        }

    }
}
