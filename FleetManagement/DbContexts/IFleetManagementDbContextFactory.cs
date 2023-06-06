namespace FleetManagement.DbContexts;

public interface IFleetManagementDbContextFactory
{
    FleetManagementDbContext CreateDbContext();
}