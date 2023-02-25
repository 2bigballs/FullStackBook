using Application.Interfaces;
using DataAccess.Reposetories;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DependencyInjection
    { 
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();  
            return services;
        }
    }
}
