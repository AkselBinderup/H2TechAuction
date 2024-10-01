using H2TechAuction.Models.UserModels.Generators;
using H2TechAuction.Models.UserModels.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.UserModels;

public class PrivateUser : User
{
    public string? CPRNumber { get; private set; }
    public int UserId { get; set; }
    public User? User { get; set; }

    public PrivateUser(string cprNumber)
    {
        CPRNumber = string.Empty;
        if (CPRValidation.IsValidCpr(cprNumber))
        {
            CPRNumber = cprNumber;
        }
        else
        {
            var cpr = CPRGenerator.GenerateCPR();
            if (CPRValidation.IsValidCpr(cpr))
            {
                CPRNumber = cpr;
            }
        }
    }
}