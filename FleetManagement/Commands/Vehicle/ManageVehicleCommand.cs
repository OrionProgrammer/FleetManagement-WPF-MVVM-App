using FleetManagement.Exceptions;
using FleetManagement.Models;
using FleetManagement.Services;
using FleetManagement.Stores;
using FleetManagement.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace FleetManagement.Commands.Vehicle;

public class ManageVehicleCommand : AsyncCommandBase
{
    private readonly ManageVehicleViewModel _manageVehicleViewModel;
    private readonly VehicleStore _vehicleStore;
    private readonly NavigationService<VehicleListingViewModel> _vehicleViewNavigationService;

    public ManageVehicleCommand(ManageVehicleViewModel manageVehicleViewModel,
        VehicleStore vehicleStore,
        NavigationService<VehicleListingViewModel> vehicleViewNavigationService)
    {
        _manageVehicleViewModel = manageVehicleViewModel;
        _vehicleStore = vehicleStore;
        _vehicleViewNavigationService = vehicleViewNavigationService;

        _manageVehicleViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    public override bool CanExecute(object parameter)
    {
        return _manageVehicleViewModel.CanCreateVehicle && base.CanExecute(parameter);
    }

    public override async Task ExecuteAsync(object parameter)
    {
        _manageVehicleViewModel.SubmitErrorMessage = string.Empty;
        _manageVehicleViewModel.IsSubmitting = true;

        VehicleModel vehicleModel = new VehicleModel(
            _manageVehicleViewModel.Make,
            _manageVehicleViewModel.Model);

        try
        {
            await _vehicleStore.AddVehicle(vehicleModel);

            MessageBox.Show("Successfully added vehicle.", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);

            _vehicleViewNavigationService.Navigate();
        }
        catch (VehicleConflictException)
        {
            _manageVehicleViewModel.SubmitErrorMessage = "This vehicle already exists. Please change the Make or Model.";
        }
        catch (Exception)
        {
            _manageVehicleViewModel.SubmitErrorMessage = "Failed to add vehicle.";
        }

        _manageVehicleViewModel.IsSubmitting = false;
    }

    private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if(e.PropertyName == nameof(ManageVehicleViewModel.CanCreateVehicle))
        {
            OnCanExecutedChanged();
        }
    }
}
