using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NtierArchitecture.DataAccess.Context;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;
using Scrutor;

namespace NtierArchitecture.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(
            this IServiceCollection services,
            IConfiguration configuration)
        {                     //DB CONTEXT BAĞLANTI YERİ
            string connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.AddIdentityCore<AppUser>(cfr =>        ///IDENTİTY KÜTÜPHANESİ
            {
                cfr.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUnitOfWork>(sv => sv.GetRequiredService<ApplicationDbContext>());  //UNITOFWORK VE DEPENDENCY INJECTION

            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.Scan(selector => selector
            .FromAssemblies(
                typeof(DependencyInjection).Assembly)
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime());

            return services;
        }
    }
}
