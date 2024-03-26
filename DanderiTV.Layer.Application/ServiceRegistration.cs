using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Repositories;
using DanderiTV.Layer.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DanderiTV.Layer.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {

            #region Repository Injection

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddTransient<ISerieRepository, SerieRepository>();

            #endregion

            #region Services Injection
            //services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<ISerieServices, SerieService>();
            #endregion

        }
    }
}
