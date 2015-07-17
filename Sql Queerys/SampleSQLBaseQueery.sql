-- Create the database Sales if it does not exist
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Sales')
  CREATE DATABASE Sales
GO

USE Sales
GO
  
 --Create tables
CREATE TABLE Measures(
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(10) NOT NULL UNIQUE,
	CONSTRAINT PK_Mesures PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE Towns(
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY CLUSTERED (Id)
 )
GO

CREATE TABLE Vendors(
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	BulstratUI nchar(13) NOT NULL UNIQUE, -- регистрационния номер по булстат е уникален бива 9 или 13 разряден
	Address nvarchar (max) NULL,
	TownId int NULL,
	CONSTRAINT PK_Vendors PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Vendors_Towns FOREIGN KEY(TownId) REFERENCES Towns (Id)
)
GO

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

CREATE TABLE Supermarkets(
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(60) NULL,
	Location nvarchar (100) NOT NULL,
	TownId int NOT NULL,
	CONSTRAINT PK_Supermarkets PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Supermarkets_Towns FOREIGN KEY(TownId) REFERENCES Towns (Id),
	CONSTRAINT uc_Supermarkets UNIQUE (Location, TownId) -- уникалността на обекта се определя от града и локацията му взети заедно
)
GO

CREATE TABLE Sales(
	Id int IDENTITY(1,1) NOT NULL,
	SaledOn date NOT NULL,
	SupermarketId int NOT NULL,
	ProductId int NOT NULL,
	Quantity int NOT NULL,
	CONSTRAINT PK_Sales PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Sales_Supermarkets FOREIGN KEY(SupermarketId) REFERENCES Supermarkets (Id),
	CONSTRAINT FK_Sales_Products FOREIGN KEY(ProductId) REFERENCES Products (Id),
	-- сумата от продажбата като допълнително пропърти в апликейшъна
)
GO