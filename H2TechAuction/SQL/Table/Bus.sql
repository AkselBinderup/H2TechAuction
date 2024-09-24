CREATE TABLE Bus (
		Id Int PRIMARY KEY IDENTITY(1,1),
		SeatingCapacity Int,
		SleepingCapacity Int,
		ToiletAvailable Bit,
		VehicleId INT,
		FOREIGN KEY (VehicleId) REFERENCES Vehicle(Id));