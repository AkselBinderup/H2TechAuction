using H2TechAuction.Models.UserModels.Generators;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.VehicleModels;

public abstract class Vehicle
{
    public int VehicleId { get; set; }
    public string? Name { get; set; }
    public int Kilometers { get; set; }
    public int ModelYear { get; set; }
    public bool TowingHitch { get; set; }
    public LicenseType LicenseType { get; set; }
    public double EngineSize { get; set; }
    public int KilometerLiter { get; set; }
    public int FuelCapacity { get; set; }
    public EnergyClass EnergyClass { get; set; }
    public string? RegistrationNumber { get; set; }
    public Vehicle()
    {
        
    }
    public override string ToString()
    {
        return $"{Name} ({ModelYear})";
    }
}
