using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExamenDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Examen")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<ITiendaRepository, TiendaRepository>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();  

            return services;
        }
    }
}
