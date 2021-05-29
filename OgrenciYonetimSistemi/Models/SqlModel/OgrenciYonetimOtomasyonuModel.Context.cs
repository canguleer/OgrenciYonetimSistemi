﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciYonetimSistemi.Models.SqlModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OgrenciYonetimSistemiEntities : DbContext
    {
        public OgrenciYonetimSistemiEntities()
            : base("name=OgrenciYonetimSistemiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bolum> Bolum { get; set; }
        public virtual DbSet<Cinsiyet> Cinsiyet { get; set; }
        public virtual DbSet<Ders> Ders { get; set; }
        public virtual DbSet<Donem> Donem { get; set; }
        public virtual DbSet<DonemDers> DonemDers { get; set; }
        public virtual DbSet<Fakulte> Fakulte { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Mesajlar> Mesajlar { get; set; }
        public virtual DbSet<Ogrenci> Ogrenci { get; set; }
        public virtual DbSet<OgrenciDers> OgrenciDers { get; set; }
        public virtual DbSet<Ogretmen> Ogretmen { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Hatalog> Hatalog { get; set; }
    
        public virtual ObjectResult<SP_OgrenciListesi_Result> SP_OgrenciListesi()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_OgrenciListesi_Result>("SP_OgrenciListesi");
        }
    
        public virtual ObjectResult<SP_YazismaDetayGetir_Result> SP_YazismaDetayGetir(Nullable<int> yazismaGecmisiIstenilenUye_Id, Nullable<int> loginKullanici_Id)
        {
            var yazismaGecmisiIstenilenUye_IdParameter = yazismaGecmisiIstenilenUye_Id.HasValue ?
                new ObjectParameter("YazismaGecmisiIstenilenUye_Id", yazismaGecmisiIstenilenUye_Id) :
                new ObjectParameter("YazismaGecmisiIstenilenUye_Id", typeof(int));
    
            var loginKullanici_IdParameter = loginKullanici_Id.HasValue ?
                new ObjectParameter("LoginKullanici_Id", loginKullanici_Id) :
                new ObjectParameter("LoginKullanici_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_YazismaDetayGetir_Result>("SP_YazismaDetayGetir", yazismaGecmisiIstenilenUye_IdParameter, loginKullanici_IdParameter);
        }
    
        public virtual ObjectResult<SP_YazismaListesiGetir_Result> SP_YazismaListesiGetir(Nullable<int> loginKullanici_Id)
        {
            var loginKullanici_IdParameter = loginKullanici_Id.HasValue ?
                new ObjectParameter("LoginKullanici_Id", loginKullanici_Id) :
                new ObjectParameter("LoginKullanici_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_YazismaListesiGetir_Result>("SP_YazismaListesiGetir", loginKullanici_IdParameter);
        }
    
        public virtual ObjectResult<SP_OgretmenListesi_Result> SP_OgretmenListesi()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_OgretmenListesi_Result>("SP_OgretmenListesi");
        }
    
        public virtual int SP_HataYakala()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_HataYakala");
        }
    
        public virtual ObjectResult<SP_MesajGonder_Result> SP_MesajGonder(Nullable<int> aliciUye_Id, string mesaj, Nullable<int> kullanici_Id)
        {
            var aliciUye_IdParameter = aliciUye_Id.HasValue ?
                new ObjectParameter("AliciUye_Id", aliciUye_Id) :
                new ObjectParameter("AliciUye_Id", typeof(int));
    
            var mesajParameter = mesaj != null ?
                new ObjectParameter("Mesaj", mesaj) :
                new ObjectParameter("Mesaj", typeof(string));
    
            var kullanici_IdParameter = kullanici_Id.HasValue ?
                new ObjectParameter("Kullanici_Id", kullanici_Id) :
                new ObjectParameter("Kullanici_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_MesajGonder_Result>("SP_MesajGonder", aliciUye_IdParameter, mesajParameter, kullanici_IdParameter);
        }
    
        public virtual ObjectResult<SP_YeniMesajKullaniciListesiGetir_Result> SP_YeniMesajKullaniciListesiGetir(Nullable<int> rol_Id)
        {
            var rol_IdParameter = rol_Id.HasValue ?
                new ObjectParameter("Rol_Id", rol_Id) :
                new ObjectParameter("Rol_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_YeniMesajKullaniciListesiGetir_Result>("SP_YeniMesajKullaniciListesiGetir", rol_IdParameter);
        }
    
        public virtual ObjectResult<SP_MesajOkundu_Result> SP_MesajOkundu(Nullable<int> loginKullanici_Id, Nullable<int> mesajGonderenUye_Id)
        {
            var loginKullanici_IdParameter = loginKullanici_Id.HasValue ?
                new ObjectParameter("LoginKullanici_Id", loginKullanici_Id) :
                new ObjectParameter("LoginKullanici_Id", typeof(int));
    
            var mesajGonderenUye_IdParameter = mesajGonderenUye_Id.HasValue ?
                new ObjectParameter("MesajGonderenUye_Id", mesajGonderenUye_Id) :
                new ObjectParameter("MesajGonderenUye_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_MesajOkundu_Result>("SP_MesajOkundu", loginKullanici_IdParameter, mesajGonderenUye_IdParameter);
        }
    }
}
