using Microsoft.EntityFrameworkCore;
using FleetManagement.DTOs;

namespace FleetManagement.DbContexts;

public class FleetManagementDbContext : DbContext
{
    public FleetManagementDbContext(DbContextOptions options) : base(options) { }

    public DbSet<VehicleDTO> Vehicles { get; set; }
}
