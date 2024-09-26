CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY(1,1),
	ZipCode NVARCHAR(20),
	Balance Decimal,
	CorporateUser Bit,
	);