using FleetManagement.Models;
using System.Threading.Tasks;

namespace FleetManagement.Services.VehicleCreators;

public interface IVehicleCreator
{
    Task CreateVehicle(VehicleModel vehicleModel);
}
