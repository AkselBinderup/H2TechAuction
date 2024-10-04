USE H2TechAuction;

GO

CREATE PROCEDURE CreatePrivateUser(
	@Username	NVARCHAR(100),
	@Password	NVARCHAR(100),
	@CprNumber	NVARCHAR(11),
	@ZipCode	NVARCHAR(20),
	@Balance	DECIMAL
)
AS
BEGIN

DECLARE @CorporateUser bit
SET @CorporateUser = 0

EXEC CreateUser @Username, @Password, @CorporateUser, @ZipCode, @Balance

DECLARE @UserId INT
SET @UserId = Scope_Identity()

INSERT INTO PrivateUsers (UserId, CPRNumber) VALUES (@UserId, @CPRNumber)

END;
