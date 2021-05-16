using OgrenciYonetimSistemi.Models;
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

        public OgrenciYonetimSistemiEntities db = new OgrenciYonetimSistemiEntities();
     
    }
}