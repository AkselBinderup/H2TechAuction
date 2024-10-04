using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.UserModels;
using H2TechAuction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class AuctionRepository : CommonDBModule<Action>, IDBRepository<Auction>
{
    public bool Delete(int Id)
    {
        return ExecuteCommand($"EXEC SetAuctionInactive({Id})");
    }

    public bool Create(Auction Input)
    {
        return ExecuteCommand($"EXEC CreateAuction({Input.Vehicle.Id}, {User.UserId}, {Input.MinimumAmount})");
    }
    public List<Auction> ReadAll()
    {
        //reads all
        return null; 

    }
    public bool Update(Auction Input, int id)
    {
        return ExecuteCommand($"EXEC UpdateAuction({id}, {Input.MinimumAmount}");
    }

    List<Auction> IDBRepository<Auction>.Read()
    {
        throw new NotImplementedException();
    }
    public List<CurrentBidModel> ReadBidHistory(User user)
    {
        throw new NotImplementedException();
    }
}
