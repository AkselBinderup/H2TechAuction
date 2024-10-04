﻿USE H2TechAuction

GO

DROP PROCEDURE IF EXISTS UpdateBaseReference

GO

CREATE PROCEDURE UpdateBaseReference(@BaseId	INT)
AS
BEGIN;

SET NOCOUNT ON

UPDATE Base SET UpdatedAt = GETUTCDATE() WHERE BaseId = @BaseId

SET NOCOUNT OFF;

END;