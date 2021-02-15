using EnergymApp.API.Aplicacion.DTOs.Configuraciones.CamposSeguimiento;
using EnergymApp.API.DTO.DTOs.Configuraciones.CamposSeguimiento;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.CamposSeguimiento;
using System;
using System.Collections.Generic;
using System.Text;



namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.CamposSeguimiento
{  
    public class CamposSeguimientoAppService : ICamposSeguimientoAppService
    {

        private readonly ICamposSeguimientoRepositorio _campoSeguimientoRepositorio;

        public CamposSeguimientoAppService(ICamposSeguimientoRepositorio campoSeguimientoRepositorio)
        {
            if (campoSeguimientoRepositorio == null) throw new ArgumentNullException("campoSeguimientoRepositorio");
            _campoSeguimientoRepositorio = campoSeguimientoRepositorio;
        }

        public List<CamposSeguimientoDTO> ObetenerCamposSeguimiento(ObtenerCamposSeguimientoRequest request)
        {
            List<CamposSeguimientoDTO> camposSeguimientoListados = _campoSeguimientoRepositorio.ObtenerCamposSeguimiento();
            return camposSeguimientoListados;
        }
        public CamposSeguimientoDTO GuardarCamposSeguimientoRequest(GuardarCamposSeguimientoRequest request, CamposSeguimientoDTO camposSeguimientoDTO)
        {
            if (request.IdCampoSeguimiento == null) throw new ArgumentNullException("IdCampoSeguimientovacio");
            if (request.IdUnidadMedida == null) throw new ArgumentNullException("IdUnidadMedidavacio");
            if (request.CampoSeguimiento1 == null) throw new ArgumentNullException("CampoSeguimientovacio");


            CamposSeguimientoDTO tipoPlanesDTO = new CamposSeguimientoDTO
            {
                IdCampoSeguimiento = request.IdCampoSeguimiento,
                IdUnidadMedida = request.IdUnidadMedida,
                CampoSeguimiento1 = request.CampoSeguimiento1,
            };

            CamposSeguimientoDTO response = _campoSeguimientoRepositorio.GuardarCamposSeguimiento(camposSeguimientoDTO);
            return response;
        }

        public CamposSeguimientoDTO ModificarCamposSeguimiento(ModificarCamposSeguimientoRequest request)
        {
            return null;
        }

        public List<CamposSeguimientoDTO> ObtenerCamposSeguimiento(ObtenerCamposSeguimientoRequest request)
        {
            throw new NotImplementedException();
        }

        public CamposSeguimientoDTO GuardarCamposSeguimiento(GuardarCamposSeguimientoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}



