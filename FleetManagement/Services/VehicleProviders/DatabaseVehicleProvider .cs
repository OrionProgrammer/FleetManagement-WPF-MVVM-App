using Microsoft.EntityFrameworkCore;
using FleetManagement.DbContexts;
using FleetManagement.DTOs;
using FleetManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.Services.VehicleProviders;

public class DatabaseVehicleProvider : IVehicleProvider
{
    private readonly IFleetManagementDbContextFactory _dbContextFactory;

    public DatabaseVehicleProvider(IFleetManagementDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<VehicleModel>> GetAllVehicles()
    {
        using (FleetManagementDbContext context = _dbContextFactory.CreateDbContext())
        {
            IEnumerable<VehicleDTO> vehicleDTOs = await context.Vehicles.ToListAsync();

            return vehicleDTOs.Select(r => ToVehicle(r));
        }
    }

    private static VehicleModel ToVehicle(VehicleDTO dto)
    {
        return new VehicleModel(dto.Make, dto.Model);
    }
}
