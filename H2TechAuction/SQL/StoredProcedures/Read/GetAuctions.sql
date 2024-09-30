USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS GetActiveAuctions;

GO

CREATE PROCEDURE GetActiveAuctions
(
	@SearchText			NVARCHAR(100) = '',
	@UserId				INT
)
AS
BEGIN;

SET NOCOUNT ON

SELECT TOP 20
	a.AskingPrice
	FROM Auctions AS a
	LEFT JOIN Vehicle AS v ON a.VehicleId = v.Id

SET NOCOUNT OFF

END;