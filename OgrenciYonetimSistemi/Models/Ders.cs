//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciYonetimSistemi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ders()
        {
            this.DonemDers = new HashSet<DonemDers>();
            this.OgrenciDers = new HashSet<OgrenciDers>();
        }
    
        public int Id { get; set; }
        public string DersKodu { get; set; }
        public byte GrupNo { get; set; }
        public string DersAdi { get; set; }
        public byte KrediSayisi { get; set; }
        public bool Statu { get; set; }
        public int Kullanici_Id { get; set; }
        public System.DateTime KayitTarihi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonemDers> DonemDers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OgrenciDers> OgrenciDers { get; set; }
    }
}