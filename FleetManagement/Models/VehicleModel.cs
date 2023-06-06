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
    public VehicleModel (string make, string model) 
    {
        Make = make;
        Model = model;
    }

    public override string ToString()
    {
        return $"{Make} {Model}";
    }
}
