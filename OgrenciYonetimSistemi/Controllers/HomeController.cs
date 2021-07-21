using OgrenciYonetimSistemi.Models.Filters;
using OgrenciYonetimSistemi.Models.Helper;
using OgrenciYonetimSistemi.Models.Helper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciYonetimSistemi.Controllers
{
    [CustomAuthenticationFilter]
    public class HomeController : BaseController
    {

        ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
        TCKimlikDogrulama.KPSPublicSoapClient tcService = new TCKimlikDogrulama.KPSPublicSoapClient();

        public ActionResult Index()
        {

            TcDogrulama();
            var dersler = svc.GetAllLessons();




            List<Ders> model = new List<Ders>();
            foreach (var item in dersler)
            {
                model.Add(new Ders
                {
                    Id = item.Id,
                    DersinAdi = item.DersAdi,
                    GroupNo = item.GrupNo,
                    KrediSayisi = item.KrediSayisi,
                   
                });
            }
        
            DersListesi data = new DersListesi();

            data.Dersler = model;



            return View(data);

        }

        public ActionResult Alerts()
        {



            return View();

        }

        public int TcDogrulama()
        {
            long tc = long.Parse("37076133202");
            bool durum = tcService.TCKimlikNoDogrula(tc, "Can", "Güler", 1997);


            long tc2 = long.Parse("37076133201");
            bool durum2 = tcService.TCKimlikNoDogrula(tc2, "Can", "Güler", 1997);


            return 1;
        }




        public ActionResult DataTable()
        {
            return View();
        }


    }
}