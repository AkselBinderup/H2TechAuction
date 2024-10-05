USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS CreatePrivatePersonalCar

GO

CREATE PROCEDURE CreatePrivatePersonalCar(
		@V_Name		NVARCHAR(100),
		@V_Odometer	INT,
		@V_ModelYear	INT,
		@V_Towinghitch	Bit,
		@V_LicensePlate	NVARCHAR(15),
		@V_EngineSize	Decimal,
		@V_FuelEconomy	INT,
		@V_FuelCapacity	INT,
		@V_Discriminator	VARCHAR(50),
		@V_EnergyClass	NVARCHAR(10),
		@V_LicenseType	NVARCHAR(10),
		@PC_SeatCapacity	INT,
		@PC_TrunkWidth	Decimal,
		@PC_TrunkHeight	Decimal,
		@PC_TrunkLength	Decimal,
		@PC_RequireCommercialLicense	Bit,
		@PC_TrunkDimensions	Decimal,
		@IsofixMounts	Bit
)
AS
BEGIN

INSERT INTO Vehicle (Name, Odometer, Modelyear, Towinghitch, LicensePlate, EngineSize, FuelEconomy, FuelCapacity, Discriminator, EnergyClass, LicenseType)
VALUES (@V_Name, @V_Odometer, @V_ModelYear, @V_Towinghitch, @V_LicensePlate, @V_EngineSize, @V_FuelEconomy, @V_FuelCapacity, @V_Discriminator, @V_EnergyClass, @V_LicenseType)

DECLARE @VehicleId INT
SET @VehicleId = SCOPE_IDENTITY()

INSERT INTO PersonalCar (SeatCapacity, TrunkWidth, TrunkHeight, TrunkLength, RequireCommercialLicense, TrunkDimensions, VehicleId)
VALUES (@PC_SeatCapacity, @PC_TrunkWidth, @PC_TrunkHeight, @PC_TrunkLength, @PC_RequireCommercialLicense, @PC_TrunkDimensions, @VehicleId)

DECLARE @PersonalCarId INT
SET @PersonalCarId = SCOPE_IDENTITY()

INSERT INTO PrivatePersonalCar (IsofixMounts, CarId) VALUES (@IsofixMounts, @PersonalCarId)

SELECT @VehicleId AS VehicleId;

END;