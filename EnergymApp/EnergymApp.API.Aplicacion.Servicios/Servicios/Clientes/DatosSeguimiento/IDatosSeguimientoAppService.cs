using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Aplicacion.DTOs.Clientes.DatosSeguimiento;
using EnergymApp.API.DTO.DTOs.Clientes.DatosSeguimiento;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.DatosSeguimiento
{
   public interface IDatosSeguimientoAppService
    {

        public List<DatosSeguimientoDTO> ObtenerDatoSeguimiento(ObtenerDatosSeguimientoRequest request);
        public DatosSeguimientoDTO CrearNuevoDatoSeguimiento(NuevoDatosSeguimientoRequest request);

        public DatosSeguimientoDTO ModificarDatoSeguimiento(ModificarDatosSeguimientoRequest request);
    }
}
