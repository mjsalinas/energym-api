using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnergymApp.API.Domino.ModelosDB
{
    public partial class Clientes
    {
        public Clientes()
        {
            Pagos = new HashSet<Pagos>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string NumeroTelefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Correo { get; set; }
        public int TipoPlan { get; set; }
        public int IdGrupo { get; set; }
        public sbyte Activo { get; set; }
        public string EstadoCliente { get; set; }

        public virtual ModalidadGrupal IdGrupoNavigation { get; set; }
        public virtual ICollection<Pagos> Pagos { get; set; }
    }
}
