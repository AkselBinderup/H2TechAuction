﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.VehicleModels;

public abstract class PassengerCar : Vehicle
{
    public int SeatCapacity { get; set; }
    public int TrunkLength { get; set; }
    public int TrunkWidth { get; set; }
    public int TrunkHeight { get; set; }
    public int TrunkDimensions { get; set; }
    public bool RequireCommercialLicense { get; set; }

    public PassengerCar()
    {
        TrunkLength = 1;
        TrunkWidth = 1;
        TrunkHeight = 1;
        GetDimensions();
    }
    public LicenseType GetLicenseType()
    {
        if (RequireCommercialLicense)
            return LicenseType.BE;
        else
            return LicenseType.B;
    }
    public double GetEngineSize()
    {
        if (EngineSize >= 0.7 && EngineSize <= 10)
            return EngineSize;
        else 
            throw new ArgumentOutOfRangeException
                (EngineSize.ToString(), "Engine size needs to be between 0.7 and 10 litres...");
    }
    public int GetDimensions()
    {
        return (TrunkLength*TrunkWidth*TrunkHeight)/1000;
    }



}
