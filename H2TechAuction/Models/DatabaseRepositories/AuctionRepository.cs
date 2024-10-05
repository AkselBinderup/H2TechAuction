using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.UserModels;
using H2TechAuction.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class AuctionRepository : CommonDBModule<Auction>, IDBRepository<Auction>
{
    public bool Delete(int Id)
    {
        return ExecuteCommand($"EXEC SetAuctionInactive({Id})");
    }

    public bool Create(Auction Input)
    {
        //private or corporate userid
        return ExecuteCommand($"EXEC CreateAuction {Input.Vehicle.VehicleId}, {Input.Seller.Id}, {Input.AskingPrice}");
    }
    public List<Auction> ReadAll(int Id)
    {
        SqlCommand cmd = new SqlCommand($"EXEC GetActiveAuctions");
        return ExecuteReader<Auction>(cmd);

    }
    public bool Update(Auction Input, int Id)
    {
        return ExecuteCommand($"EXEC UpdateAuction({Id}, {Input.AskingPrice})");
    }

    public Auction Read(string obj, string obj2)
    {
        throw new NotImplementedException();
    }
}
