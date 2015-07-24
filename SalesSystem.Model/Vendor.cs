namespace SalesSystem.Model
    {
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    /*CREATE TABLE Vendors(
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	BulstratUI nchar(13) NOT NULL UNIQUE, -- регистрационния номер по булстат е уникален бива 9 или 13 разряден
	Address nvarchar (max) NULL,
	TownId int NULL,
	CONSTRAINT PK_Vendors PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Vendors_Towns FOREIGN KEY(TownId) REFERENCES Towns (Id)
)
GO*/
    public class Vendor
    {
        private ICollection<Product> products;

        public Vendor()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength (50)]
        public string Name { get; set; }
        [Required]
        [StringLength(13,ErrorMessage = "BulstratUI is 9-13 symbols long", MinimumLength = 9)]
        public string BulstratUI { get; set; }
        public string Address { get; set; }

        public virtual int TownId { get; set; } //ok the nav prop is seted

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        } 

        }
    }
