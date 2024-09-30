CREATE TABLE ProfessionalCar (
		Id INT PRIMARY KEY IDENTITY(1,1),
		RollCage Bit,
		FireExtinguisher Bit,
		RacingSeat Bit,
		RacingHarness Bit,
		LoadCapacity Int,
		CarId INT,
		FOREIGN KEY (CarId) REFERENCES PersonalCar(Id));