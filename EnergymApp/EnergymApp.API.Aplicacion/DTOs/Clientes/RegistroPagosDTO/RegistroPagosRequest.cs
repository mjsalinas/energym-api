using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.DTO.DTOs.Clientes.RegistroPagosDTO
{
    public class ObtenerRegistroPagosRequest
    {
    }

    public class ObtenerRegistroPagosIdRequest
    {
        public int IdRegistroPagos { get; set; }
    }

    public class NuevoRegistroPagosRequest
    {
    public int IdPagos { get; set; }
    public int IdCliente { get; set; }
    public string EstadoDePago { get; set; }
    public DateTime FechaRealizacionPago { get; set; }
}

    public class ModificarRegistroPagosRequest
    {
        public int IdRegistroPagos { get; set; }
        public int IdPagos { get; set; }
        public int IdCliente { get; set; }
        public string EstadoDePago { get; set; }
        public DateTime FechaRealizacionPago { get; set; }
    }
   



}
