using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Configuraciones.ModalidadGrupal
{
    public class ModalidadGrupalDTO
    {
        public int IdGrupo { get; set; }
        public int IdPlan { get; set; }
        public int LiderDeGrupo { get; set; }
        public sbyte GrupoActivo { get; set; }
        public string MensajeDeError { get; set; }

    }
}
