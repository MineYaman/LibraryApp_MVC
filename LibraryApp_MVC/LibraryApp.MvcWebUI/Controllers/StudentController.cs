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

    public class StudentController : Controller
    {
        IStudentService _studentService = new StudentManager(new StudentRepository());

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddStudent(Ogrenci ogrenci)
        {
            try
            {
                Random rastgele = new Random();
                if (ModelState.IsValid) //model doğru gelmişse
                {
                    ogrenci.Silindi = false;
                    ogrenci.OgrenciNo = rastgele.Next(1, 1000);
                    ogrenci.OgrenciCezaPuani = 0;
                    _studentService.Add(ogrenci);
                    return RedirectToAction("ListStudent");
                }
                else
                {
                    return View("AddStudent");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("", error.Message);
                return View("AddStudent");
            }
        }

        [HttpGet]
        public ActionResult ListStudent()
        {
            List<Ogrenci> ogrencis = _studentService.GetAll().Where(x => x.Silindi == false).ToList();
            return View(ogrencis);
        }

      
        public ActionResult DeleteStudent(int id)
        {
            _studentService.DeletedById(id);
            return View("ListStudent");
        }


        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var model = _studentService.GetById(id);
            if (model == null)
            {
                throw new Exception(" Öğrenci Seçilmedi..");
            }
            return View("UpdateStudent",model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateStudent(Ogrenci ogrenci)
        {
            try
            {
                if (ModelState.IsValid) //model doğru gelmişse
                {
                    _studentService.Update(ogrenci);
                    return RedirectToAction("ListStudent");
                }
                else
                {
                    return View("UpdateStudent", ogrenci);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("", error.Message);
                return View("UpdateStudent", ogrenci);
            }
        }
    }
}