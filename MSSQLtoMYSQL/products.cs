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
    
    public partial class products
    {
        public products()
        {
            this.vendors_products = new HashSet<vendors_products>();
        }
    
        public int id { get; set; }
        public int vendor_id { get; set; }
        public string product_name { get; set; }
        public decimal price { get; set; }
    
        public virtual vendors vendors { get; set; }
        public virtual ICollection<vendors_products> vendors_products { get; set; }
    }
}
