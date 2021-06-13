using OgrenciYonetimSistemi.Models.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciYonetimSistemi.Models.Helper.Ogrenci
{
    public class OgrenciEkle
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Bolum_Id { get; set; }
        public int Cinsiyet_Id { get; set; }
        public int OgrenciNo { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Tc { get; set; }
        public string CepTel { get; set; }
        public string Adres { get; set; }
        public string Resim { get; set; }
        public DateTime DogumTarihi  { get; set; }
    }
}