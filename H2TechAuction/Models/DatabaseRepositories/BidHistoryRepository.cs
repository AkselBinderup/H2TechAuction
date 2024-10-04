using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.UserModels;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splat.ModeDetection;

namespace H2TechAuction.Models.DatabaseRepositories;
public class BidHistoryRepository : CommonDBModule<CurrentBidModel>, IDBRepository<CurrentBidModel>
{
    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public bool Create(CurrentBidModel Input)
    {
        return ExecuteCommand($"EXEC CreateBid({Input.AuctionId}, {"User.UserId"}, {Input.Bid})");
    }

    public bool Update(CurrentBidModel Input, int id)
    {
        throw new NotImplementedException();
    }

    public CurrentBidModel Read()
    {
        throw new NotImplementedException();
    }

    public List<CurrentBidModel> ReadAll()
    {
        throw new NotImplementedException();
    }
}

