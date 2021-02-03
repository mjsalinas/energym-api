using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Configuraciones.ModalidadGrual
{
    public class ModalidadGrupalDTO
    {
        public int IdGrupo { get; set; }
        public int IdPlan { get; set; }
        public int LiderDeGrupo { get; set; }
        public bool GrupoActivo { get; set; }
        public string MensajeDeError { get; set; }

    }
}
