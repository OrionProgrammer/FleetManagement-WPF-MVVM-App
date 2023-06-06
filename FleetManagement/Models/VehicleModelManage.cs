using System.Collections.Generic;
using System.Threading.Tasks;
using FleetManagement.Exceptions;
using FleetManagement.Services.VehicleConflictValidators;
using FleetManagement.Services.VehicleCreators;
using FleetManagement.Services.VehicleProviders;

namespace FleetManagement.Models;

public class VehicleModelManage
{
    private readonly IVehicleProvider _vehicleProvider;
    private readonly IVehicleCreator _vehicleCreator;
    private readonly IVehicleConflictValidator _vehicleConflictValidator;
    public VehicleModelManage(IVehicleProvider vehicleProvider,
                        IVehicleCreator vehicleCreator,
                        IVehicleConflictValidator vehicleConflictValidator)
    {
        _vehicleProvider = vehicleProvider;
        _vehicleCreator = vehicleCreator;
        _vehicleConflictValidator = vehicleConflictValidator;
    }

    public async Task<IEnumerable<VehicleModel>> GetAllVehicles()
    {
        return await _vehicleProvider.GetAllVehicles();
    }

    public async Task AddVehicle(VehicleModel vehicleModel)
    {
        //check if vechicle with same make and model exists, if true, then throw conflict error
        VehicleModel conflictingVehicle = await _vehicleConflictValidator.GetConflictingVehicle(vehicleModel);

        if (conflictingVehicle != null)
        {
            throw new VehicleConflictException(conflictingVehicle, vehicleModel);
        }

        await _vehicleCreator.CreateVehicle(vehicleModel);
    }
}
