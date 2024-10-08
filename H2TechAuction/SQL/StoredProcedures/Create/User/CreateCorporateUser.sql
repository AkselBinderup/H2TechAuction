﻿USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS CreateCorporateUser;

GO

CREATE PROCEDURE CreateCorporateUser(
	@Username	NVARCHAR(100),
	@Password	NVARCHAR(100),
	@EAN		NVARCHAR(50),
	@Credit		DECIMAL,
	@ZipCode	NVARCHAR(20),
	@Balance	DECIMAL
)
AS
BEGIN

DECLARE @CorporateUser bit
SET @CorporateUser = 1

EXEC CreateUser @Username, @Password, @CorporateUser, @ZipCode, @Balance

DECLARE @UserId INT
SET @UserId = Scope_Identity()

INSERT INTO CorporateUser (UserId, Credit, EAN) VALUES (@UserId, @Credit, @EAN)

END;

