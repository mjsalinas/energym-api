using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnergymApp.API.Domino.ModelosDB
{
    public partial class Pagos
    {
        public Pagos()
        {
            RegistroPagos = new HashSet<RegistroPagos>();
        }

        public int IdPagos { get; set; }
        public int IdCliente { get; set; }
        public string EstadoDePago { get; set; }
        public DateTime FechaMaximaPago { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual ICollection<RegistroPagos> RegistroPagos { get; set; }
    }
}
