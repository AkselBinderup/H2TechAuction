CREATE TABLE Truck (
		Id Int PRIMARY KEY IDENTITY(1,1),
		LoadCapacity Int,
		VehicleId INT,
		FOREIGN KEY (VehicleId) REFERENCES Vehicle(Id)
		);