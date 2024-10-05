using H2TechAuction.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.UserModels.Validation;
public class VehicleTypeMapper
{
    private static readonly Dictionary<EnergyClass, int> _energyClassMap = new()
    {
        { EnergyClass.A, 1 },
        { EnergyClass.B, 2 },
        { EnergyClass.C, 3 },
        { EnergyClass.D, 1 } // Assuming you want the same value for EnergyClass.D as A
    };

    private static readonly Dictionary<LicenseType, int> _licenseTypeMap = new()
    {
        { LicenseType.B, 2 },
        { LicenseType.BE, 3 },
        { LicenseType.C, 4 },
        { LicenseType.CE, 5 },
        { LicenseType.D, 6 },
        { LicenseType.DE, 7 }
    };

    public static int GetEnergyClassValue(EnergyClass energyClass)
    {
        return _energyClassMap.TryGetValue(energyClass, out var value) ? value : 0; 
    }

    public static int GetLicenseTypeValue(LicenseType licenseType)
    {
        return _licenseTypeMap.TryGetValue(licenseType, out var value) ? value : 0;
    }
}
