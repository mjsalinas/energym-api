using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Clientes.DatosSeguimiento
{
    public class DatosSeguimientoDTO
    {
        public int IdCampoSeguimiento { get; set; }
        public int IdCliente { get; set; }
        public string DatoSeguimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string MensajeDeError { get; set; }
        
    }
}
