//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BootcampManagement.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee_Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<System.DateTimeOffset> DeleteDate { get; set; }
        public bool IsDelete { get; set; }
        public string Employee_Id { get; set; }
        public string Language_Id { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Language Language { get; set; }
    }
}
