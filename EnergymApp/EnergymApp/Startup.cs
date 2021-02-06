using EnergymApp.API.Aplicacion.Servicios.Clientes.Clientes;
using EnergymApp.API.Infraestructura.Repositorios.Cliente.Cliente;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.ModalidadGrupalRepo;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.TipoPlanes;
using EnergymApp.API.Infraestructura.Repositorios.Grupos.ModalidadGrupalRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergymApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IClientesAppService, ClientesAppService>();
            services.AddTransient<IClientesRepositorio, ClientesRepositorio>();
            services.AddTransient<ITipoPlanesRepositorio, TipoPlanesRepositorio>();
            services.AddTransient<IModalidadGrupalRepositorio, ModalidadGrupalRepositorio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
