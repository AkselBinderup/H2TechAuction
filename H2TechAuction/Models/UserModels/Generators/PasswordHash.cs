using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.UserModels.Generators;

public class PasswordHash
{
    public static string HashPassword(string? password)
    {
        using var sha256 = SHA256.Create();
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(passwordBytes);
        return Convert.ToBase64String(hash);
        
    }
}
