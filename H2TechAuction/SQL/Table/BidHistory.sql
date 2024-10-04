CREATE TABLE BidHistory (
		Id INT PRIMARY KEY IDENTITY(1,1),
		Bid Decimal,
		UserId INT,
		AuctionId Int,
		FOREIGN KEY (UserId) REFERENCES Users (Id),
		FOREIGN KEY (AuctionId) REFERENCES Auctions (Id) );