using Application;
using DataAccess;
using Mapster;
using MapsterMapper;
using System.Reflection;
using Application.Configuration;
using Application.Helpers.Paths;
using Application.Helpers.Url;
using Infrastructure;

namespace BookApi
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.Configure<SecretCode>(configuration.GetSection("SecretCode"));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDataAccess(configuration);
            services.AddApplication(configuration);
            services.AddMapsterConfiguration();
            services.AddInfrastructure(configuration);
            services.AddScoped<DirectoryPath>();
            services.AddScoped<UrlManager>();
            services.AddHttpContextAccessor();
            services.AddFrontendConfiguration(configuration);
            return services;
        }
        private static IServiceCollection AddMapsterConfiguration(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
            return services;
        }

        private static IServiceCollection AddFrontendConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddCors();
            try
            {
                services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = Path.Combine("ClientApp", "dist", "library");
                });
            }
            catch (Exception e)
            {
            }
          
            return services;
        }

    }
    
}
