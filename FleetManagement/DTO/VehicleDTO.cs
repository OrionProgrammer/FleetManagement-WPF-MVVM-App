using System;
using System.ComponentModel.DataAnnotations;
using System.Security.RightsManagement;

namespace FleetManagement.DTOs;

public class VehicleDTO
{
    [Key]
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Status { get; set; }
}
