CREATE TABLE PrivatePersonalCar (
		Id INT PRIMARY KEY IDENTITY(1,1),
		IsofixMounts Bit,
		CarId INT,
		FOREIGN KEY (CarId) REFERENCES PersonalCar(Id));
