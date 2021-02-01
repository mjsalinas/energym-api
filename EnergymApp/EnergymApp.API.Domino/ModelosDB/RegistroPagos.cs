using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnergymApp.API.Domino.ModelosDB
{
    public partial class RegistroPagos
    {
        public int IdRegistroPagos { get; set; }
        public int IdPagos { get; set; }
        public int IdCliente { get; set; }
        public string EstadoDePago { get; set; }
        public DateTime FechaRealizacionPago { get; set; }

        public virtual Pagos IdPagosNavigation { get; set; }
    }
}
