CREATE TABLE HeavyVehicle (
	Height	Decimal,
	Weight	Decimal,
	Length	Decimal,
	VehicleId		INT,
	FOREIGN KEY (VehicleId) REFERENCES Vehicle(Id));
