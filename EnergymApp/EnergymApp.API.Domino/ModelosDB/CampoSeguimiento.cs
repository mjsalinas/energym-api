using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnergymApp.API.Domino.ModelosDB
{
    public partial class CampoSeguimiento
    {
        public int IdCampoSeguimiento { get; set; }
        public int IdUnidadMedida { get; set; }
        public string CampoSeguimiento1 { get; set; }
        public sbyte? RegistroOculto { get; set; }
    }
}
