USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS CreateUser

GO


CREATE PROCEDURE CreateUser (
	@Username TEXT,
	@Password Text,
	@CorporateUser Bit,
	@ZipCode NVARCHAR(20),
	@Balance Decimal
)
AS
BEGIN

DECLARE @sql Text

SET @sql = 'IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = ' + @Username + ')
			BEGIN
			CREATE Login ' + @Username + '
			WITH PASSWORD = ''' + @Password + ''',
			DEFAULT_DATABASE=''H2TechAuction''
			CREATE USER ' + @Username + ' FOR LOGIN ' + @Username + '
			END'
EXEC @sql;

INSERT INTO Users (Username, Balance, CorporateUser, ZipCode) VALUES (@Username, @Balance, @CorporateUser, @ZipCode)

EXEC sp_addrolemember 'AuctionUser', @Username;


END
GO;