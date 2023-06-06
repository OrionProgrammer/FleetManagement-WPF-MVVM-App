using Microsoft.EntityFrameworkCore;

namespace FleetManagement.DbContexts;

public class FleetManagementDbContextFactory : IFleetManagementDbContextFactory
{
    private readonly string _connectionString;

    public FleetManagementDbContextFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public FleetManagementDbContext CreateDbContext()
    {
        DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;

        return new FleetManagementDbContext(options);
    }
}
