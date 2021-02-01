using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Configuraciones.CamposSeguimiento
{
    public class CamposSeguimientoDTO
    {
        public int IdCampoSeguimiento { get; set; }
        public int IdUnidadMedida { get; set; }
        public string CampoSeguimiento1 { get; set; }
        public sbyte? RegistroOculto { get; set; }
        public string MensajeDeError { get; set; }

    }
}
