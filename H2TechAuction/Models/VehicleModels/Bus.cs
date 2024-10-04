using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace H2TechAuction.Models.VehicleModels;

public class Bus : HeavyVehicle
{
    public int Height { get; set; }
    public int Weight { get; set; }
    public int Length { get; set; }
    public int SeatingCapacity { get; set; }
    public int SleepingCapacity { get; set; }
    public bool ToiletAvailable { get; set; }

    //    Bus klassen skal håndtere:
    // Kørekorttype: Er som udgangspunkt D.
    //Hvis bussen har trækkrog kræver det
    //imidlertid et DE kørekort.
    // Motorstørrelse: Værdien skal være
    //imellem 4.2 og 15.0 L eller kaste en ’out
    //of range exception’.


    //DB
    public Bus()
    {
        LicenseType = GetLicenseType();
    }
    public LicenseType GetLicenseType()
    {
        if (TowingHitch)
            return LicenseType.DE;
        else
            return LicenseType.D;
    }

    public override string ToString()
    {
        //tostring todo
        return "";      
    }

}
