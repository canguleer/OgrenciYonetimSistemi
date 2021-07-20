//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.PeriodCourse = new HashSet<PeriodCourse>();
            this.StudentCourse = new HashSet<StudentCourse>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Language_Id { get; set; }
        public string CourseCode { get; set; }
        public int GroupNo { get; set; }
        public string CoursName { get; set; }
        public int NumberOfCredits { get; set; }
        public bool Statu { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
    
        public virtual Language Language { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodCourse> PeriodCourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}