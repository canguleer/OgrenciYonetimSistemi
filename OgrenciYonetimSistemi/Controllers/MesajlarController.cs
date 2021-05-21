using OgrenciYonetimSistemi.Models.Helper;
using OgrenciYonetimSistemi.Models.Helper.Kullanıcı;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciYonetimSistemi.Controllers
{
    public class MesajlarController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            ChatDetayGetir chat = new ChatDetayGetir()
            {
                YazismaDetayListesi = db.SP_YazismaDetayGetir(4, 2).ToList(),
                YazismaListesi = db.SP_YazismaListesiGetir(2).ToList()
            };

            var mesajlasilanKisi = "Ahmet Güler";

            ViewData["mesajlasilanKisi"] = mesajlasilanKisi;
            ViewData["UserName"] = LoginUser.Adi; 
        


            return View(chat);

            

        }


        public ActionResult _sohbetGecmisiGetir(int? SohbetGecmisiIstenilenUye_Id)
        {
            int loginUser_Id = 2;

            ChatSohbetGecmisiGetir model = new ChatSohbetGecmisiGetir()
            {
                YazismaDetayListesi = db.SP_YazismaDetayGetir(SohbetGecmisiIstenilenUye_Id, loginUser_Id).ToList()
            };
            return PartialView("_sohbetGecmisiGetir", model);
        }



    }

}