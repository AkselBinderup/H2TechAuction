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
    public async Task<bool> ValidateUser(string? username, string? password)
    {
        try
        {
            SqlCommand cmd = new("SELECT PasswordHash FROM Users WHERE Username = @username");
            cmd.Parameters.AddWithValue("@username", username);
            return await ExecuteReaderWithParametersAsync(cmd, "PasswordHash", password);
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
                $"EXEC CreatePrivateUser @Username = '{privateUser.UserName}', " +
                $"@Password = '{privateUser.Password}', @CprNumber = '{privateUser.CPRNumber}', " +
                $"@ZipCode = '{privateUser.PostalCode}', @Balance = {privateUser.Balance}"
            );
        }
        else if (input.GetType() == typeof(CorporateUser))
        {
            var corporateUser = (CorporateUser)input;
            return ExecuteCommand(
                $"EXEC CreateCorporateUser @Username = '{corporateUser.UserName}', " +
                $"@Password = '{corporateUser.Password}', @EAN = '{corporateUser.CvrNumber}', " +
                $"@Credit = {corporateUser.Credit}, @ZipCode = '{corporateUser.PostalCode}', " +
                $"@Balance = {corporateUser.Balance}"
            );
        }
        return false;
    }
    public bool Update(User Input, int id)
    {
        throw new NotImplementedException();
    }
    public User Read(int i)
    {
        throw new NotImplementedException();
    }
}
