using EnergymApp.API.Aplicacion.DTOs.Configuraciones.UnidadesMedida;
using EnergymApp.API.DTO.DTOs.Configuraciones.UnidadesMedida;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Configuraciones.UnidadesMedida
{
    public interface IUnidadesMedidaAppService
    {
        public List<UnidadesMedidaDTO> ObtenerUnidadesMedida(ObtenerUnidadesMedidaRequest request);
        public UnidadesMedidaDTO CrearNuevaUnidadMedida(NuevaUnidadMedidadRequest request);
        public UnidadesMedidaDTO ModificarUnidadMedida(ModificarUnidadMedidadRequest request);

    }
}
