﻿namespace H2TechAuction.Models.VehicleModels;
public class PrivatePassengerCar : PassengerCar
{
    public bool IsofixMount { get; set; }
    //DB

    public PrivatePassengerCar(bool isofixMount)
    {
        IsofixMount = isofixMount;
    }

    public override string ToString()
    {
        return "";
    }
}
