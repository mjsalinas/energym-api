using EnergymApp.API.Aplicacion.DTOs.Configuraciones.TipoPlanes;
using EnergymApp.API.DTO.DTOs.Configuraciones.TipoPlanes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.TiposDePlanes
{
    public interface ITipoPlanesAppService
    {
        public List<TipoPlanesDTO> ObtenerTipoPlanes(ObtenerTipoPlanesRequest request);
        public TipoPlanesDTO ObtenerTipoPlanId(ObtenerIdTipoPlanesRequest request);
        public TipoPlanesDTO GuardarTipoPlan(NuevoTipoPlanRequest request);
        public TipoPlanesDTO ModificarTipoPlan(ModificarTipoPlanRequest request);
    }
}
