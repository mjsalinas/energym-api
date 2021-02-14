using EnergymApp.API.Aplicacion.DTOs.Configuraciones.UnidadesMedida;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.UnidadesDeMedida
{
    public interface IUnidadesMedidaRepositorio
    {
        public List<UnidadesMedidaDTO> ObtenerUnidadesMedida();
        public UnidadesMedidaDTO GuardarUnidadMedida(UnidadesMedidaDTO unidadMedida);
        public UnidadesMedidaDTO ModificarUnidadMedida(UnidadesMedidaDTO unidadMedida);


    }
}
