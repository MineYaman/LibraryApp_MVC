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
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            this._bookDal = bookDal;
        }

        public bool Add(Kitap entity)
        {
            try
            {
                using (IBookDal _bookDal = new BookRepository())
                {
                    var deger = _bookDal.Add(entity);
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
                throw new Exception("Kitap Eklenemedi" + ex.Message);
            }
        }

        public bool Delete(Kitap entity)
        {
            try
            {
                using (IBookDal _bookDal = new BookRepository())
                {
                    var deger = _bookDal.Delete(entity);
                    if (deger == false)
                    {
                        throw new Exception("Kitap silinemedi");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap silinemedi" + ex.Message);
            }
        }

        public bool DeletedById(int id)
        {
            try
            {
                using (IBookDal _bookDal = new BookRepository())
                {
                    var kitap = GetById(id);//var ise nesne döndürür
                    if (kitap == null)
                        throw new Exception("Kitap silinemedi");
                    else
                    {
                        Delete(kitap);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap silinemedi" + ex.Message);
            }
        }

        public List<Kitap> DynamicList(Expression<Func<Kitap, bool>> predicate)
        {
            using (IBookDal _bookDal = new BookRepository())
            {
                return _bookDal.DynamicList(predicate);
            }
        }

        public List<Kitap> GetAll()
        {
            try
            {
                using (IBookDal _bookDal = new BookRepository())
                {
                    return _bookDal.GetAll();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Listelenemedi" + ex.Message);
            }
        }

        public Kitap GetById(int id)
        {
            try
            {
                using (IBookDal _bookDal = new BookRepository())
                {
                    return _bookDal.GetById(id);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Seçilemedi" + ex.Message);
            }
        }

        public bool Update(Kitap entity)
        {
            try
            {
                using (IBookDal _bookDal = new BookRepository())
                {
                    _bookDal.Update(entity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Seçilemedi" + ex.Message);
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
                using (IBookDal _BookDal = new BookRepository())
                {
                    if (disposing)
                        _BookDal.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Kitap> GetListID(int id)
        {
            try
            {
                using (IBookDal _bookDal = new BookRepository())
                {
                    return _bookDal.GetListID(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Listelenemedi" + ex.Message);
            }
        }

        public bool UpdateAlindi(int no)
        {
            try
            {
                using (IBookDal _bookDal = new BookRepository())
                {
                    _bookDal.UpdateAlindi(no);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Seçilemedi" + ex.Message);
            }
        }

        public bool UpdateAlinmadi(int no)
        {
            try
            {
                using (IBookDal _bookDal = new BookRepository())
                {
                    _bookDal.UpdateAlinmadi(no);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kitap Seçilemedi" + ex.Message);
            }
        }
    }
}
