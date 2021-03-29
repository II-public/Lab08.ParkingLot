using Lab08.ParkingLot.Data.Context;
using Lab08.ParkingLot.Repository;
using Lab08.ParkingLot.Repository.Interfaces;
using Lab08.ParkingLot.Service.Calculators;
using Lab08.ParkingLot.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lab08.ParkingLot.Service
{
    public static class ServiceExtension
    {
        public static void ConfigureDBContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ParkingLotDBContext>(o => o.UseSqlServer(connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .EnableSensitiveDataLogging());
        }

        /// <summary>
        /// Configures the repository wrapper.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<ILab08ParkingLotUnitOfWork, Lab08ParkingLotUnitOfWork>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculatorFactory, CalculatorFactory>();
            services.AddTransient<IRegisterService, RegisterService>();
        }
    }
}
