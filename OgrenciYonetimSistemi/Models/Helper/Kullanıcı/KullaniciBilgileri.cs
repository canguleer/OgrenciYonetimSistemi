using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciYonetimSistemi.Models.Helper.Kullanıcı
{
    public class KullaniciBilgileri
    {
        public int? Kullanici_Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }

        public int? Role_Id { get; set; }
        public bool IsAuthenticate { get; set; }


        public KullaniciBilgileri()
        {
            IsAuthenticate = false;
        }

        public bool IsUserAuthenticate()
        {
            try
            {
                if (Kullanici_Id == 0 || IsAuthenticate == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


    }





}