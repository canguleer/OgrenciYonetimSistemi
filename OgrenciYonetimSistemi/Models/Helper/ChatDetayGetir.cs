using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciYonetimSistemi.Models.Helper
{
	public class ChatDetayGetir
	{
        public List<SP_YazismaDetayGetir_Result> YazismaDetayListesi { get; set; }
        public List<SP_YazismaListesiGetir_Result> YazismaListesi { get; set; }

    }
}