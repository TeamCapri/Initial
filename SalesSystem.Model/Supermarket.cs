namespace SalesSystem.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Supermarket
    {
        private ICollection<Sale> sales;

        public Supermarket()
        {
            this.sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Location { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }
    }
}
