using EnergymApp.API.Aplicacion.DTOs.Configuraciones.OportunidadesDTO;
using EnergymApp.API.DTO.DTOs.Configuraciones.OportunidadesDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Configuraciones.Oportunidades
{
    public interface IOportunidadesAppService
    {
        public List<OportunidadesDTO> ObtenerOportunidades(ObtenerOportunidadesRequest Request);
        public OportunidadesDTO GuardarOportunidad(NuevaOportunidadRequest Request);
    }
}
