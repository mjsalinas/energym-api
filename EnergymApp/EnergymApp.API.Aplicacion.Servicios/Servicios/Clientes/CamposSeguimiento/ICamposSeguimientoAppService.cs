using EnergymApp.API.Aplicacion.DTOs.Configuraciones.CamposSeguimiento;
using EnergymApp.API.DTO.DTOs.Configuraciones.CamposSeguimiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.CamposSeguimiento
{
    public interface ICamposSeguimientoAppService
    {
        public List<CamposSeguimientoDTO> ObtenerCamposSeguimiento(ObtenerCamposSeguimientoRequest request);
        public CamposSeguimientoDTO GuardarCamposSeguimiento(GuardarCamposSeguimientoRequest request);
        public CamposSeguimientoDTO ModificarCamposSeguimiento(ModificarCamposSeguimientoRequest request);

    }
}

