CREATE TABLE Products
(
     ProductID int,
     ProductName varchar(1000),
     Quantity int
)


INSERT INTO Products(ProductID,ProductName,Quantity) VALUES (1,'Mobile',100)

INSERT INTO Products(ProductID,ProductName,Quantity) VALUES (2,'Laptop',200)

INSERT INTO Products(ProductID,ProductName,Quantity) VALUES (3,'Tabs',300)

SELECT * FROM Products
     	
Server=tcp:productsdbserverk2024.database.windows.net,1433;Initial Catalog=productsdb;Persist Security Info=False;User ID=kannan;Password=Kan@3180;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

