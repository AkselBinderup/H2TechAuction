CREATE TABLE HeavyVehicle (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Height	Decimal,
	Weight	Decimal,
	Length	Decimal,
	VehicleId		INT,
	FOREIGN KEY (VehicleId) REFERENCES Vehicle(Id));
