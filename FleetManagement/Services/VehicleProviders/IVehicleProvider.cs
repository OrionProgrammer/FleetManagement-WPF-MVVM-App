using FleetManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.Services.VehicleProviders;

public interface IVehicleProvider
{
    Task<IEnumerable<VehicleModel>> GetAllVehicles();
}
