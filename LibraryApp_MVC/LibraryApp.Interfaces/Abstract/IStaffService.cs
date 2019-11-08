using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces.Abstract
{
    public interface IStaffService 
    {
        Yetkili StaffLogin(string UserName, string Password);
    }
}
