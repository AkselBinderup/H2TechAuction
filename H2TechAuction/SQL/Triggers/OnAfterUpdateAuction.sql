CREATE TRIGGER UpdateBaseUpdatedAt
ON Auctions
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Base
	SET UpdatedAt = GETUTCDATE()
	WHERE Id IN (SELECT BaseId FROM inserted)
	SET NOCOUNT OFF
END;

--Eksempel på en trigger som opdaterer UpdatedAt i Base tabellen når der opdateres i Auctions tabellen.
--Bruges ikke i øjeblikket