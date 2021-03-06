using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.DTO.DTOs.Grupos.ModalidadGrupalDTO
{
    public class ModalidadGrupalRequest
    {
        public class ObtenerGruposRequest
        {

        }

        public class ObtenerGrupoIdRequest
        {
            public int IdGrupo { get; set; }
        }

        public class NuevoGrupoRequest
        {
            public int IdPlan { get; set; }
            public int LiderGrupo { get; set; }
            public sbyte GrupoActivo { get; set; }
        }
        public class ModificarGrupoRequest
        {
            public int IdPlan { get; set; }
            public int LiderGrupo { get; set; }
            public sbyte GrupoActivo { get; set; }
        }
    }
}
