using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.VehicleModels;

public class Truck : HeavyVehicle
{
    public int Height { get; set; }
    public int Weight { get; set; }
    public int Length { get; set; }
    public int Capacity { get; set; } 
    public LicenseType GetLicenseType()
    {
        if (TowingHitch)
            return LicenseType.CE;
        else 
            return LicenseType.C;
    }
    public Truck()
    {
        LicenseType = GetLicenseType();
    }
    public override string ToString()
    {
        return "";
    }
}
