using OgrenciYonetimSistemi.Models.Helper.Kullanıcı;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OgrenciYonetimSistemi.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            var kullanici = db.Kullanici.Where(x => x.Email == Email && x.Sifre == Password && x.Statu == true).FirstOrDefault();
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.Email, false);
                System.Web.HttpContext.Current.Session["LoginUser"] = KullaniciHesapBilgileri.GetUserInformation(kullanici.Id);

                ResultData = new Models.Helper.Result.ResultObject
                {
                    message = "Giriş Başarılı",
                    status = true,
                };
                return Json(ResultData);
            }



            ResultData = new Models.Helper.Result.ResultObject
            {
                message = "Hatalı Kullanıcı Adı veya Şifre",
                status = false
            };

            return Json(ResultData);


        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session["LoginUser"] = null;
            return RedirectToAction("Login");
        }

        

        public ActionResult ForgetPassword(int? User_Id, string Password)
        {
            return View();
        }


    }
}