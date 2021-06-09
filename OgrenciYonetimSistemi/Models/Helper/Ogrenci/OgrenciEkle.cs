using OgrenciYonetimSistemi.Models.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciYonetimSistemi.Models.Helper.Ogrenci
{
    public class OgrenciEkle
    {
        public List<Bolum> Bolumler { get; set; }
        public int OgrenciNo { get; set; }
        public char TcNo { get; set; }
        public string CepTel { get; set; }
        public string Adres { get; set; }
        public DateTime DogumTarihi  { get; set; }
        public int Cinsiyet  { get; set; }
    }
}