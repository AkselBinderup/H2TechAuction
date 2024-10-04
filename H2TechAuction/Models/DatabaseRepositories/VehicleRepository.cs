using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.UserModels;
using H2TechAuction.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class VehicleRepository : CommonDBModule<Vehicle>, IDBRepository<Vehicle>
{
    public bool Create(Vehicle input)
    {
        if (input.GetType() == typeof(PrivatePassengerCar))
        {
            var car = (PrivatePassengerCar)input;
            return ExecuteCommand(
                $"EXEC CreatePrivatePersonalCar @V_Name = '{car.Name}', " +
                $"@V_Odometer = {car.Kilometers}, @V_ModelYear = {car.ModelYear}, " +
                $"@V_Towinghitch = {(car.TowingHitch ? 1 : 0)}, @V_LicensePlate = {car.RegistrationNumber}, " +
                $"@V_EngineSize = {car.EngineSize}, @V_FuelEconomy = {car.KilometerLiter}, " +
                $"@V_FuelCapacity = {car.FuelCapacity}, @V_Discriminator = '{nameof(PrivatePassengerCar)}', " +
                $"@V_EnergyClass = '{car.EnergyClass}', @V_LicenseType = '{car.LicenseType}', " +
                $"@PC_SeatCapacity = {car.AmountOfSeats}, @PC_TrunkWidth = {car.TrunkWidth}, " +
                $"@PC_TrunkHeight = {car.TrunkHeight}, @PC_TrunkLength = {car.TrunkLength}, " +
                $"@PC_RequireCommercialLicense = {(car.RequireCommercialLicense ? 1 : 0)}, " +
                $"@PC_TrunkDimensions = {car.TrunkDimensions}, @IsofixMounts = {(car.IsofixMount ? 1 : 0)}"
            );
        }
        else if (input.GetType() == typeof(ProfessionalPassengerCar))
        {
            var car = (ProfessionalPassengerCar)input;
            return ExecuteCommand(
                $"EXEC CreateProfessionalCar @V_Name = '{car.Name}', " +
                $"@V_Odometer = {car.KilometerLiter}, @V_ModelYear = {car.ModelYear}, " +
                $"@V_Towinghitch = {(car.TowingHitch ? 1 : 0)}, @V_LicensePlate = {car.RegistrationNumber}, " +
                $"@V_EngineSize = {car.EngineSize}, @V_FuelEconomy = {car.KilometerLiter}, " +
                $"@V_FuelCapacity = {car.FuelCapacity}, @V_Discriminator = '{nameof(ProfessionalPassengerCar)}', " +
                $"@V_EnergyClass = '{car.EnergyClass}', @V_LicenseType = '{car.LicenseType}', " +
                $"@PC_SeatCapacity = {car.AmountOfSeats}, @PC_TrunkWidth = {car.TrunkWidth}, " +
                $"@PC_TrunkHeight = {car.TrunkHeight}, @PC_TrunkLength = {car.TrunkLength}, " +
                $"@PC_RequireCommercialLicense = {(car.RequireCommercialLicense ? 1 : 0)}, " +
                $"@PC_TrunkDimensions = {car.TrunkDimensions}, @RollCage = {(car.RollCage ? 1 : 0)}, " +
                $"@FireExtinguisher = {(car.FireExtinguisher ? 1 : 0)}, @RacingHarness = {(car.RacingHarness ? 1 : 0)}, " +
                $"@RacingSeat = {(car.RacingSeat ? 1 : 0)}, @LoadCapacity = {car.LoadCapacity}"
            );
        }
        else if (input.GetType() == typeof(Truck))
        {
            var truck = (Truck)input;
            return ExecuteCommand(
                $"EXEC CreateTruck @HV_Weight = {truck.Weight}, " +
                $"@HV_Height = {truck.Height}, @HV_Length = {truck.Length}, " +
                $"@V_Name = '{truck.Name}', @V_Odometer = {truck.KilometerLiter}, " +
                $"@V_ModelYear = {truck.ModelYear}, @V_Towinghitch = {(truck.TowingHitch ? 1 : 0)}, " +
                $"@V_LicensePlate = {truck.RegistrationNumber}, @V_EngineSize = {truck.EngineSize}, " +
                $"@V_FuelEconomy = {truck.KilometerLiter}, @V_FuelCapacity = {truck.FuelCapacity}, " +
                $"@V_Discriminator = '{nameof(Truck)}', @V_EnergyClass = '{truck.EnergyClass}', " +
                $"@V_LicenseType = '{truck.LicenseType}', @LoadCapacity = {truck.Capacity}"
            );
        }
        else if (input.GetType() == typeof(Bus))
        {
            var bus = (Bus)input;
            return ExecuteCommand(
                $"EXEC CreateBus @HV_Weight = {bus.Weight}, " +
                $"@HV_Height = {bus.Height}, @HV_Length = {bus.Length}, " +
                $"@V_Name = '{bus.Name}', @V_Odometer = {bus.KilometerLiter}, " +
                $"@V_ModelYear = {bus.ModelYear}, @V_Towinghitch = {(bus.TowingHitch ? 1 : 0)}, " +
                $"@V_LicensePlate = {bus.RegistrationNumber}, @V_EngineSize = {bus.EngineSize}, " +
                $"@V_FuelEconomy = {bus.KilometerLiter}, @V_FuelCapacity = {bus.FuelCapacity}, " +
                $"@V_Discriminator = '{nameof(Bus)}', @V_EnergyClass = '{bus.EnergyClass}', " +
                $"@V_LicenseType = '{bus.LicenseType}', @SeatingCapacity = {bus.AmountOfSeats}, " +
                $"@SleepingCapacity = {bus.AmountOfBeds}, @ToiletAvailable = {(bus.Toilet ? 1 : 0)}"
            );
        }
        return false;
    }

    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public Vehicle Read(string obj, string obj2)
    {
        throw new NotImplementedException();
    }

    public List<Vehicle> ReadAll(int Id)
    {
        throw new NotImplementedException();
    }
    public bool Update(Vehicle Input, int id)
    {
        throw new NotImplementedException();
    }
    public bool Delete(int Id, string discriminator)
    {
        return ExecuteCommand($"EXEC DeleteVehicle({Id}, {discriminator}");
    }
}
