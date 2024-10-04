USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS CreateAuction

GO

CREATE PROCEDURE CreateAuction
(
	@VehicleId		INT,	
	@SellerId		INT,
	@AskingPrice	Decimal
)
AS
BEGIN;

SET NOCOUNT ON

INSERT INTO Auctions (VehicleId, SellerId, AskingPrice)
VALUES (@VehicleId, @SellerId, @AskingPrice);

SET NOCOUNT OFF;

END;