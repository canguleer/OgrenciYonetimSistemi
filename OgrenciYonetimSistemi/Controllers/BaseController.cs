using OgrenciYonetimSistemi.Models;
using OgrenciYonetimSistemi.Models.Helper.Kullanıcı;
using OgrenciYonetimSistemi.Models.Helper.Result;
using OgrenciYonetimSistemi.Models.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciYonetimSistemi.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base

        public OgrenciYonetimSistemiEntities db;
        public KullaniciBilgileri LoginUser;
        public ResultObject ResultData;


        public BaseController()
        {
            db = new OgrenciYonetimSistemiEntities();
            LoginUser = KullaniciHesapBilgileri.GetCurrentUser();
            ResultData = new ResultObject();
        }

    }
}

