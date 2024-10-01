using H2TechAuction.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.UserModels;

public abstract class User : IUser
    
{    public string? UserName { get; set; }
    public string PostalCode { get; set; }
    
    public static int Id { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }
}