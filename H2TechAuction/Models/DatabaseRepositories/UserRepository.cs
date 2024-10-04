using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class UserRepository : IDBRepository<User>
{
    public bool Create(User Input)
    {
        throw new NotImplementedException();
    }

    public bool Update(User Input, int id)
    {
        throw new NotImplementedException();
    }

    public List<User> Read()
    {
        throw new NotImplementedException();
    }

    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }
}
