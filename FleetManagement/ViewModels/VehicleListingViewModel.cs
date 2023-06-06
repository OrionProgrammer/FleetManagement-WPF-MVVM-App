using FleetManagement.Commands;
using FleetManagement.Commands.Vehicle;
using FleetManagement.Models;
using FleetManagement.Services;
using FleetManagement.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;


namespace FleetManagement.ViewModels
{
    public class VehicleListingViewModel : ViewModelBase
    {
        private readonly VehicleStore _vehicleStore;

        private readonly ObservableCollection<VehicleViewModel> _vehicleViewModels;

        public IEnumerable<VehicleViewModel> Vehicles => _vehicleViewModels;

        public bool HasVehicles => _vehicleViewModels.Any();

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));

                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand LoadVehiclesCommand { get; }
        public ICommand ManageVehiclesCommand { get; }

        public VehicleListingViewModel(VehicleStore vehicleStore, NavigationService<ManageVehicleViewModel> manageVehicleNavigationService)
        {
            _vehicleStore = vehicleStore;
            _vehicleViewModels = new ObservableCollection<VehicleViewModel>();

            LoadVehiclesCommand = new LoadVehiclesCommand(this, vehicleStore);
            ManageVehiclesCommand = new NavigateCommand<ManageVehicleViewModel>(manageVehicleNavigationService);

            _vehicleStore.VehicleAdded += OnVehicleAdded;
            _vehicleViewModels.CollectionChanged += OnReservationsChanged;
        }

        public override void Dispose()
        {
            _vehicleStore.VehicleAdded -= OnVehicleAdded;
            base.Dispose();
        }

        private void OnVehicleAdded(VehicleModel vehicleModel)
        {
            VehicleViewModel vehicleViewModel = new VehicleViewModel(vehicleModel);
            _vehicleViewModels.Add(vehicleViewModel);
        }

        public static VehicleListingViewModel LoadViewModel(VehicleStore vehicleStore, 
            NavigationService<ManageVehicleViewModel> manageVehicleNavaigationService)
        {
            VehicleListingViewModel viewModel = new VehicleListingViewModel(vehicleStore, manageVehicleNavaigationService);

            viewModel.LoadVehiclesCommand.Execute(null);

            return viewModel;
        }

        public void UpdateVehicles(IEnumerable<VehicleModel> vehicles)
        {
            vehicles = Enumerable.Empty<VehicleModel>();

            foreach (VehicleModel vehicleModel in vehicles)
            {
                VehicleViewModel vehicleViewModel = new(vehicleModel);

                _vehicleViewModels.Add(vehicleViewModel);
            }
        }

        private void OnReservationsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(HasVehicles));
        }
    }
}
