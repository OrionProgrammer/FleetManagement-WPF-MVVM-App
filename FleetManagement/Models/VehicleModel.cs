using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Models;

public class VehicleModel
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Status { get; set; }

    public VehicleModel (string make, string model, int status) 
    {
        Make = make;
        Model = model;
        Status = status;
    }

    public override string ToString()
    {
        return $"{Make} {Model}";
    }
}
