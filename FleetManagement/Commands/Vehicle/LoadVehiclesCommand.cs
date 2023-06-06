using FleetManagement.Models;
using FleetManagement.Stores;
using FleetManagement.ViewModels;
using System;
using System.Threading.Tasks;

namespace FleetManagement.Commands.Vehicle;

public class LoadVehiclesCommand : AsyncCommandBase
{
    private readonly VehicleListingViewModel _viewModel;
    private readonly VehicleStore _vehicleStore;

    public LoadVehiclesCommand(VehicleListingViewModel viewModel, VehicleStore vehicleStore)
    {
        _viewModel = viewModel;
        _vehicleStore = vehicleStore;
    }

    public override async Task ExecuteAsync(object parameter)
    {
        _viewModel.ErrorMessage = string.Empty;
        _viewModel.IsLoading = true;

        try
        {
            await _vehicleStore.Load();

            _viewModel.UpdateVehicles(_vehicleStore.VehicleModels);
        }
        catch (Exception)
        {
            _viewModel.ErrorMessage = "Failed to load vehicles.";
        }

        _viewModel.IsLoading = false;
    }
}
