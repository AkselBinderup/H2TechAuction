namespace H2TechAuction.Models.Interfaces;
public interface IUser
{
    string? UserName {  get; set; }

    int UserId { get; set; }

    string PostalCode { get; set; }
    decimal Balance { get; set; }
    string ToString();
}
