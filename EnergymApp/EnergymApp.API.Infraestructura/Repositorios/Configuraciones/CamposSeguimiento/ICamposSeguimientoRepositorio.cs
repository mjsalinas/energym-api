using EnergymApp.API.Aplicacion.DTOs.Configuraciones.CamposSeguimiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.CamposSeguimiento
{
    public interface ICamposSeguimientoRepositorio
    {
        public List<CamposSeguimientoDTO> ObtenerCamposSeguimiento();
        public CamposSeguimientoDTO GuardarCamposSeguimiento(CamposSeguimientoDTO camposSeguimiento);
        public CamposSeguimientoDTO modificarCamposSeguimiento(CamposSeguimientoDTO camposSeguimiento);
    }
}
