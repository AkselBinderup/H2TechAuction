using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.AuctionModels;

public class VisualAuction
{
    public string? Name { get; set; }
    public string? Year {  get; set; }
    public string? CurrentBid { get; set; }
    public int SellerId { get; set;}
    public int VehicleId { get; set; }
}
