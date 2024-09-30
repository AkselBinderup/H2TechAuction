USE H2TechAuction;

GO;

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

INSERT INTO CorporateUsers (UserId, Credit, EAN) VALUES (@UserId, @Credit, @EAN)

END;

GO;

USE H2TechAuction;

GO;

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


GO;

USE H2TechAuction;

GO;

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

USE H2TechAuction;

GO;

DROP PROCEDURE IF EXISTS CreateAuction

GO;

CREATE PROCEDURE CreateAuction
(
	@VehicleId		INT,
	@SellerId		INT,
	@AskingPrice	Decimal
)
AS
BEGIN;

SET NOCOUNT ON

DECLARE @BaseId INT;
EXEC @BaseId = GetBaseReference

INSERT INTO ActiveAuctions (VehicleId, SellerId, AskingPrice, BaseId)
VALUES (@MovieId, @SellerId, @AskingPrice, @BaseId);

SET NOCOUNT OFF;

END;

GO;

USE H2TechAuction;

GO;

DROP PROCEDURE IF EXISTS CreateBaseReference
GO;

CREATE PROCEDURE CreateBaseReference
AS
BEGIN;

SET NOCOUNT ON

INSERT INTO Base DEFAULT VALUES

SET NOCOUNT OFF;

SELECT SCOPE_IDENTITY();
RETURN;

END;

GO;

USE H2TechAuction;

GO;

DROP PROCEDURE IF EXISTS CreateBid

GO;

CREATE PROCEDURE CreateBid
(
	@AuctionId		INT,
	@BidderId		INT,
	@Bid			Decimal
)
AS
BEGIN;

SET NOCOUNT ON

DECLARE @BaseId INT;
EXEC @BaseId = GetBaseReference

INSERT INTO BidHistory (Bid, UserId, AuctionId, BaseId) VALUES (@Bid, @UserId, @BidderId, @BaseId)

SET NOCOUNT OFF;

END;

GO;

USE H2TechAuction;

GO;

CREATE PROCEDURE DeleteAuctions
AS
BEGIN

	CREATE TABLE #BaseToDelete (Id Int);

	DELETE FROM Auctions
	OUTPUT DELETED.BaseId INTO #BaseToDelete
	WHERE BaseId IN (
	SELECT Id
	FROM Base
	WHERE UpdatedAt < DATEADD(Month, -3, GETUTCDATE())
	AND IsActive = 0 )

	DELETE FROM Base
	WHERE Id IN (SELECT Id FROM #BaseToDelete);

END;

GO;

USE H2TechAuction;

GO;

CREATE PROCEDURE DeleteAuctions
AS
BEGIN

	CREATE TABLE #BaseToDelete (Id Int);

	DELETE FROM BidHistory
	OUTPUT DELETED.BaseId INTO #BaseToDelete
	WHERE BaseId IN (
	SELECT Id
	FROM Base
	WHERE UpdatedAt < DATEADD(Month, -3, GETUTCDATE()));

	DELETE FROM Base
	WHERE Id IN (SELECT Id FROM #BaseToDelete);

END;

GO;

USE H2TechAuction;

GO;

DROP PROCEDURE IF EXISTS GetUserBidHistory;

GO;

CREATE PROCEDURE GetUserBidHistoy
(
	@UserId		INT
)
AS
BEGIN;

SET NOCOUNT ON

SELECT
	bh.Bid,
	u.Username,
	v.Name,
	b.CreatedAt
	
	FROM BidHistory AS bh
	LEFT JOIN Users AS u ON bh.UserId = u.Id
	LEFT JOIN Auctions AS a ON bh.AuctionId = a.Id
	LEFT JOIN Base AS b ON bh.BaseId = b.Id
	LEFT JOIN Vehicle AS v ON a.VehicleId = v.Id
	WHERE bh.UserId = @UserId

SET NOCOUNT OFF

END;