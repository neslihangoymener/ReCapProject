select * from Cars
select * from Brands
select * from Colors

insert into Colors (ColorId,ColorName) values (1,'RED')
insert into Colors (ColorId,ColorName) values (2,'GREY')
insert into Colors (ColorId,ColorName) values (3,'WHITE')
insert into Colors (ColorId,ColorName) values (4,'BLACK')
insert into Colors (ColorId,ColorName) values (5,'GREEN')
insert into Colors (ColorId,ColorName) values (6,'PURPLE')
insert into Colors (ColorId,ColorName) values (7,'YELLOW')
insert into Colors (ColorId,ColorName) values (8,'ORANGE')


insert into Brands (BrandId,BrandName) values (1,'Opel')
insert into Brands (BrandId,BrandName) values (2,'Nissan')
insert into Brands (BrandId,BrandName) values (3,'Volswagen')
insert into Brands (BrandId,BrandName) values (4,'Ford')
insert into Brands (BrandId,BrandName) values (5,'Fiat')



insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (2,1,2,2005,120000,'Opel Corsa')
insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (3,1,3,2005,120000,'Opel Insignia')


insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (4,2,2,2020,200000,'Nissan Micra')
insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (5,2,3,2021,300000,'Nissan Qashqai')
insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (6,2,4,2019,250000,'Nissan Juke')

insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (7,3,2,2018,325000,'Volswagen Passat')
insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (8,3,3,2017,100000,'Volkswagen Jetta')
insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (9,3,4,2016,95000,'Volkswagen Golf')
insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (10,3,5,2015,75000,'Volkswagen Transporter')

insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (11,4,6,2014,120000,'Ford Transporter')
insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (12,4,7,2020,180000,'Ford Fiesta')
insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (13,4,8,2018,75000,'Ford Focus')

insert into cars (Id,BrandId,	ColorId,	ModelYear,	DailyPrice,	Description) values (14,5,1,2018,120000,'Fiat Egea')

update cars set DailyPrice=110 where Id=1