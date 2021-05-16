using OgrenciYonetimSistemi.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciYonetimSistemi.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()  
        {
            ChatDetayGetir chat = new ChatDetayGetir() {
                 YazismaDetayListesi = db.SP_YazismaDetayGetir(4, 2).ToList(),
                  YazismaListesi = db.SP_YazismaListesiGetir(2).ToList()
            };

            var mesajlasilanKisi = "Ahmet Güler";

            ViewData["mesajlasilanKisi"] = mesajlasilanKisi;


            return View(chat);

        }

        public ActionResult DataTable()  
        {
            return View();  
        }

 
    }
} 