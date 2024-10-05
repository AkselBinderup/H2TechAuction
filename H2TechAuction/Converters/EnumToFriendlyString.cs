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
    public static string AddSpacesEnum(this Enum enumValue)
    {
        if (enumValue == null) return string.Empty;

        var enumName = enumValue.ToString();
        // Add spaces before capital letters
        return System.Text.RegularExpressions.Regex.Replace(enumName, "(\\B[A-Z])", " $1");
    }
}
