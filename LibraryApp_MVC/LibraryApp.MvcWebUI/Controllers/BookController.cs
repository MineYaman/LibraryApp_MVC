using LibraryApp.Bll;
using LibraryApp.Dal.Concrete.Repository;
using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using LibraryApp.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.MvcWebUI.Controllers
{
    [Authorize]

    public class BookController : Controller
    {
        IBookService _bookService = new BookManager(new BookRepository());

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddBook(Kitap kitap)
        {
            try
            {
                if(kitap.KitapEklenmeTarihi>DateTime.Now)
                {
                    throw new Exception(" Kitap Eklenme Tarihi Max Bugün Olabilir...");
                }
                Random rastgele = new Random();

                if (ModelState.IsValid) //model doğru gelmişse
                {
                    kitap.Silindi = false;
                    kitap.KitapDurum = false;
                    kitap.KitapNo = rastgele.Next(1, 1000);
                    _bookService.Add(kitap);
                    return RedirectToAction("ListBook");
                }
                else
                {
                    return View("AddBook");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("", error.Message);
                return View("AddBook");
            }
        }

        [HttpGet]
        public ActionResult ListBook()
        {
            List<Kitap> kitaps = _bookService.GetAll().Where(x=> x.Silindi==false).ToList();
            return View(kitaps);
        }

        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            _bookService.DeletedById(id);
            return RedirectToAction("ListBook");
        }


        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            var model = _bookService.GetById(id);
            if (model == null)
            {
                throw new Exception(" Kitap Seçilmedi..");
            }
            return View("UpdateBook", model);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateBook(Kitap kitap)
        {
            try
            {
                if (kitap.KitapEklenmeTarihi > DateTime.Now)
                {
                    throw new Exception(" Kitap Eklenme Tarihi Max Bugün Olabilir...");
                }

                if (ModelState.IsValid) //model doğru gelmişse
                {
                    _bookService.Update(kitap);
                    return RedirectToAction("ListBook");
                }
                else
                {
                    return View("UpdateBook",kitap);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("", error.Message);
                return View("UpdateBook" , kitap);
            }
        }
        
    }
}