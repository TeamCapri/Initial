using System.Collections.Generic;

namespace SalesSystem.Model
    {
    using System.ComponentModel.DataAnnotations;
    /*
    CREATE TABLE Products(
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL UNIQUE,
	VendorId int NOT NULL,
	MeasureId int NOT NULL,
	Price money NOT NULL,
	CONSTRAINT PK_Products PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Products_Vendors FOREIGN KEY(VendorId) REFERENCES Vendors (Id),
	CONSTRAINT FK_Products_Mesures FOREIGN KEY(MeasureId) REFERENCES Measures (Id)
)
GO
    */

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
        public int VendorId { get; set; } // nav prop in vendors is setpub
        public Measure Measure { get; set; }

        public virtual ICollection<Sale> Sales
            {
            get { return this.sales; }
            set { this.sales = value; }
            }

        }
    }
