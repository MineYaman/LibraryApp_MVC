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

    public class EntrustController : Controller
    {
        IBookService _bookService = new BookManager(new BookRepository());
        IEntrustService _entrustService = new EntrustManager(new EntrustRepository());
        IStudentService _studentService = new StudentManager(new StudentRepository());
        
        [HttpGet]
        public ActionResult Entrusted()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Entrusted(Emanet emanet)
        {
            try
            {
                if (emanet.KitapOduncVerilmeTarihi > DateTime.Now)
                {
                    throw new Exception(" Kitap Ödünç Verilme Tarihi Max Bugün Olabilir...");
                }

                if (ModelState.IsValid) //model doğru gelmişse
                {
                    var kontrol1 = _studentService.GetByNo(Convert.ToInt32(emanet.OgrNo));
                    var kontrol2 = _bookService.UpdateAlindi(Convert.ToInt32(emanet.KtpNo));
                    if (kontrol1 != null && kontrol2)
                    {
                        emanet.KitapIadeTarihi = emanet.KitapOduncVerilmeTarihi.Value.AddDays(+10);
                        emanet.KtpDurum = false;
                        _entrustService.Add(emanet);
                        return RedirectToAction("ListEntrust");
                    }
                }
                else
                {
                    return View("Entrusted");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("", error.Message);
                return View("Entrusted");
            }
            return View("Entrusted");
        }

        [HttpGet]
        public ActionResult ListEntrust()
        {
            List<Emanet> emanets = _entrustService.GetAll().Where(x => x.KtpDurum == false).ToList();
            return View(emanets);
        }


        public ActionResult Received(int id)
        {
            int ceza = 0;
            var model = _entrustService.GetById(id);
            _entrustService.Delete(model);
            TimeSpan fark = DateTime.Now.Subtract(model.KitapIadeTarihi.Value);
            ceza = Convert.ToInt32(fark.Days);

            if (ceza > 0)
            {
                model.OgrCezaPuani += ceza;
                _studentService.UpdateCeza(Convert.ToInt32(model.KitapID), Convert.ToInt32(model.OgrCezaPuani));
            }
            _bookService.UpdateAlinmadi(Convert.ToInt32(model.KtpNo));
            _studentService.UpdateCeza(Convert.ToInt32(model.OgrenciID), Convert.ToInt32(model.OgrCezaPuani));
            return RedirectToAction("ListEntrust");
        }
    }
}