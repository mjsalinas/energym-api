using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnergymApp.API.Domino.ModelosDB
{
    public partial class DatosSeguimiento
    {
        public int IdCamposSeguimiento { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string DatoSeguimiento { get; set; }
    }
}
