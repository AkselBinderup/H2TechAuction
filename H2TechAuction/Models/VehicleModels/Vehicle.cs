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
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Kilometers { get; set; }
    public int ModelYear { get; set; }
    public bool TowingHitch { get; set; }
    public LicenseType LicenseType { get; set; }
    public double EngineSize { get; set; }
    public int KilometerLiter { get; set; }
    public string? Fuel { get; set; }
    public EnergyClass EnergyClass { get; set; }

    public override string ToString()
    {
        return $"{Name} ({ModelYear})";
    }
    public string GetEnergyClass()
    {
        if(ModelYear < 2010)
        {
            if ("electric" == Fuel || "hydrogen" == Fuel)
            {
                return "A";
            }
            else if (Fuel == "diesel")
            {
                if (KilometerLiter >= 23) return "A";
                else if (KilometerLiter >= 18) return "B";
                else if (KilometerLiter >= 13) return "C";
                else return "D";
            }
            else if (Fuel == "petrol")
            {
                if (KilometerLiter >= 18) return "A";
                else if (KilometerLiter >= 14) return "B";
                else if (KilometerLiter >= 10) return "C";
                else return "D";
            }
            else
            {
                if (Fuel == "electric" || Fuel == "hydrogen")
                {
                    return "A";
                }
                else if (Fuel == "diesel")
                {
                    if (KilometerLiter >= 25) return "A";
                    else if (KilometerLiter  >= 20) return "B";
                    else if (KilometerLiter >= 15) return "C";
                    else return "D";
                }
                else if (Fuel == "petrol")
                {
                    if (KilometerLiter >= 20) return "A";
                    else if (KilometerLiter >= 16) return "B";
                    else if (KilometerLiter >= 12) return "C";
                    else return "D";
                }
            }
        }
        return "unknown";
    }
}
