using Lab08.ParkingLot.Data.Configurations;
using Lab08.ParkingLot.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lab08.ParkingLot.Data.Context
{
    public class ParkingLotDBContext : DbContext
    {
        public ParkingLotDBContext(DbContextOptions<ParkingLotDBContext> options)
         : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // db sets here
        DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // apply configurations here
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        }
    }
}
