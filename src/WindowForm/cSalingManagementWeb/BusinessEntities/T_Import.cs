//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Import
    {
        public string ProductID { get; set; }
        public System.DateTime ImportDate { get; set; }
        public string Supplier { get; set; }
        public Nullable<int> Import_Quantity { get; set; }
        public Nullable<int> Import_InStock { get; set; }
        public Nullable<int> Import_OnOrder { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<System.DateTime> ExpirionDate { get; set; }
        public string Import_User { get; set; }
        public Nullable<int> Import_Vote { get; set; }
        public Nullable<int> Import_Status { get; set; }
    }
}
