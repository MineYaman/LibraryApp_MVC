using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Dal.Abstract
{
    public interface IStaffDal : IDisposable
    {
        Yetkili StaffLogin(string UserName, string Password);
    }
}
