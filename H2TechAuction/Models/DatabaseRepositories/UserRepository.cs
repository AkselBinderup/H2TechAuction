﻿using H2TechAuction.Models.AuctionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class UserRepository : IDBRepository<Auction>
{
    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public bool Create(Auction Input)
    {
        throw new NotImplementedException();
    }

    public bool Update(Auction Input, int id)
    {
        throw new NotImplementedException();
    }

    public Auction Read()
    {
        throw new NotImplementedException();
    }
}
