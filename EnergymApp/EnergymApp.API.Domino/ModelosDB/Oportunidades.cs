using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnergymApp.API.Domino.ModelosDB
{
    public partial class Oportunidades
    {
        public int IdOportunidad { get; set; }
        public string Oportunidad { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string TipoOportunidad { get; set; }
    }
}
