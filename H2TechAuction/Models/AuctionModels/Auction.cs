using H2TechAuction.Models.UserModels;
using H2TechAuction.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.AuctionModels;

public class Auction(Vehicle? vehicle, User? seller, ulong minAmount)
{
    public uint AuctionId { get; set; }
    public Vehicle? Vehicle { get; set; } = vehicle;
    public User? Seller { get; set; } = seller;
    public ulong MinimumAmount { get; set; } = minAmount;

    public static Auction SetForSale(Vehicle? vehicle, User? seller, ulong minAmount)
    {
        return new Auction(vehicle, seller, minAmount);
    }

    public void RecieveBid(ulong bidAmount)
    {

    }

    public void AcceptBid()
    {
    }

    public void FindAuctionById()
    {

    }



}
