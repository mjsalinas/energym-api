using EnergymApp.API.Aplicacion.DTOs.Configuraciones.OportunidadesDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.OportunidadesRepo
{
    public interface IOportunidadesRepositorio
    {
        public List<OportunidadesDTO> ObtenerOportunidades();
        public OportunidadesDTO GuardarOportunidad(OportunidadesDTO oportunidad);

    }
}
