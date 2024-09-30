using H2TechAuction.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.UserModels;

public abstract class User : IUser
    //base
{
    public string? UserName { get; set; }
    public ushort PostalCode { get; set; }
    public string? Discriminator { get; set; }
    public int BaseId { get; set; }
    //public Base? Base { get; set; }
    public User(){}
    public override string ToString()
    {
        return base.ToString();
    }
}