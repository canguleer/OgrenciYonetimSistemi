using OgrenciYonetimSistemi.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciYonetimSistemi.Controllers
{
    public class MesajlarController : BaseController
    {
        // GET: Mesajlar
        public ActionResult Index()
        {
            ChatDetayGetir chat = new ChatDetayGetir()
            {
                YazismaDetayListesi = db.SP_YazismaDetayGetir(4, 2).ToList(),
                YazismaListesi = db.SP_YazismaListesiGetir(2).ToList()
            };

            var mesajlasilanKisi = "Ahmet Güler";

            ViewData["mesajlasilanKisi"] = mesajlasilanKisi;


            return View(chat);

        }



        public PartialViewResult _sohbetGecmisiGetir(int? SohbetGecmisiIstenilenUye_Id)
        {
            int loginUser_Id = 2;

            List<Models.SP_YazismaDetayGetir_Result> model = db.SP_YazismaDetayGetir(SohbetGecmisiIstenilenUye_Id, loginUser_Id).ToList();

            return PartialView("_sohbetGecmisiGetir",model);

        }




    }
}