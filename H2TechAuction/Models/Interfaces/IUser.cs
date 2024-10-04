namespace H2TechAuction.Models.Interfaces;
public interface IUser
{
    string? Username {  get; set; }

    int Id { get; set; }

    string ZipCode { get; set; }
    decimal Balance { get; set; }
    string ToString();
}
