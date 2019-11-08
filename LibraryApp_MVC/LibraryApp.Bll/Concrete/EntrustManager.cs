using LibraryApp.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using System.Linq.Expressions;
using LibraryApp.Dal.Abstract;
using LibraryApp.Dal.Concrete.Repository;

namespace LibraryApp.Bll
{
    public class EntrustManager : IEntrustService
    {
        private IEntrustDal _entrustDalDal;

        public EntrustManager(IEntrustDal entrustDal)
        {
            this._entrustDalDal = entrustDal;
        }
        
        public bool Add(Emanet entity)
        {
            try
            {
                using (IEntrustDal _entrustDal = new EntrustRepository())
                {
                    if (string.IsNullOrEmpty(entity.OgrNo.Value.ToString()) || string.IsNullOrEmpty(entity.KtpNo.Value.ToString()))
                    {
                        throw new Exception("Kitap ve Öğrenci Bilgileri Boş Geçilemez.");
                    }
                    var deger = _entrustDal.Add(entity);
                    if (deger == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Ödünç Verilemedi" + ex.Message);
            }
        }

        public bool Delete(Emanet entity)
        {
            try
            {
                using (IEntrustDal _entrustDal = new EntrustRepository())
                {
                    var deger = _entrustDal.Received(entity);
                    if (deger == false)
                    {
                        throw new Exception("Kitap İade Alınamadı");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap İade Alınamadı" + ex.Message);
            }
        }

        public bool DeletedById(int id)
        {
            try
            {
               /* using (IEntrustDal _entrustDal = new EntrustRepository())
                {*/
                    var emanet = GetById(id);//var ise nesne döndürür
                    if (emanet == null)
                        throw new Exception("Kitap İade Alınamadı");
                    else
                    {
                        Delete(emanet);
                        return true;
                    }
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap İade Alınamadı" + ex.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                using (IEntrustDal _entrustDal = new EntrustRepository())
                {
                    if (disposing)
                        _entrustDal.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Emanet> DynamicList(Expression<Func<Emanet, bool>> predicate)
        {
            using (IEntrustDal _entrustDal = new EntrustRepository())
            {
                return _entrustDal.DynamicList(predicate);
            }
            throw new NotImplementedException();
        }

        public List<Emanet> GetAll()
        {
            try
            {
                using (IEntrustDal _entrustDal = new EntrustRepository())
                {
                    return _entrustDal.GetAll();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Ödünç Listesi Listelenemedi" + ex.Message);
            }
        }

        public Emanet GetById(int id)
        {
            try
            {
                using (IEntrustDal _entrustDal = new EntrustRepository())
                {
                    return _entrustDal.GetById(id);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Seçilemedi" + ex.Message);
            }
        }

        public bool Update(Emanet entity)
        {
            try
            {
                using (IEntrustDal _entrustDal = new EntrustRepository())
                {
                    _entrustDal.Update(entity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Seçilemedi" + ex.Message);
            }
        }

        public List<Emanet> GetListID(int id)
        {
            try
            {
                using (IEntrustDal _entrustDal = new EntrustRepository())
                {
                    return _entrustDal.GetListID(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap-Öğrenci Listelenemedi" + ex.Message);
            }
        }
    }
}
