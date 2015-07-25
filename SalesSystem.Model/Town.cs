namespace SalesSystem.Model
    {
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Town
        {

        private ICollection<Vendor> vendors;
        public Town()
        {
            this.vendors = new HashSet<Vendor>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength (50)]
        public string Name { get; set; }
       
        // navigation properties
        public virtual ICollection<Vendor> Vendors
        {
            get { return this.vendors; }
            set { this.vendors = value; }
        }
        
        }
    }
