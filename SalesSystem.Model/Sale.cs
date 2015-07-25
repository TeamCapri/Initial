namespace SalesSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int SupermarketId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal ItemSum { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supermarket Supermarket { get; set; }
    }
}
