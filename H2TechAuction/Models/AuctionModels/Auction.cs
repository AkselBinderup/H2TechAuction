using H2TechAuction.Models.UserModels;
using H2TechAuction.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.AuctionModels;

public class Auction
{
    public int AuctionId { get; set; }
    public Vehicle? Vehicle { get; set; } 
    public int VehicleId { get; set; }
    public User? Seller { get; set; } 
    public int SellerId { get; set; }
    public decimal AskingPrice { get; set; } 
    public decimal CurrentBid { get; set; }

    public Auction(Vehicle? vehicle, User? seller, decimal minAmount)
    {
        Vehicle = vehicle;
        Seller = seller;
        AskingPrice = minAmount;
    }

    public Auction()
    {
    }

    public Auction SetForSale(Vehicle? vehicle, User? seller, decimal minAmount)
    {
        return new Auction(vehicle, seller, minAmount);
    }

    public void RecieveBid(decimal bidAmount)
    {

    }

    public void AcceptBid()
    {
    }

    public void FindAuctionById()
    {

    }



}
