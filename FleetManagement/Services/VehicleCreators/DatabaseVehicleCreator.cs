using FleetManagement.DbContexts;
using FleetManagement.DTOs;
using FleetManagement.Models;
using System.Threading.Tasks;

namespace FleetManagement.Services.VehicleCreators;

public class DatabaseVehicleCreator : IVehicleCreator
{
    private readonly IFleetManagementDbContextFactory _dbContextFactory;

    public DatabaseVehicleCreator(IFleetManagementDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task CreateVehicle(VehicleModel vehicleModel)
    {
        using (FleetManagementDbContext context = _dbContextFactory.CreateDbContext())
        {
            VehicleDTO vehicleDTO = ToVehicleDTO(vehicleModel);

            context.Vehicles.Add(vehicleDTO);
            await context.SaveChangesAsync();
        }
    }

    private VehicleDTO ToVehicleDTO(VehicleModel vehicleModel)
    {
        return new VehicleDTO()
        {
            Make = vehicleModel.Make,
            Model = vehicleModel.Model,
            Status = vehicleModel.Status
        };
    }
}
