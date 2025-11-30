using Application.ProtectionPlusInsurance.Services.Implementations;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ProtectionPlusInsurance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAdjusterService, AdjusterService>();
            services.AddScoped<IClaimAdjusterService, ClaimAdjusterService>();
            services.AddScoped<IClaimPaymentService, ClaimPaymentService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<IPolicyHolderService, PolicyHolderService>();
            services.AddScoped<IPolicyService, PolicyService>();
            services.AddScoped<IPropertyService, PropertyService>();

            return services;
        }
    }
}
