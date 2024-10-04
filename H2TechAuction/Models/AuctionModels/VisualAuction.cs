using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.AuctionModels;

public class VisualAuction
{
    public string? Name { get; set; }
    public int Year {  get; set; }
    public decimal CurrentBid { get; set; }
}
