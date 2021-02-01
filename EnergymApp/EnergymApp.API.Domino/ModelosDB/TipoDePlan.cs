using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnergymApp.API.Domino.ModelosDB
{
    public partial class TipoDePlan
    {
        public TipoDePlan()
        {
            ModalidadGrupal = new HashSet<ModalidadGrupal>();
        }

        public int IdPlan { get; set; }
        public string NombrePlan { get; set; }
        public int NoIntegrantes { get; set; }
        public decimal CostoPlan { get; set; }
        public sbyte RegistroOculto { get; set; }

        public virtual ICollection<ModalidadGrupal> ModalidadGrupal { get; set; }
    }
}
