using Lab08.ParkingLot.Data.ConfigurationHelpers;
using Lab08.ParkingLot.Data.Constants;
using Lab08.ParkingLot.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab08.ParkingLot.Data.Configurations
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> entityBuilder)
        {
            entityBuilder.ToTable(TablesConstants.Vehicle, ConfigurationConstants.SchemaName);

            entityBuilder
                .HasKey(e => new { e.VehicleId })
                .HasName(ConstraintNameBuilder.GetPrimaryName(
                    nameof(Vehicle),
                    nameof(Vehicle.VehicleId)));

            entityBuilder.HasIndex(e => e.Number);
        }
    }
}
