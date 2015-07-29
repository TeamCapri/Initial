namespace SalesSystem.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public int VendorId { get; set; }
        public string Period { get; set; }
        public decimal Total { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
