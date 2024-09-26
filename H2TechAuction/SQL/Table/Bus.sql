CREATE TABLE Bus (
		Id Int PRIMARY KEY IDENTITY(1,1),
		SeatingCapacity Int,
		SleepingCapacity Int,
		ToiletAvailable Bit,
		HeavyVehicleId INT,
		FOREIGN KEY (HeavyVehicleId) REFERENCES HeavyVehicle(Id));