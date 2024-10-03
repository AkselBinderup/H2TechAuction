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
        throw new NotImplementedException();
    }

    public bool Create(Auction Input)
    {
        return ExecuteCommand($"EXEC CreateAuction({Input.Vehicle.Id}, {User.Id}, {Input.MinimumAmount})");
    }
    public Auction Read()
    {
        throw new NotImplementedException();
    }
    public List<Auction> ReadAll()
    {
        //reads all
        return null; 

    }
    public bool Update(Auction Input, int id)
    {
        return ExecuteCommand($"EXEC UpdateAuction({Input.AuctionId}, ");
    }
    public List<CurrentBidModel> ReadBidHistory(User user)
    {
        throw new NotImplementedException();
    }
}
