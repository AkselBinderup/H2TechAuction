using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.AuctionModels;

public class AuctionItemModel
{
    public string? Name { get; set; }
    public string? Year { get; set; }
    public string? Bid { get; set; }
    public string? FinalBid { get; set; }
}
