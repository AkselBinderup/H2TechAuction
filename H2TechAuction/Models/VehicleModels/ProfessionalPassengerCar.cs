using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.VehicleModels;

public class ProfessionalPassengerCar : PassengerCar
{
    public bool SafetyBarCar { get; set; }
    public int Capacity { get; set; }
    //db
    public override string ToString()
    {
        return base.ToString();
    }

}
