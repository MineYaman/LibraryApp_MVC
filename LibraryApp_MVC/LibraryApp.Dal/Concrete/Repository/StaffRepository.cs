using LibraryApp.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;

namespace LibraryApp.Dal.Concrete.Repository
{
    public class StaffRepository : IStaffDal
    {
        LibraryContext context = new LibraryContext();

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public Yetkili StaffLogin(string UserName, string Password)
        {
            return context.Yetkili.Where(x => x.YetkiliAd == UserName && x.YetkiliSifre == Password).SingleOrDefault();
        }
    }
}
