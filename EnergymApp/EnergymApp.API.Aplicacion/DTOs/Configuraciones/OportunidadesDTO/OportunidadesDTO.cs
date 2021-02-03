using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Configuraciones.OportunidadesDTO
{
   public class OportunidadesDTO
    {
        public int IdOportunidad { get; set; }
        public string Oportunidad { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string TipoOportunidad { get; set; }
        public string MensajeDeError { get; set; }

    }
}
