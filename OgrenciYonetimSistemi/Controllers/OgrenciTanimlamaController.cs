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
            return View();
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
    }
}