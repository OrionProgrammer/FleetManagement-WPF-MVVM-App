using FleetManagement.Models;
using System;

namespace FleetManagement.ViewModels
{
    public class VehicleViewModel : ViewModelBase
    {
        private readonly VehicleModel _vehicleModel;

        public Guid Id => _vehicleModel.Id;
        public string Make => _vehicleModel.Make;
        public string Model => _vehicleModel.Model;

        public VehicleViewModel(VehicleModel vehicleModel)
        {
            _vehicleModel = vehicleModel;
        }
    }
}
