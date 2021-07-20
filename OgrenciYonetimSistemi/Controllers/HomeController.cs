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

        public ActionResult Index()
        {
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




        public ActionResult DataTable()
        {
            return View();
        }


    }
}