using EnergymApp.API.Aplicacion.DTOs.Configuraciones.ModalidadGrupal;
using System;
using System.Collections.Generic;
using System.Text;
using static EnergymApp.API.DTO.DTOs.Grupos.ModalidadGrupalDTO.ModalidadGrupalRequest;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Grupos
{
    public interface IModalidadGrupalAppService
    {
        public List<ModalidadGrupalDTO> ObtenerModalidadGrupal(ObtenerGruposRequest request);
        public ModalidadGrupalDTO CrearNuevoGrupo(NuevoGrupoRequest request);
        public ModalidadGrupalDTO ModificarModalidadGrupal(ModificarGrupoRequest request);
    }
}
