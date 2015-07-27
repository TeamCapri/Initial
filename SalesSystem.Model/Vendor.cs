namespace SalesSystem.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vendor
    {
        private ICollection<Product> products;

        public Vendor()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(13, ErrorMessage = "BulstratUI is 9-13 symbols long", MinimumLength = 9)]
        [Index(IsUnique = true)]
        public string BulstratUI { get; set; }
        public string Address { get; set; }
        public int TownId { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public virtual Town Town { get; set; }
    }
}