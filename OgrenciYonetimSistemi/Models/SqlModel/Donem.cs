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
    
    public partial class Donem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donem()
        {
            this.DonemDers = new HashSet<DonemDers>();
        }
    
        public int Id { get; set; }
        public string DonemAdi { get; set; }
        public int Yil { get; set; }
        public System.DateTime BaslamaTarihi { get; set; }
        public System.DateTime BitisTarihi { get; set; }
        public bool Statu { get; set; }
        public int Kullanici_Id { get; set; }
        public System.DateTime KayitTarihi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonemDers> DonemDers { get; set; }
    }
}
