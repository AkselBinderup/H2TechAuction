USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS GetActiveAuctions;

GO

CREATE PROCEDURE GetActiveAuctions
(
	@SearchText			NVARCHAR(100) = ''
)
AS
BEGIN;

SET NOCOUNT ON

SELECT TOP 20
	a.AskingPrice,
	v.Name,
	v.ModelYear,
	v.Id,
	a.Id,
	a.CurrentBid
	FROM Auctions AS a
	LEFT JOIN Vehicle AS v ON a.VehicleId = v.Id
	WHERE a.IsActive = 1 AND
	v.Name LIKE '%' + @SearchText + '%'

SET NOCOUNT OFF

END;