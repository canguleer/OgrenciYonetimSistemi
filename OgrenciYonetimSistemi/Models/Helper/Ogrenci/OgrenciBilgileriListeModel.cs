using OgrenciYonetimSistemi.Models.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciYonetimSistemi.Models.Helper.Ogrenci
{
    public class OgrenciBilgileriListeModel
    {
        public List<SP_OgrenciBilgileriListe_Result> OgrenciListesi { get; set; }
    }
}