﻿USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS GetUserBidHistory;

GO

CREATE PROCEDURE GetUserBidHistoy
(
	@UserId	INT
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
	LEFT JOIN Vehicle AS v ON a.VehicleId = v.Id
	WHERE bh.UserId = @UserId

SET NOCOUNT OFF

END;