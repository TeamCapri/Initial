//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ads
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageDataURL { get; set; }
        public string OwnerId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> TownId { get; set; }
        public System.DateTime Date { get; set; }
        public int StatusId { get; set; }
    
        public virtual AdStatuses AdStatuses { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Towns Towns { get; set; }
    }
}
