﻿USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS DeleteAuctions;

GO

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

--Sat til at køre hver dag ved midnat