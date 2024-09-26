CREATE TABLE HeavyVehicle (
	Height	Decimal,
	Weight	Decimal,
	Length	Decimal,
	Enginesize	Decimal,
	LicenseTypeId	INT,
	VehicleId		INT,
	FOREIGN KEY (LicenseTypeId) REFERENCES LicenseType(Id),
	FOREIGN KEY (VehicleId) REFERENCES Vehicle(Id));
