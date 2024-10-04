﻿CREATE TABLE Auctions (
		Id				Int PRIMARY KEY IDENTITY (1,1),
		SellerId		Int NOT NULL,
		HighestBidderId Int,
		VehicleId		INT NOT NULL,
		AskingPrice		Decimal,
		CurrentBid		Decimal,
		ExpirationDate	DateTime,
		IsActive		Bit
);