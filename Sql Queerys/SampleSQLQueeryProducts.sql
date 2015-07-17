use Sales

go

insert into Measures (Name) 
Values ('liters'),('kg'), ('pieces')

go

insert into Towns (Name)
Values ('Sofia'),
	   ('Plovdiv'),
	   ('Varna'),
	   ('Burgas'),
	   ('St. Zagora'),
	   ('Targovishte')

go

insert into Vendors (Name, BulstratUI, [Address], TownId)
Values ('Zagorka Corp.', 1215141512, 'Bul. Zagoretz', 5),
	   ('Targovishte Drinks', 1215121516, 'Bul. Tzar Simeon', 6),
	   ('Nestle Sofia Corp.', 1115144524, 'z.k. Svoboda', 1),
	   ('Mlechni Izdeliq OOD', 1411121514, 'z.k. Manastira', 4 ),
	   ('Terter EOOD 2000', 1112112141, 'Bul. Vitosha 12', 3)
go

insert into Products (Name, VendorId, MeasureId, Price)
values ('Beer “Zagorka”', 1, 1, 1.19),
	   ('Vodka “Targovishte”', 2, 1, 7.59),
	   ('Chocolate “Milka”', 1, 3, 2.54),
	   ('Kashkaval "Vitosha"', 4, 2, 12.54),
	   ('Sirene "Terter"', 5, 2, 15.90)

go

insert into Supermarkets (Name, Location, TownId)
Values ('Fantastiko', 'Fantastiko Vitosha', 1),
	   ('Fantastiko', ' Fantastiko Lozenetz', 1),
	   ('Billa', 'Billa Burgas', 4),
	   ('Kaufland', 'Kaufland Center', 6),
	   ('Lidl', 'Lidl BUkston', 2)

go

insert into Sales (SaledOn, SupermarketId, ProductId, Quantity)
Values ('2015-4-15', 1, 1, 3000),
	   ('2015-4-16', 3, 3, 1500),
	   ('2015-4-17', 5, 4, 49),
	   ('18-apr-15', 3, 5, 88)

go