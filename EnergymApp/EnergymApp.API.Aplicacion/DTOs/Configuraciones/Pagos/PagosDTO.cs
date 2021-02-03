using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Configuraciones.Pagos
{
    public class PagosDTO
    {
        public int IdPago { get; set; }
        public int IdCliente { get; set; }
        public string EstadoDePago { get; set; }
        public DateTime FechaDeMaximaDePago{ get; set; }
        public string MensajeDeError { get; set; }

    }
}
