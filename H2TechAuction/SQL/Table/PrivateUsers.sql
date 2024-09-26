﻿CREATE TABLE PrivateUsers (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserId INT,
	CPRNumber	NVARCHAR(11),
	FOREIGN KEY (UserId) REFERENCES Users(Id));