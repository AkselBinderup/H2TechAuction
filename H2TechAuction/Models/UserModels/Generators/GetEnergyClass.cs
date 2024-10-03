using H2TechAuction.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.UserModels.Generators;

public class GetEnergyClass
{
    public EnergyClass DetermineClass(int modelYear, string? fuel, int kilometerLiter)
    {
        return Enum.TryParse<EnergyClass>(EnergyClassCalculator(modelYear, fuel, kilometerLiter), out var energyClass) ? energyClass : EnergyClass.C;
    }
    private static string EnergyClassCalculator(int ModelYear, string? Fuel, int KilometerLiter)
    {
        if (ModelYear < 2010)
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
                    else if (KilometerLiter >= 20) return "B";
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
