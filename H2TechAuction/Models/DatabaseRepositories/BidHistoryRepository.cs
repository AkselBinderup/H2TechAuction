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
using H2TechAuction.Views;
using H2TechAuction.ViewModels;

namespace H2TechAuction.Models.DatabaseRepositories;
public class BidHistoryRepository : CommonDBModule<CurrentBidModel>, IDBRepository<CurrentBidModel>
{
    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public bool Create(CurrentBidModel Input)
    {
        return ExecuteCommand($"EXEC CreateBid {Input.AuctionId}, {LoginScreenViewModel.User.Id}, {Input.CurrentBid}");
    }

    public bool Update(CurrentBidModel Input, int id)
    {
        throw new NotImplementedException();
    }

    public CurrentBidModel Read(string obj, string obj2)
    {
        throw new NotImplementedException();
    }

    public List<CurrentBidModel> ReadAll(int Id)
    {
        SqlCommand cmd = new ($"EXEC GetUserBidHistory @UserId = {Id}");
        return ExecuteReader<CurrentBidModel>(cmd);
    }
}

