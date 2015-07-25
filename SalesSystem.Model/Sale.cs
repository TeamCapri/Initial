namespace SalesSystem.Model
    {
    using System;
    using System.ComponentModel.DataAnnotations;
  
    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
   //     [ForeignKey("Supermarket")]
        public int SupermarketId { get; set; } // nav prop in supermarket is added
     //   [ForeignKey("Product")]
        public int ProductId { get; set; } //nav prop in products is added
        [Required]
        public double Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal ItemSum { get; set; }
      
        //public Product Product { get; set; }
        //public Supermarket Supermarket { get; set; }
     
        }


    }
