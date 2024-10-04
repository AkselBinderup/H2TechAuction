using H2TechAuction.Models.UserModels.Validation;

namespace H2TechAuction.Models.UserModels;
public class CorporateUser : User
{
    public decimal Credit { get; set; }
    public string? EAN { get; set; }

    public CorporateUser()
    {
        
    }
    public CorporateUser(decimal credit, string cvrNumber)
    {
        Credit = credit;
        if (CVRValidation.ValidateCvrNumber(cvrNumber))
            EAN = cvrNumber;


        //db connection...
    }
    public override string ToString()
    {
        return $"Credit: {Credit} " +
            $"CVRNumber: {EAN}";
    }
}