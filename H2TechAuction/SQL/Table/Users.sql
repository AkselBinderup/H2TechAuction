CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Username NVARCHAR(50),
	ZipCode NVARCHAR(20),
	Balance Decimal,
	CorporateUser Bit,
	);