using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.DTO.DTOs.Configuraciones.CamposSeguimiento
{
    public class ObtenerCamposSeguimientoRequest
    {

    }
    public class GuardarCamposSeguimientoRequest
    {
        public int IdCampoSeguimiento { get; set; }
        public int IdUnidadMedida { get; set; }
        public string CampoSeguimiento1 { get; set; }
    }
    public class ModificarCamposSeguimientoRequest
    {

        public int IdCampoSeguimiento { get; set; }
        public int IdUnidadMedida { get; set; }
        public string CampoSeguimiento1 { get; set; }
    }

}



