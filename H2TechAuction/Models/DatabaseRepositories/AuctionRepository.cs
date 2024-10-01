using H2TechAuction.Models.AuctionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class AuctionRepository : CommonDBModule, IDBRepository<Auction>
{
    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public bool Insert(Auction Input)
    {
        return ExecuteCommand("EXEC SP_x (x,x,x,x)");
    }
    public bool Update(Auction Input, int id)
    {
        throw new NotImplementedException();
    }
}
