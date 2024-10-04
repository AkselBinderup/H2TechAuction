using H2TechAuction.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H2TechAuction.Converters;

public static class EnumToFriendlyString
{
    public static string AddSpacesEnum(this VehicleTypes vehicleType)
    {
        return Regex.Replace(vehicleType.ToString(), "([a-z])([A-Z])", "$1 $2");
    }
}
