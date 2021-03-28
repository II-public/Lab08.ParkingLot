using Lab08.ParkingLot.Data.Constants;
using Lab08.ParkingLot.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lab08.ParkingLot.Data.ContextFactories
{
    public class DbContextMigrationFactory : IDesignTimeDbContextFactory<ParkingLotDBContext>
    {
        public ParkingLotDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ParkingLotDBContext>();
            optionsBuilder.UseSqlServer(ConfigurationConstants.CreateMigrationConnectionString,
                                        o => o.EnableRetryOnFailure());

            return new ParkingLotDBContext(optionsBuilder.Options);
        }
    }
}
