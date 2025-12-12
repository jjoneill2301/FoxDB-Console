CREATE TABLE Products(
	ProductID int IDENTITY(1,1) PRIMARY KEY,
	ProductName varchar(20) NOT NULL,
	UnitPrice float NOT NULL
);