//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeEf
{
    using System;
    using System.Collections.Generic;
    
    public partial class USERS
    {
        public int ID { get; set; }
        public string LOGIN { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<int> STATUS { get; set; }
        public string NAME { get; set; }
    
        public virtual STATUS STATUS1 { get; set; }
    }
}
