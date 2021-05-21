using OgrenciYonetimSistemi.Controllers;
using OgrenciYonetimSistemi.Models.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciYonetimSistemi.Models.Helper.Kullanıcı
{
    public class KullaniciHesapBilgileri
    {
        //İçinde buluduğu sınıftan nesne oluşturulmadan veya hiç bir nesneye referans olmadan kullanılabilen üyeler static olarak nitelendirilir. ... Static olarak tanımlanan bir metoda program çalıştığı sürece erişilir, böylece sadece bir metot ile birden çok nesne çağırılır.

        public static KullaniciBilgileri GetCurrentUser()

        {
            try
            {
                if (HttpContext.Current.Session["LoginUser"] != null)
                {
                    return (KullaniciBilgileri)HttpContext.Current.Session["LoginUser"];
                }
                else
                {
                    return new KullaniciBilgileri();
                }
            }
            catch (Exception)
            {
                return new KullaniciBilgileri();
            }
        }



        public static KullaniciBilgileri GetUserInformation(int? Kullanici_Id)
        {
            OgrenciYonetimSistemiEntities model = new OgrenciYonetimSistemiEntities();

            try
            {
                var kullanici = model.Kullanici.Where(x => x.Id == Kullanici_Id).Select(x => new KullaniciBilgileri
                {
                    Adi = x.Adi,
                    Soyadi = x.Soyadi,
                    Email = x.Email,
                    IsAuthenticate = true,
                    Kullanici_Id = x.Id,
                    Role_Id = x.Rol_Id
                }).FirstOrDefault();

                return kullanici;

            }
            catch (Exception ex)
            {
                //loglama yapılacak..
                throw new NullReferenceException("Kullanıcı bilgileri alınırken hata meydana geldi", ex);
            }

        }

    


        public static bool ValidateUser(string email, string sifre)

        {
            int User_Id = 0;
            //gelen kullanici adi ve şifreye göre doğrulama yap ve ardından session oluştur..

            HttpContext.Current.Session["LoginUser"] = GetUserInformation(User_Id);
            //cookie oluştur ve devam et..
            return true;

        }


    }
}