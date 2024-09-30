﻿USE H2TechAuction;

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

DECLARE @BaseId INT;
EXEC @BaseId = GetBaseReference

INSERT INTO ActiveAuctions (VehicleId, SellerId, AskingPrice, BaseId)
VALUES (@VehicleId, @SellerId, @AskingPrice, @BaseId);

SET NOCOUNT OFF;

END;