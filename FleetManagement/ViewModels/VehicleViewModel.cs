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
        public int Status => _vehicleModel.Status;

        public VehicleViewModel(VehicleModel vehicleModel)
        {
            _vehicleModel = vehicleModel;
        }
    }
}
