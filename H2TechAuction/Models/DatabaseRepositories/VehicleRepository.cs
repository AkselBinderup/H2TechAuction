using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class VehicleRepository : CommonDBModule<Vehicle>, IDBRepository<Vehicle>
{
    public bool Create(Vehicle Input)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public Vehicle Read()
    {
        throw new NotImplementedException();
    }

    public bool Update(Vehicle Input, int id)
    {
        throw new NotImplementedException();
    }
}
