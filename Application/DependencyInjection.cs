using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using FluentValidation;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookService,BookService>();
            services.AddScoped<IReviewService,ReviewService>();
            services.AddScoped<IRatingService,RatingService>();
            services.AddValidatorsFromAssemblyContaining<BookValidator>(); 

            return services;
        }
    }
}
