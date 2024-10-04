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


--Sat til at køre hver dag ved midnat