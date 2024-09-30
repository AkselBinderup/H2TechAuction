CREATE TABLE Truck (
		Id Int PRIMARY KEY IDENTITY(1,1),
		LoadCapacity Int,
		HeavyVehicleId INT,
		FOREIGN KEY (HeavyVehicleId) REFERENCES HeavyVehicle(Id)
		);