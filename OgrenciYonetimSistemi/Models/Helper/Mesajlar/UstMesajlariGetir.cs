using OgrenciYonetimSistemi.Models.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciYonetimSistemi.Models.Helper
{
    public class UstMesajlariGetir
    {

        public List<SP_YazismaListesiGetir_Result> YazismaListesi { get; set; }
        public int? OkunmayanMesajSayisi { get; set; }



    }
}