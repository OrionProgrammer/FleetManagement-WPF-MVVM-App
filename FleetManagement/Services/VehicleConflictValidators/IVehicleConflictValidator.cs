using FleetManagement.Models;
using System.Threading.Tasks;

namespace FleetManagement.Services.VehicleConflictValidators;

public interface IVehicleConflictValidator
{
    Task<VehicleModel> GetConflictingVehicle(VehicleModel vehicleModel);
}
