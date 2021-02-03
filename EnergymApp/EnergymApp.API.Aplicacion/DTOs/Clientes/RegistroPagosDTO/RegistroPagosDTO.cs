using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Clientes.RegistroPagosDTO
{
    public class RegistroPagosDTO
    {
        public int IdRegistroPago { get; set; }
        public int IdPagos { get; set; }
        public int IdCliente { get; set; }
        public string EstadoDePago { get; set; }
        public DateTime FechaPago { get; set; }
        public string MensajeDeError { get; set; }








    }
}
