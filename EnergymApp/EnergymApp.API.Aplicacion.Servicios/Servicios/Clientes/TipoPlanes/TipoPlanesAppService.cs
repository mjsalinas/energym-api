using EnergymApp.API.Aplicacion.DTOs.Configuraciones.TipoPlanes;
using EnergymApp.API.DTO.DTOs.Configuraciones.TipoPlanes;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.TipoPlanes;
using System;
using System.Collections.Generic;
using System.Text;


namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.TiposDePlanes
{
    public class TipoPlanesAppService : ITipoPlanesAppService
    {
        private readonly ITipoPlanesRepositorio _tipoPlanesRepositorio;

        public TipoPlanesAppService(ITipoPlanesRepositorio TipoPlanesRepositorio)
        {
            if (TipoPlanesRepositorio == null) throw new ArgumentNullException("TipoPlanesRepositorio");
            _tipoPlanesRepositorio = TipoPlanesRepositorio;
        }

        public List<TipoPlanesDTO> ObtenerTipoPlanes(ObtenerTipoPlanesRequest request)
        {
            List<TipoPlanesDTO> tipoPlanesListados = _tipoPlanesRepositorio.ObtenerTipoPlanes();
            return tipoPlanesListados;
        }
        public TipoPlanesDTO GuardarTipoPlan(NuevoTipoPlanRequest request)
        {
            if (request.NombrePlan == null) throw new ArgumentNullException("NombrePlanvacio");
            if (request.NoIntegrantes == null) throw new ArgumentNullException("NoIntregantesvacio");
            if (request.CostoPlan == null) throw new ArgumentNullException("CostoDePlanvacio");


            TipoPlanesDTO tipoPlanesDTO = new TipoPlanesDTO
            {
                NombrePlan = request.NombrePlan,
                NoIntegrantes = request.NoIntegrantes,
                CostoPlan = request.CostoPlan,
            }; 

            TipoPlanesDTO response = _tipoPlanesRepositorio.GuardarTipoPlan(tipoPlanesDTO);
            return response;
        }

      public TipoPlanesDTO ModificarTipoPlan(ModificarTipoPlanRequest request)
        {
            return null;
        }

        public TipoPlanesDTO ObtenerTipoPlanId(ObtenerIdTipoPlanesRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
