USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS CreateUser

GO


CREATE PROCEDURE CreateUser (
	@Username NVARCHAR(100),
	@Password NVARCHAR(256),
	@CorporateUser Bit,
	@ZipCode NVARCHAR(20),
	@Balance Decimal
)
AS
BEGIN

DECLARE @sql NVARCHAR(MAX)

--SET @sql = 'IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = [' + @Username + '])
--			BEGIN
--			CREATE Login [' + @Username + ']
--			WITH PASSWORD =[' + @Password + '],
--			DEFAULT_DATABASE=''H2TechAuction''
--			CREATE USER [' + @Username + '] FOR LOGIN [' + @Username + ']
--			END'
--EXEC @sql;

INSERT INTO Users (Username, [Password], Balance, CorporateUser, ZipCode) VALUES (@Username, @Password, @Balance, @CorporateUser, @ZipCode)

--EXEC sp_addrolemember 'AuctionUser', @Username;


END