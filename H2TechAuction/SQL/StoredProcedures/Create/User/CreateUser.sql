DROP PROCEDURE IF EXISTS CreateUser

GO;


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

SET @sql = 'CREATE User ' + @Username + ' WITH PASSWORD = ''' + @Password + ''', DEFAULT_DATABASE='+@Username+' , CHECK_POLICY = OFF;'
EXEC @sql;

INSERT INTO Users (Username, Balance, CorporateUser, ZipCode) VALUES (@Username, @Balance, @CorporateUser, @ZipCode)

EXEC sp_addrolemember 'AuctionUser', @Username;


END
GO;