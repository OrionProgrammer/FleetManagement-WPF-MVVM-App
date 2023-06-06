using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FleetManagement.DbContexts;

public class FleetManagementDesignTimeDbContextFactory : IDesignTimeDbContextFactory<FleetManagementDbContext>
{
    public FleetManagementDbContext CreateDbContext(string[] args)
    {
        string connectionString = null;
        
        try
        {
            connectionString = args[0];
        }
        catch
        {
            //get connection string from appSettings.json
            connectionString = args[0];
        }
        

        DbContextOptions options = new DbContextOptionsBuilder()
            .UseSqlServer(connectionString).Options;

        return new FleetManagementDbContext(options);
    }
}
