using FleetManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.Stores;

public class VehicleStore
{
    private readonly VehicleModelManage _vehicleModelManage; //store

    private readonly List<VehicleModel> _vehicleModels;
    private Lazy<Task> _initializeLazy;

    public IEnumerable<VehicleModel> VehicleModels => _vehicleModels;

    public event Action<VehicleModel> VehicleAdded;

    public VehicleStore(VehicleModelManage vehicleModelManage)
    {
        _vehicleModelManage = vehicleModelManage;
        _initializeLazy = new Lazy<Task>(Initialize);

        _vehicleModels = new List<VehicleModel>();
    }

    public async Task Load()
    {
        try
        {
            await _initializeLazy.Value;
        }
        catch (Exception)
        {
            _initializeLazy = new Lazy<Task>(Initialize);
            throw;
        }
    }

    public async Task AddVehicle(VehicleModel vehicleModel)
    {
        await _vehicleModelManage.AddVehicle(vehicleModel);

        _vehicleModels.Add(vehicleModel);

        OnReservationMade(vehicleModel);
    }

    private void OnReservationMade(VehicleModel vehicleModel)
    {
        VehicleAdded?.Invoke(vehicleModel);
    }

    private async Task Initialize()
    {
        IEnumerable<VehicleModel> vehicles = await _vehicleModelManage.GetAllVehicles();

        _vehicleModels.Clear();
        _vehicleModels.AddRange(vehicles);
    }
}
