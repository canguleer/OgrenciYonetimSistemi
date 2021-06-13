using OgrenciYonetimSistemi.Models.Filters;
using OgrenciYonetimSistemi.Models.Helper.Ogrenci;
using OgrenciYonetimSistemi.Models.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciYonetimSistemi.Controllers
{
    [CustomAuthenticationFilter]
    public class OgrenciTanimlamaController : BaseController
    {

        public ActionResult Index()
        {
            OgrenciBilgileriListeModel model = new OgrenciBilgileriListeModel()
            {
                OgrenciListesi = db.SP_OgrenciBilgileriListe(null).ToList()
            };
            return View(model);
        }

        public PartialViewResult _ogrenciEklePartialView()
        {

            var bolumModel = (from _bolumList in db.Bolum
                              where _bolumList.Statu == true
                              select new
                              {
                                  Value = _bolumList.Id,
                                  Text = _bolumList.BolumAdi
                              }).ToList();

            ViewData["BolumListesi"] = new SelectList(bolumModel, "Value", "Text");



            return PartialView("_ogrenciEklePartialView");

        }

        [HttpPost]
        public JsonResult OgrenciEkle(OgrenciEkle post_model)
        {
            try
            {
                var ogrenci = db.SP_OgrenciEkle(post_model.Adi,
                                              post_model.Soyadi,
                                              post_model.Sifre,
                                              post_model.Email,
                                              post_model.Resim,
                                              post_model.OgrenciNo,
                                              post_model.Bolum_Id,
                                              post_model.Tc,
                                              post_model.CepTel,
                                              post_model.DogumTarihi,
                                              post_model.Adres,
                                              post_model.Cinsiyet_Id,
                                              LoginUser.Kullanici_Id).FirstOrDefault();
                if (ogrenci.Status == true)
                {
                    var ogrenciGetir = db.SP_OgrenciBilgileriListe(ogrenci.Kayit_Id).FirstOrDefault(); //yeni eklenen öğrenci bilgisi
                    ResultData = new Models.Helper.Result.ResultObject
                    {
                        data = ogrenciGetir,
                        status = true
                    };
                    return Json(ResultData);
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex, "Hata");
                ResultData = new Models.Helper.Result.ResultObject
                {
                    message = "İşleminiz sırasında istisna ile karşılaşıldı.",
                    status = false
                };
            }
            return Json(ResultData);
        }



    }
}