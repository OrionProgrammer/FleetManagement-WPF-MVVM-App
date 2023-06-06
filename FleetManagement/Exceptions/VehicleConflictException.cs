using FleetManagement.Models;
using System;
using System.Runtime.Serialization;

namespace FleetManagement.Exceptions;

public class VehicleConflictException : Exception
{
    public VehicleModel ExistingVehicle { get; }
    public VehicleModel NewVehicle { get; }

    public VehicleConflictException(VehicleModel existingVehicle, VehicleModel newVehicle)
    {
        ExistingVehicle = existingVehicle;
        NewVehicle = newVehicle;
    }

    public VehicleConflictException(string message, VehicleModel existingVehicle, VehicleModel newVehicle) : base(message)
    {
        ExistingVehicle = existingVehicle;
        NewVehicle = newVehicle;
    }

    public VehicleConflictException(string message, VehicleModel existingVehicle, VehicleModel newVehicle, Exception innerException) : base(message, innerException)
    {
        ExistingVehicle = existingVehicle;
        NewVehicle = newVehicle;
    }

    protected VehicleConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
