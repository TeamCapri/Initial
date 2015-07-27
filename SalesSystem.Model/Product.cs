namespace SalesSystem.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Product
    {
        private ICollection<Sale> sales;

        public Product()
        {
            this.sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int VendorId { get; set; }
        public Measure Measure { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }

        public virtual Vendor Vendor { get; set; }
    }
}