using LibraryApp.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using LibraryApp.Dal.Abstract;
using LibraryApp.Dal.Concrete.Repository;

namespace LibraryApp.Bll
{
    public class StaffManager : IStaffService
    {
        private IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            this._staffDal = staffDal;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            using (IStaffDal _staffDal = new StaffRepository())
            {
                if (disposing)
                    _staffDal.Dispose();
            }
        }

        public Yetkili StaffLogin(string UserName, string Password)
        {
            try
            {
                using (IStaffDal _staffDal = new StaffRepository())
                {
                    var _password = ToPassword.CreateMD5(Password);//parola şifre dönüştürme
                    var staff = _staffDal.StaffLogin(UserName, _password);
                    if (staff == null)
                        throw new Exception("Kullanıcı Adı veya Parola Hatalı. ");
                    else
                        return staff;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Giriş Hatası Oluştu. " + ex.Message);
            }
        }
    }
}
