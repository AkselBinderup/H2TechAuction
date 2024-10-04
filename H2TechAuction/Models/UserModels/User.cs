using H2TechAuction.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.UserModels;

public abstract class User : IUser
    
{
    public string? Username { get; set; }
    public string ZipCode { get; set; }
    public string? Password { get; set; }
    public decimal Balance { get; set; }

    public int Id { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }
}