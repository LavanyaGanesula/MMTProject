
USE [MMT]
GO

--drop table ProductCategory

--drop table Product

CREATE TABLE Product 
  ( 
     Id   BIGINT IDENTITY(1, 1) NOT NULL, 
     SKU  NVARCHAR(50) NOT NULL, 
     NAME NVARCHAR(50) NOT NULL, 
     Description NVARCHAR(50) NOT NULL, 
     Price decimal(10,2) Not Null,
     PRIMARY KEY (Id) 
  ) 
GO 


INSERT INTO Product
VALUES
('10000','Television','Smart TV', 2000),
('10001','FitBit','Fit Bit', 2500),
('20000','TreadMill','Tread Mill', 1000),
('20001','Yoga Mat','Yoga Tool Kit', 1500),
('30000','Lawn Mover', 'Lawn Mover', 3000),
('30001','Garden Shed', 'Garden Shed', 3500)

CREATE TABLE Category 
  ( 
     Id   BIGINT IDENTITY(1, 1) NOT NULL, 
     NAME NVARCHAR(50) NOT NULL   
      PRIMARY KEY (Id) 
      ) 
GO 

CREATE TABLE ProductCategory
  ( 
     ProductId   BIGINT NOT NULL, 
     CategoryId BIGINT NOT NULL 
     PRIMARY KEY (ProductId, CategoryId), 
     FOREIGN KEY (ProductId) REFERENCES Product(Id), 
     FOREIGN KEY (CategoryId) REFERENCES Category(Id) 
  )

INSERT INTO Category
VALUES
('Home'),
('Garden'),
('Electronics'),
('Fitness'),
('Toys')



INSERT INTO ProductCategory
VALUES
(1,3),
(2,3),
(3,4),
(4,4),
(4,2),
(5,2)


create PROCEDURE GetProdutsByCategory 
  @CatId int
AS
Begin
    select *
      from product p
      inner join ProductCategory pc on pc.ProductId = p.id
      where pc.CategoryId  = @CatId
End

--drop PROCEDURE GetProdutsByCategory
 --exec GetProdutsByCategory 2
 