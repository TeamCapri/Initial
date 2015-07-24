namespace SalesSystem.Model
    {
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Town
        {
        /*      CREATE TABLE Towns(
        Id int IDENTITY(1,1) NOT NULL,
        Name nvarchar(50) NOT NULL,
        CONSTRAINT PK_Towns PRIMARY KEY CLUSTERED(Id)
        )
        GO*/
        private ICollection<Vendor> vendors;
        private ICollection<Supermarket> supermarkets;
        public Town()
        {
            this.vendors = new HashSet<Vendor>();
            this.supermarkets = new HashSet<Supermarket>();
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
        public virtual ICollection<Supermarket> Supermarkets
            {
            get { return this.supermarkets; }
            set { this.supermarkets = value; }
            }
        }
    }
