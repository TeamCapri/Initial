//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSSQLtoMYSQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class vendors
    {
        public vendors()
        {
            this.expenses = new HashSet<expenses>();
            this.products = new HashSet<products>();
            this.vendors_products = new HashSet<vendors_products>();
        }
    
        public int id { get; set; }
        public string vendor_name { get; set; }
    
        public virtual ICollection<expenses> expenses { get; set; }
        public virtual ICollection<products> products { get; set; }
        public virtual ICollection<vendors_products> vendors_products { get; set; }
    }
}
