using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Model
    {
    /*
    CREATE TABLE Sales(
	Id int IDENTITY(1,1) NOT NULL,
	SaledOn datetime NOT NULL,
	SupermarketId int NOT NULL,
	ProductId int NOT NULL,
	Quantity int NOT NULL,
	CONSTRAINT PK_Sales PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Sales_Supermarkets FOREIGN KEY(SupermarketId) REFERENCES Supermarkets (Id),
	CONSTRAINT FK_Sales_Products FOREIGN KEY(ProductId) REFERENCES Products (Id),
	-- сумата от продажбата като допълнително пропърти в апликейшъна
)
GO
    */
    public class Sale
    {
        private ICollection<Product> products;
        private ICollection<Supermarket> supermarkets;
        public Sale()
        {
            this.products = new HashSet<Product>();
            this.supermarkets = new HashSet<Supermarket>();
        }
        public int Id { get; set; }
        [Required]
        public DateTime SalesOn { get; set; }
        [Required]
        public int SupermarketId { get; set; } // nav prop in supermarket is added
        public int ProductId { get; set; } //nav prop in products is added
        [Required]
        public decimal Quantity { get; set; }

        public virtual ICollection<Product> Products
            {
            get { return this.products; }
            set { this.products = value; }
            }
        public virtual ICollection<Supermarket> Supermarkets
            {
            get { return this.supermarkets; }
            set { this.supermarkets = value; }
            }
        }


    }
