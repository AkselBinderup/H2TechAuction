USE H2TechAuction

GO

DROP PROCEDURE IF EXISTS ActiveAuctionsTimer

GO

CREATE PROCEDURE ActiveAuctionsTimer
AS
BEGIN;

SET NOCOUNT ON

UPDATE Auctions
    SET IsActive = 0
    WHERE ExpirationDate <= GETUTCDATE() 
    AND IsActive = 1;

SET NOCOUNT OFF;

END;

--Sættes til at køre hvert 15min, Der burde også gøres fra programmet at auctions expiration date kun kan sættes til hvert 15min