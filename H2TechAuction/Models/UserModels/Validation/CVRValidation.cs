using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.UserModels.Validation;

public class CVRValidation
{
    public static bool ValidateCvrNumber(string CvrNumber)
    {
        if (string.IsNullOrEmpty(CvrNumber))
        {
            return false;
        }

        if (CvrNumber.Length != 8)
        {
            return false;
        }

        if (!ulong.TryParse(CvrNumber, out _))
        {
            return false;
        }

        if (CvrNumber[0] == '0')
        {
            return false;
        }

        return true;
    }
}
