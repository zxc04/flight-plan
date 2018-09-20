using FlightPlan.Application.Repositories;
using FlightPlan.Sql.Entities;
using FlightPlan.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlan.Ioc
{
    public static class Bootstrap
    {
        public static void ConfigureIoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseContext")));

            services.AddTransient<IPlaneRepository, PlaneRepository>();
            services.AddTransient<IAirportRepository, AirportRepository>();
        }
    }
}
