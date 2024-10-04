CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Username NVARCHAR(50),
	[Password] NVARCHAR(255) NOT NULL,
	ZipCode NVARCHAR(20),
	Balance Decimal,
	CorporateUser Bit,
	);