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
    
    public partial class Bolum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bolum()
        {
            this.Ogrenci = new HashSet<Ogrenci>();
        }
    
        public int Id { get; set; }
        public int Fakulte_Id { get; set; }
        public string BolumAdi { get; set; }
        public int OgrenciNumaraFormati { get; set; }
        public bool Statu { get; set; }
        public int Kullanici_Id { get; set; }
        public System.DateTime KayitTarihi { get; set; }
    
        public virtual Fakulte Fakulte { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogrenci> Ogrenci { get; set; }
    }
}
