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
    
    public partial class PeriodCourse
    {
        public int Id { get; set; }
        public Nullable<int> Period_Id { get; set; }
        public Nullable<int> Teacher_Id { get; set; }
        public Nullable<int> Course_Id { get; set; }
        public bool Statu { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public string DayOfWeek { get; set; }
        public string ClassName { get; set; }
        public Nullable<byte> Capacity { get; set; }
        public Nullable<byte> NumberOfStudentsTakingTheCourse { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Period Period { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
