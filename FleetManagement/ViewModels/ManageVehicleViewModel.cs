using FleetManagement.Commands;
using FleetManagement.Commands.Vehicle;
using FleetManagement.Models;
using FleetManagement.Services;
using FleetManagement.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FleetManagement.ViewModels;

public class ManageVehicleViewModel : ViewModelBase, INotifyDataErrorInfo
{
    private string _make;
    public string Make
    {
        get
        {
            return _make;
        }
        set
        {
            _make = value;
            OnPropertyChanged(nameof(Make));

            ClearErrors(nameof(Make));

            if(!HasMake)
            {
                AddError("Make cannot be empty.", nameof(Make));
            }

            OnPropertyChanged(nameof(CanCreateVehicle));
        }
    }

    private string _model;
    public string Model
    {
        get
        {
            return _model;
        }
        set
        {
            _model = value;
            OnPropertyChanged(nameof(Model));

            ClearErrors(nameof(Model));

            if (!HasModel)
            {
                AddError("Model cannot be empty.", nameof(Model));
            }

            OnPropertyChanged(nameof(CanCreateVehicle));
        }
    }

    private int _status;
    public int Status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
            OnPropertyChanged(nameof(Status));

            ClearErrors(nameof(Status));

            if (!HasStatus)
            {
                AddError("Please select a status.", nameof(Status));
            }

            OnPropertyChanged(nameof(CanCreateVehicle));
        }
    }

    public bool CanCreateVehicle =>
        HasMake&&
        HasModel&&
        !HasErrors;

    private bool HasMake => !string.IsNullOrEmpty(Make);
    private bool HasModel => !string.IsNullOrEmpty(Model);
    private bool HasStatus => Status != 0;

    private string _submitErrorMessage;
    public string SubmitErrorMessage
    {
        get
        {
            return _submitErrorMessage;
        }
        set
        {
            _submitErrorMessage = value;
            OnPropertyChanged(nameof(SubmitErrorMessage));

            OnPropertyChanged(nameof(HasSubmitErrorMessage));
        }
    }

    public bool HasSubmitErrorMessage => !string.IsNullOrEmpty(SubmitErrorMessage);

    private bool _isSubmitting;
    public bool IsSubmitting
    {
        get
        {
            return _isSubmitting;
        }
        set
        {
            _isSubmitting = value;
            OnPropertyChanged(nameof(IsSubmitting));
        }
    }

    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

    public bool HasErrors => _propertyNameToErrorsDictionary.Any();

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    public ManageVehicleViewModel(VehicleStore vehicleStore, 
        NavigationService<VehicleListingViewModel> vehicleViewNavigationService)
    {
        SubmitCommand = new ManageVehicleCommand(this, vehicleStore, vehicleViewNavigationService);
        CancelCommand = new NavigateCommand<VehicleListingViewModel>(vehicleViewNavigationService);

        _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
    }

    public IEnumerable GetErrors(string propertyName)
    {
        return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
    }

    private void AddError(string errorMessage, string propertyName)
    {
        if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
        {
            _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
        }

        _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);

        OnErrorsChanged(propertyName);
    }

    private void ClearErrors(string propertyName)
    {
        _propertyNameToErrorsDictionary.Remove(propertyName);

        OnErrorsChanged(propertyName);
    }

    private void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}
