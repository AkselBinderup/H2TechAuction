DROP PROCEDURE IF EXISTS SetAuctionInactive

GO;

CREATE PROCEDURE SetAuctionInactive
(
	@AuctionId		INT
)
AS
BEGIN;

SET NOCOUNT ON


UPDATE Auctions SET IsActive = 0 WHERE Id = @AuctionId

SET NOCOUNT OFF;

END;