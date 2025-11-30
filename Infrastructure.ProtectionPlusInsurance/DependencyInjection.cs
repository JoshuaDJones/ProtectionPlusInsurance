using Core.ProtectionPlusInsurance.Interfaces;
using Infrastructure.ProtectionPlusInsurance.Database;
using Infrastructure.ProtectionPlusInsurance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ProtectionPlusInsurance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<DatabaseInitializer>();
            services.AddScoped<ISqlExecutor, SqlExecutor>();
            services.AddScoped<IAdjusterRepository, AdjusterRepository>();
            services.AddScoped<IClaimAdjusterRepository, ClaimAdjusterRepository>();
            services.AddScoped<IClaimPaymentRepository, ClaimPaymentRepository>();
            services.AddScoped<IClaimStatusRepository, ClaimStatusRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IIncidentRepository, IncidentRepository>();
            services.AddScoped<IPolicyHolderRepository, PolicyHolderRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();            
            services.AddScoped<IIncidentTypeRepository, IncidentTypeRepository>();
            services.AddScoped<IPolicyStatusRepository, PolicyStatusRepository>();

            return services;
        }
    }
}
