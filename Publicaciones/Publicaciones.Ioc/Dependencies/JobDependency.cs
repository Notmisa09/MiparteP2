using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Application.Validations.ServicesValidations;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
    public static class JobDependency
    {
        public static void AddJobDependency(this IServiceCollection services)
        {
            services.AddScoped<IJobsRepository, JobsRepository>();
            services.AddTransient<JobValidations>();
            services.AddTransient<IJobsService, JobsService>();
        }
    }
}
