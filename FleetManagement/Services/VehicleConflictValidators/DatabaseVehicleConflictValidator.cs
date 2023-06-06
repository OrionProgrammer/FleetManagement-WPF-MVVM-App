using Microsoft.EntityFrameworkCore;
using FleetManagement.DbContexts;
using FleetManagement.DTOs;
using FleetManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.Services.VehicleConflictValidators;

public class DatabaseVehicleConflictValidator : IVehicleConflictValidator
{
    private readonly IFleetManagementDbContextFactory _dbContextFactory;

    public DatabaseVehicleConflictValidator(IFleetManagementDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<VehicleModel> GetConflictingVehicle(VehicleModel vehicleModel)
    {
        using (FleetManagementDbContext context = _dbContextFactory.CreateDbContext())
        {
            VehicleDTO vehicleDTO = await context.Vehicles
                .Where(v => v.Make.Equals(vehicleModel.Make))
                .Where(v => v.Model.Equals(vehicleModel.Model))
                .FirstOrDefaultAsync();

            if (vehicleDTO == null)
            {
                return null;
            }    

            return ToVehicle(vehicleDTO);
        }
    }

    private static VehicleModel ToVehicle(VehicleDTO dto)
    {
        return new VehicleModel(dto.Make, dto.Model);
    }
}
