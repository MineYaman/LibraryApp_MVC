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
using System.Web.Security;

namespace LibraryApp.MvcWebUI.Controllers
{

    public class StaffController : Controller
    {
        IStaffService _staffService = new StaffManager(new StaffRepository());

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("StaffLogin");
        }

        [HttpGet]
        public ActionResult StaffLogin()
        {
            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult StaffLogin(Yetkili yetkili)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _yetkili = _staffService.StaffLogin(yetkili.YetkiliAd, yetkili.YetkiliSifre);
                    FormsAuthentication.SetAuthCookie("YetkiliId", false);
                    Session["YetkiliId"] = _yetkili.YetkiliID;
                    Session["YetkiliAdi"] = _yetkili.YetkiliAd;
                    return RedirectToAction("Index", "Anasayfa");
                }
                else
                {
                    return View("StaffLogin");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("", error.Message);
                return View("StaffLogin");
            }
        }

    }
}