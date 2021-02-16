using LibraryApp.Application.Interfaces;
using LibraryApp.Application.Services;
using LibraryApp.Data.Connection;
using LibraryApp.Data.Repository;
using LibraryApp.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.IoC
{
    public class DependencyInjectionBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookAppService, BookAppService>();
            services.AddScoped<IBookLoanAppService, BookLoanAppService>();
            services.AddScoped<Database>();
        }
    }
}