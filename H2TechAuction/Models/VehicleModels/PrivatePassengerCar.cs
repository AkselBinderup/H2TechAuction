namespace H2TechAuction.Models.VehicleModels;
public class PrivatePassengerCar : PassengerCar
{
    public bool IsofixMounts { get; set; }
    //DB

    public PrivatePassengerCar()
    {
        
    }
    public PrivatePassengerCar(bool isofixMount)
    {
        IsofixMounts = isofixMount;
    }

    public override string ToString()
    {
        return "";
    }
}
