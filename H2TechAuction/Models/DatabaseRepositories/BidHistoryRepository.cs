using H2TechAuction.Models.AuctionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class BidHistoryRepository : IDBRepository<AuctionItemModel>
{
    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public bool Create(AuctionItemModel Input)
    {
        throw new NotImplementedException();
    }

    public bool Update(AuctionItemModel Input, int id)
    {
        throw new NotImplementedException();
    }

    public AuctionItemModel Read()
    {
        throw new NotImplementedException();
    }
}
