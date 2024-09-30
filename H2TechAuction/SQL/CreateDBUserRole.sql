USE H2TechAuction;

CREATE ROLE AuctionUser;

GRANT EXECUTE TO AuctionUser;

DENY SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO AuctionUser;

EXEC sp_addrolemember 'AuctionUser', 'User';