using H2TechAuction.Models.AuctionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class BidHistoryRepository : CommonDBModule<CurrentBidModel>, IDBRepository<CurrentBidModel>
{
    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public bool Create(CurrentBidModel Input)
    {
        throw new NotImplementedException();
    }

    public bool Update(CurrentBidModel Input, int id)
    {
        throw new NotImplementedException();
    }

    public CurrentBidModel Read()
    {
        throw new NotImplementedException();
    }
}
