using Avalonia.Data.Converters;
using Avalonia.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Converters;

public class StringToEnumConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Enum enumValue)
        {
            return enumValue.AddSpacesEnum(); 
        }
        return value?.ToString() ?? string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string stringValue && parameter is Type enumType && enumType.IsEnum)
        {
            foreach (var enumVal in Enum.GetValues(enumType))
            {
                if (stringValue == ((Enum)enumVal).AddSpacesEnum()) 
                {
                    return enumVal;
                }
            }
        }
        return BindingNotification.UnsetValue;
    }
}


