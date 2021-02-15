using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Aplicacion.DTOs.Clientes.DatosSeguimiento;

namespace EnergymApp.API.Infraestructura.Repositorios.Cliente.DatosSeguimientoRepositorio
{
    public interface IDatosSeguimientoRepositorio
    {
        public List<DatosSeguimientoDTO> ObtenerDatosSegumiento();
        public DatosSeguimientoDTO GuardarDatosSeguimiento(DatosSeguimientoDTO datosSeguimiento);
        public DatosSeguimientoDTO ModificarDatosSeguimiento(DatosSeguimientoDTO datosSeguimiento);

    }
}