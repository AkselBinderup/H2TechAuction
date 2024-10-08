﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.UserModels.Validation;

public class UserValidation
{
    public static bool ValidateUserName(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return false;
        }
        else if (userName.Length < 3 || userName.Length > 16)
        {
            return false;
        }
        return true;
    }

    public static bool ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return false;
        }
        else if (password.Length < 5 || password.Length > 256)
        {
            return false;
        }
        return true;
    }
}
