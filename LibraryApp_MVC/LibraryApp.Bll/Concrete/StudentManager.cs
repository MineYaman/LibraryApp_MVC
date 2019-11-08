using LibraryApp.Interfaces.Abstract;
using LibraryApp.Dal.Abstract;
using LibraryApp.Dal.Concrete.Repository;
using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LibraryApp.Bll
{
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            this._studentDal = studentDal;
        }

        public bool Add(Ogrenci entity)
        {
            try
            {
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    var deger = _studentDal.Add(entity);
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
                throw new Exception("Öğrenci Eklenemedi" + ex.Message);
            }
        }

        public bool Delete(Ogrenci entity)
        {
            try
            {
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    var deger = _studentDal.Delete(entity);
                    if (deger == false)
                    {
                        throw new Exception("Öğrenci silinemedi");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Öğrenci silinemedi" + ex.Message);
            }
        }

        public bool DeletedById(int id)
        {
            try
            {
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    var ogrenci = GetById(id);//var ise nesne döndürür
                    if (ogrenci == null)
                        throw new Exception("Ögrenci silinemedi");
                    else
                    {
                        Delete(ogrenci);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ögrenci silinemedi" + ex.Message);
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
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    if (disposing)
                        _studentDal.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Ogrenci> DynamicList(Expression<Func<Ogrenci, bool>> predicate)
        {
            using (IStudentDal _studentDal = new StudentRepository())
            {
                return _studentDal.DynamicList(predicate);
            }
        }

        public List<Ogrenci> GetAll()
        {
            try
            {
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    return _studentDal.GetAll();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Öğrenci Listelenemedi" + ex.Message);
            }
        }

        public Ogrenci GetById(int id)
        {
            try
            {
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    return _studentDal.GetById(id);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Öğrenci Seçilemedi" + ex.Message);
            }
        }

        public List<Ogrenci> GetListID(int id)
        {
            try
            {
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    return _studentDal.GetListID(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Öğrenci Listelenemedi" + ex.Message);
            }
        }

        public bool Update(Ogrenci entity)
        {
            try
            {
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    _studentDal.Update(entity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Öğrenci Seçilemedi" + ex.Message);
            }
        }

        public Ogrenci GetByNo(int no)
        {
            try
            {
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    return _studentDal.GetByNo(no);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Öğrenci Seçilemedi" + ex.Message);
            }
        }

        public bool UpdateCeza(int id, int ceza)
        {
            try
            {
                using (IStudentDal _studentDal = new StudentRepository())
                {
                    _studentDal.UpdateCeza(id, ceza);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Öğrenci Seçilemedi" + ex.Message);
            }
        }
    }
}
