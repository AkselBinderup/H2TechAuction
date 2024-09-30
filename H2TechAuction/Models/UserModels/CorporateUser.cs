using H2TechAuction.Models.UserModels.Validation;

namespace H2TechAuction.Models.UserModels;
public class CorporateUser : User
{
    public decimal Credit { get; set; }
    public string? CvrNumber { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public CorporateUser(decimal credit, string cvrNumber)
    {
        Credit = credit;
        if (CVRValidation.ValidateCvrNumber(cvrNumber))
            CvrNumber = cvrNumber;


        //db connection...
    }
    public override string ToString()
    {
        return $"Credit: {Credit} " +
            $"CVRNumber: {CvrNumber}";
    }
}