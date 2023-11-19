namespace Transaction.Framework.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Transaction.Framework.Data;
    using Transaction.Framework.Services;
    using Transaction.Framework.Services.Interface;
    using Transaction.Framework.Mappers;
    using AutoMapper;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTransactionFramework(this IServiceCollection services, IConfiguration configuration)
        {
            // Service
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ICBService, CBService>();

            // Mappers
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            // Connection String
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            return services;
        }
    }
}
