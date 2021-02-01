using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnergymApp.API.Domino.ModelosDB
{
    public partial class ModalidadGrupal
    {
        public ModalidadGrupal()
        {
            Clientes = new HashSet<Clientes>();
        }

        public int IdGrupo { get; set; }
        public int IdPlan { get; set; }
        public int LiderGrupo { get; set; }
        public sbyte GrupoActivo { get; set; }
        public string ModalidadGrupalcol { get; set; }

        public virtual TipoDePlan IdPlanNavigation { get; set; }
        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
