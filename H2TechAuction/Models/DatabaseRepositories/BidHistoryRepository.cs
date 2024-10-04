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
public class BidHistoryRepository : CommonDBModule, IDBRepository<Auction>
{
    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public bool Create(Auction Input)
    {
        return ExecuteCommand($"EXEC CreateBid({Input.AuctionId}, {User.UserId}, {Input.CurrentBid})");
    }

    public bool Update(Auction Input, int id)
    {
        throw new NotImplementedException();
    }

    public List<Auction> Read()
    {
        List<Auction> BidHistory = new();
        var conn = GetConnection();
        using (SqlCommand cmd = new("GetUserBidHistory", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@User", SqlDbType.Int).Value = User.UserId;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Auction auction = new()
                {
                    CurrentBid = reader.GetDecimal(reader.GetOrdinal("Bid_Amount")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    

                };
                BidHistory.Add(auction);

            }
            conn.Close();
        }

        return BidHistory;
    }
}

