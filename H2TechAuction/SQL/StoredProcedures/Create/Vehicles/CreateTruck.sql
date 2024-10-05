USE H2TechAuction;

GO

DROP PROCEDURE IF EXISTS CreateTruck

GO

CREATE PROCEDURE CreateTruck(
		@HV_Weight	Decimal,
		@HV_Height	Decimal,
		@HV_Length	Decimal,
		@V_Name		NVARCHAR(100),
		@V_Odometer	INT,
		@V_ModelYear	INT,
		@V_Towinghitch	Bit,
		@V_LicensePlate	VARCHAR(15),
		@V_EngineSize	Decimal,
		@V_FuelEconomy	INT,
		@V_FuelCapacity	INT,
		@V_Discriminator	NVARCHAR(50),
		@V_EnergyClass	NVARCHAR(10),
		@V_LicenseType	NVARCHAR(10),
		@LoadCapacity	Decimal
)
AS
BEGIN

INSERT INTO Vehicle (Name, Odometer, Modelyear, Towinghitch, LicensePlate, EngineSize, FuelEconomy, FuelCapacity, Discriminator, EnergyClass, LicenseType)
VALUES (@V_Name, @V_Odometer, @V_ModelYear, @V_Towinghitch, @V_LicensePlate, @V_EngineSize, @V_FuelEconomy, @V_FuelCapacity, @V_Discriminator, @V_EnergyClass, @V_LicenseType)

DECLARE @VehicleId INT
SET @VehicleId = SCOPE_IDENTITY()

INSERT INTO HeavyVehicle (Weight, Height, Length, VehicleId) VALUES (@HV_Weight, @HV_Height, @HV_Length, @VehicleId)

DECLARE @HeavyVehicleId INT
SET @HeavyVehicleId = SCOPE_IDENTITY()

INSERT INTO Truck (LoadCapacity, HeavyVehicleId) VALUES (@LoadCapacity, @HeavyVehicleId)

SELECT @VehicleId AS VehicleId;

END;