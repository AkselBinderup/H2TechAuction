using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.VehicleModels;

public class HeavyVehicle : Vehicle
{
    public double GetEngineSize()
    {
        if (EngineSize >= 4.2 && EngineSize <= 15.0)
            return EngineSize;

        throw new ArgumentOutOfRangeException(EngineSize.ToString(), "Engine size needs to be between 4.2 and 15.0 lites...");
    }

    //    Lav en klassen imellem Bus/Lastbil og køretøj, 
    //som sammensætter de værdier som Bus og
    //Lastbil deler.
    //    Høj Domæne
    //Model
    //V6 Køretøj.TungKør
    //etøj
    //Redefinere objekt klassens ToString() for 
    //TungKøretøj


}
