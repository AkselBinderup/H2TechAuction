using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.Interfaces;
using H2TechAuction.Models.UserModels;
using H2TechAuction.Models.UserModels.Generators;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;
public class UserRepository : CommonDBModule<User>, IDBRepository<User>
{
    public bool ValidateUser(string? username, string? password)
    {
        try
        {
            SqlCommand cmd = new("SELECT Password FROM Users WHERE Username = @username");
            cmd.Parameters.AddWithValue("@username", username);
            return ExecuteReaderWithParametersAsync(cmd, "Password", password);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            return false;
        }
    }
    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }
    public List<User> ReadAll(int i)
    {
        throw new NotImplementedException();
    }
    public bool Create(User input)
    {
        if (input.GetType() == typeof(PrivateUser))
        {
            var privateUser = (PrivateUser)input;
            return ExecuteCommand(
                $"EXEC CreatePrivateUser @Username = '{privateUser.Username}', " +
                $"@Password = '{privateUser.Password}', @CprNumber = '{privateUser.CPRNumber}', " +
                $"@ZipCode = '{privateUser.ZipCode}', @Balance = {privateUser.Balance}"
            );
        }
        else if (input.GetType() == typeof(CorporateUser))
        {
            var corporateUser = (CorporateUser)input;
            return ExecuteCommand(
                $"EXEC CreateCorporateUser @Username = '{corporateUser.Username}', " +
                $"@Password = '{corporateUser.Password}', @EAN = '{corporateUser.EAN}', " +
                $"@Credit = {corporateUser.Credit}, @ZipCode = '{corporateUser.ZipCode}', " +
                $"@Balance = {corporateUser.Balance}"
            );
        }
        return false;
    }
    public bool Update(User Input, int id)
    {
        throw new NotImplementedException();
    }
    public User Read(string userName, string password)
    {
        string query = "SELECT * FROM Users WHERE Username = @Username";
        SqlCommand cmd = new(query);
        cmd.Parameters.AddWithValue("@Username", userName);
        return ExecuteReader<PrivateUser>(cmd).First();
    }
}
