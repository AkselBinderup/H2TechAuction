USE H2TechAuction;

CREATE TABLE LicenseType ( Id INT PRIMARY KEY IDENTITY(1,1), Type NVARCHAR(20));

INSERT INTO LicenseType (Type) VALUES ('A'), ('B'), ('BE'), ('C'), ('CE'), ('D'), ('DE');

CREATE TABLE EnergyClass ( Id INT Primary Key IDENTITY(1,1), Type NVARCHAR(10) );

INSERT INTO EnergyClass (Type) VALUES ('A'), ('B'), ('C'), ('D');

CREATE TABLE Vehicle ( 
		Id INT PRIMARY KEY IDENTITY (1,1),
		Name	NVARCHAR(100),
		Odometer Int,
		LicensePlate VARCHAR(15),
		ModelYear Int,
		Towinghitch Bit,
		LicenseType Int NOT NULL DEFAULT 1,
		EngineSize Decimal,
		FuelEconomy Int,
		FuelCapacity Int,
		EnergyClass Int NOT NULL DEFAULT 1,
		Discriminator NVARCHAR(50),
		FOREIGN KEY (LicenseType) references LicenseType (Id),
		FOREIGN KEY (EnergyClass) references EnergyClass (Id));

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY(1,1),
	ZipCode NVARCHAR(20),
	Balance Decimal,
	CorporateUser Bit,
	);

CREATE TABLE Auctions (
		Id				Int PRIMARY KEY IDENTITY (1,1),
		SellerId		Int NOT NULL,
		HighestBidderId Int,
		VehicleId		INT NOT NULL,
		AskingPrice		Decimal,
		CurrentBid		Decimal,
		BaseId			INT,
		ExpirationDate	DATETIME,
		IsActive		Bit
);

CREATE TABLE Base( 
	Id INT PRIMARY KEY IDENTITY(1,1),
	CreatedAt	DATETIME DEFAULT GETUTCDATE(),
	UpdatedAt	DATETIME);

CREATE TABLE BidHistory (
		Id INT PRIMARY KEY IDENTITY(1,1),
		Bid Decimal,
		UserId INT,
		AuctionId Int,
		BaseId INT,
		FOREIGN KEY (BaseId) REFERENCES Base(Id),
		FOREIGN KEY (UserId) REFERENCES Users (Id),
		FOREIGN KEY (AuctionId) REFERENCES Auctions (Id) );

CREATE TABLE HeavyVehicle (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Height	Decimal,
	Weight	Decimal,
	Length	Decimal,
	VehicleId		INT,
	FOREIGN KEY (VehicleId) REFERENCES Vehicle(Id));

CREATE TABLE Bus (
		Id Int PRIMARY KEY IDENTITY(1,1),
		SeatingCapacity Int,
		SleepingCapacity Int,
		ToiletAvailable Bit,
		HeavyVehicleId INT,
		FOREIGN KEY (HeavyVehicleId) REFERENCES HeavyVehicle(Id));

CREATE TABLE CorporateUser (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserId INT,
	Credit Decimal,
	EAN	NVARCHAR(50),
	FOREIGN KEY (UserId) REFERENCES Users(Id));




CREATE TABLE PersonalCar (
		Id Int PRIMARY KEY IDENTITY(1,1),
		TrunkWidth Decimal,
		TrunkHeight Decimal,
		TrunkLength Decimal,
		SeatCapacity Int,
		RequireCommercialLicense Bit,
		TrunkDimensions Decimal,
		VehicleId INT,
		FOREIGN KEY (VehicleId) REFERENCES Vehicle(Id));

CREATE TABLE PrivatePersonalCar (
		Id INT PRIMARY KEY IDENTITY(1,1),
		IsofixMounts Bit,
		CarId INT,
		FOREIGN KEY (CarId) REFERENCES PersonalCar(Id));

CREATE TABLE PrivateUsers (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserId INT,
	CPRNumber	NVARCHAR(11),
	FOREIGN KEY (UserId) REFERENCES Users(Id));

CREATE TABLE ProfessionalCar (
		Id INT PRIMARY KEY IDENTITY(1,1),
		RollCage Bit,
		FireExtinguisher Bit,
		RacingSeat Bit,
		RachingHarness Bit,
		LoadCapacity Int,
		CarId INT,
		FOREIGN KEY (CarId) REFERENCES PersonalCar(Id));

CREATE TABLE Truck (
		Id Int PRIMARY KEY IDENTITY(1,1),
		LoadCapacity Int,
		HeavyVehicleId INT,
		FOREIGN KEY (HeavyVehicleId) REFERENCES HeavyVehicle(Id)
		);



