using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.DTO.DTOs.Clientes.DatosSeguimiento
{
    public class ObtenerDatosSeguimientoRequest
    {


    }

    public class ObtenerDatosSeguimientoIdRequest
    {
        public int IdCamposSeguimiento { get; set; }
    }

    public class NuevoDatosSeguimientoRequest
    {
        
        public int IdCliente { get; set; }
        public string DatoSeguimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class ModificarDatosSeguimientoRequest
    {
        public int IdCliente { get; set; }
        public string DatoSeguimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
