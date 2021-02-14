using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.DTO.DTOs.Configuraciones.OportunidadesDTO
{
    public class ObtenerOportunidadesRequest
    {
    }

    public class ObtenerOportunidadesIdRequest
    {
        public int IdOportunidad { get; set; }
    }
    public class NuevaOportunidadRequest
    {
        public string Oportunidad { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string TipoOportunidad { get; set; }
    }
}
