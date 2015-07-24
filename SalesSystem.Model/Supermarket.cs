namespace SalesSystem.Model
    {
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    /*CREATE TABLE Supermarkets(
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(60) NULL,
	Location nvarchar (100) NOT NULL,
	TownId int NOT NULL,
	CONSTRAINT PK_Supermarkets PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Supermarkets_Towns FOREIGN KEY(TownId) REFERENCES Towns (Id),
	CONSTRAINT uc_Supermarkets UNIQUE (Location, TownId) -- уникалността на обекта се определя от града и локацията му взети заедно
)
GO*/
    public class Supermarket
    {
        private ICollection<Sale> sales;

        public Supermarket()
        {
            this.sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        [MaxLength (60)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [Index("IX_TownAndLocation", 2, IsUnique = true)]
        public string Location { get; set; }
        [Required]
        [Index("IX_TownAndLocation", 1, IsUnique = true)]
        public virtual int TownId { get; set; }

        public virtual ICollection<Sale> Sales
            {
            get { return this.sales; }
            set { this.sales = value; }
            }
        }
    }
