USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS GetActiveAuctions;

GO

CREATE PROCEDURE GetActiveAuctions
(
    @SearchText NVARCHAR(100) = '',
    @VehicleId INT = NULL  
)
AS
BEGIN

    SET NOCOUNT ON;

    SELECT TOP 20
        a.AskingPrice,
        v.Name,
        v.ModelYear,
        v.Id AS VehicleId,
        a.SellerId AS SellerId,
        a.CurrentBid,
        a.Id AS AuctionId 
    FROM Auctions AS a
    LEFT JOIN Vehicle AS v ON a.VehicleId = v.Id
    WHERE a.IsActive = 1 
      AND v.Name LIKE '%' + @SearchText + '%'
      AND (@VehicleId IS NULL OR v.Id = @VehicleId); 

    SET NOCOUNT OFF;

END;