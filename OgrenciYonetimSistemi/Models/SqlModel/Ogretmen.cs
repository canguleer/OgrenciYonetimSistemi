//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Ogretmen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ogretmen()
        {
            this.DonemDers = new HashSet<DonemDers>();
        }
    
        public int Id { get; set; }
        public int UyeKullanici_Id { get; set; }
        public string TcNo { get; set; }
        public string CepTel { get; set; }
        public Nullable<System.DateTime> DogumTarihi { get; set; }
        public string Adres { get; set; }
        public string Alani { get; set; }
        public bool Statu { get; set; }
        public int Kullanici_Id { get; set; }
        public System.DateTime KayitTarihi { get; set; }
        public Nullable<int> Cinsiyet_Id { get; set; }
    
        public virtual Cinsiyet Cinsiyet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonemDers> DonemDers { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
