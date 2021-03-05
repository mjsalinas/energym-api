using EnergymApp.API.Aplicacion.Servicios.Clientes.Clientes;
using EnergymApp.API.Infraestructura.Repositorios.Cliente.Cliente;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.ModalidadGrupalRepo;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.TipoPlanes;
using EnergymApp.API.Infraestructura.Repositorios.Grupos.ModalidadGrupalRepo;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.CamposSeguimiento;
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
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.CamposSeguimiento;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Configuraciones.Oportunidades;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.TiposDePlanes;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.OportunidadesRepo;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Configuraciones.UnidadesMedida;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.UnidadesDeMedida;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.DatosSeguimiento;
using EnergymApp.API.Infraestructura.Repositorios.Cliente.DatosSeguimientoRepositorio;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.RegistroPagosServicios;
using EnergymApp.API.Infraestructura.Repositorios.Cliente.RegistroPagosRepositorio;

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

            services.AddTransient<ITipoPlanesAppService, TipoPlanesAppService>();
            services.AddTransient<ITipoPlanesRepositorio, TipoPlanesRepositorio>();


            services.AddTransient<IOportunidadesAppService, OportunidadesAppService>();
            services.AddTransient<IOportunidadesRepositorio, OportunidadesRepositorio>();

            services.AddTransient<ICamposSeguimientoRepositorio, CamposSeguimientoRepositorio>();
            services.AddTransient<ICamposSeguimientoAppService, CamposSeguimientoAppService>();

            services.AddTransient<IModalidadGrupalRepositorio, ModalidadGrupalRepositorio>();
            
            services.AddTransient<IUnidadesMedidaAppService, UnidadesMedidaAppService>();
            services.AddTransient<IUnidadesMedidaRepositorio, UnidadesMedidaRepositorio>();
            
            services.AddTransient<IDatosSeguimientoAppService, DatosSeguimientoAppService>();
            services.AddTransient<IDatosSeguimientoRepositorio, DatosSeguimientoRepositorio>();
            
            services.AddTransient<IRegistroPagosAppService, RegistroPagosAppService>();
            services.AddTransient<IRegistroPagosRepositorio, RegistroPagosRepositorio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }
            app.UseDeveloperExceptionPage();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
