CREATE TABLE Orders(
	OrderID int IDENTITY(1,1) PRIMARY KEY,
	CustomerID_FK int FOREIGN KEY REFERENCES Customers(CustomerID),
	ProductID_FK int FOREIGN KEY REFERENCES Products(ProductID),
	Quantity int NOT NULL,
	UnitPrice float NOT NULL,
	OrderDate date
);