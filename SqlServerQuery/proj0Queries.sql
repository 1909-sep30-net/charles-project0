CREATE SCHEMA caproj0

GO

--Location
--LocationID (PK)
--Name
--Phone
--Inventory   --<-- no, and makes no sense.
--MangerID (FK)  <-- no, stored in Manager table.

CREATE TABLE caproj0.Manager
(
	ManagerID		INT				NOT NULL		IDENTITY		PRIMARY KEY,
	ManagerPW		NVARCHAR(20)	NOT NULL
)

CREATE TABLE caproj0.StoreLocation
(
	LocationID		INT				NOT NULL		IDENTITY		PRIMARY KEY,
	Name			NVARCHAR(40)	NOT NULL,
	Phone			NVARCHAR(40)	NOT NULL,
	Manager			INT				NOT NULL		FOREIGN KEY REFERENCES			caproj0.Manager (ManagerID)
)

Create TABLE caproj0.Product
(
	ProductID		INT				NOT NULL		IDENTITY		PRIMARY KEY,
	PName			NVARCHAR(15)	NOT NULL,
	SalesName		NVARCHAR(40),
	Cost			MONEY,
	SalesPrice		MONEY
)

CREATE TABLE caproj0.Inventory
(
	LocationID			INT				NOT NULL		FOREIGN KEY REFERENCES			caproj0.StoreLocation (LocationID),
	ProductID			INT				NOT NULL		FOREIGN KEY REFERENCES			caproj0.Product (ProductID),
	Quantity			INT				NOT NULL

)

--Customer
--Phone(PK)
--FName
--LName
--CustomerPW
--FavProdID (FK)

CREATE TABLE caproj0.Customer
(
	CustomerID			INT				NOT NULL		IDENTITY		PRIMARY KEY,
	Phone				NVARCHAR(32)	NOT NULL,
	FName				NVARCHAR(32)	NOT NULL,
	LName				NVARCHAR(32)	NOT NULL,
	FavProdID			INT				NOT NULL		FOREIGN KEY REFERENCES			caproj0.Product (ProductID)
)

--Order ID has been intended to be based on a HEX value: Method from https://stackoverflow.com/questions/703019/convert-integer-to-hex-and-hex-to-integer
--bigint is the only thing that can hold it, but FFFF for all 4 quartets is impossible.
--settle on bigint.

CREATE TABLE caproj0.CustOrder
(
	OrderID				BIGINT			NOT NULL		IDENTITY		PRIMARY KEY,

	CustomerID			INT				NOT NULL		FOREIGN KEY REFERENCES			caproj0.Customer (CustomerID),
	LocationID			INT				NOT NULL		FOREIGN KEY REFERENCES			caproj0.StoreLocation (LocationID)

)

--LineItem
--OrderID (FK)
--ProductID(FK)
--Quantity

CREATE TABLE caproj0.LineItem
(
	OrderID				BIGINT			FOREIGN KEY REFERENCES			caproj0.CustOrder (OrderID),
	ProductID			INT				FOREIGN KEY REFERENCES			caproj0.Product (ProductID),
	Quantity			INT
)


