using OgrenciYonetimSistemi.Models.Helper;
using OgrenciYonetimSistemi.Models.Helper.Kullanıcı;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static OgrenciYonetimSistemi.Models.Helper.Kullanıcı.KullaniciEnum;

namespace OgrenciYonetimSistemi.Controllers
{
    public class MesajlarController : BaseController
    {
        [Authorize]
        public ActionResult Index(int? Id)
        {
            ViewData["MesajDetayiIstenilenUye_Id"] = Id.HasValue ? Id.Value : 0;

            ChatDetayGetir model = new ChatDetayGetir()
            {
                YazismaListesi = db.SP_YazismaListesiGetir(LoginUser.Kullanici_Id).ToList(),
                YeniMesajKullaniciListesi = db.SP_YeniMesajKullaniciListesiGetir(LoginUser.Role_Id).ToList()
            };

            return View(model);

        }


        public ActionResult _sohbetDetaylariGetir(int? SohbetGecmisiIstenilenUye_Id)
        {
            ViewData["Uye_Id"] = SohbetGecmisiIstenilenUye_Id;
            ChatDetayGetir model = new ChatDetayGetir()
            {
                YazismaDetayListesi = db.SP_YazismaDetayGetir(SohbetGecmisiIstenilenUye_Id, LoginUser.Kullanici_Id).ToList()
            };
            return PartialView("_sohbetDetaylariGetir", model);
        }

        public ActionResult _sohbetGecmisiListeGetir()
        {
            ChatDetayGetir model = new ChatDetayGetir()
            {
                YazismaListesi = db.SP_YazismaListesiGetir(LoginUser.Kullanici_Id).ToList(),
            };
            return PartialView("_sohbetGecmisiListeGetir", model);
        }

        public ActionResult _ustMesajlariGetir()
        {
            ChatDetayGetir model = new ChatDetayGetir()
            {
                YazismaListesi = db.SP_YazismaListesiGetir(LoginUser.Kullanici_Id).Take(3).ToList(),
            };
            return PartialView("_ustMesajlariGetir", model);
        }





        [HttpPost]
        public JsonResult MesajGonder(string Mesaj, int? AliciUye_Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Mesaj))
                {
                    ResultData.message = "Mesaj alanı boş olamaz.";
                    ResultData.status = false;
                    return Json(ResultData);
                }
                if (!(AliciUye_Id > 0))
                {
                    ResultData.message = "Lütfen Mesaj atılacak kişiyi seçiniz.";
                    ResultData.status = false;
                    return Json(ResultData);
                }

                var mesaj = db.SP_MesajGonder(AliciUye_Id, Mesaj, LoginUser.Kullanici_Id).FirstOrDefault();
                if (mesaj.Status == true)
                {
                    ResultData = new Models.Helper.Result.ResultObject
                    {
                        data = mesaj,
                        status = true
                    };
                    return Json(ResultData);
                }
            }
            catch (Exception ex)
            {

            }


            ResultData.status = false;
            return Json(ResultData);
        }



    }

}