using System;
using AutoMapper;
using LibraryApp.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Web.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(m => m.AddProfiles(new Profile[]
            {
                new BookLoanMap(),
                new BookMap()
            }));
        }
    }
}