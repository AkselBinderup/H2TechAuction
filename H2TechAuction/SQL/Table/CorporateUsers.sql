﻿CREATE TABLE CorporateUser (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserId INT,
	Credit Decimal,
	EAN	NVARCHAR(50),
	FOREIGN KEY (UserId) REFERENCES Users(Id));