using EnergymApp.API.Aplicacion.DTOs.Configuraciones.OportunidadesDTO;
using EnergymApp.API.DTO.DTOs.Configuraciones.OportunidadesDTO;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.OportunidadesRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Configuraciones.Oportunidades
{
    public class OportunidadesAppService : IOportunidadesAppService
    {
        private readonly IOportunidadesRepositorio _oportunidadesRepositorio;
        public OportunidadesAppService(IOportunidadesRepositorio oportunidadesRepositorio)
        {
            if (oportunidadesRepositorio == null) throw new ArgumentNullException("oportunidadesRepositorio");
            _oportunidadesRepositorio = oportunidadesRepositorio;

        }

        public List<OportunidadesDTO> ObtenerOportunidades(ObtenerOportunidadesRequest request)
        {
            List<OportunidadesDTO> OportunidadesListados = _oportunidadesRepositorio.ObtenerOportunidades();
            return OportunidadesListados;
        }
        public OportunidadesDTO GuardarOportunidad(NuevaOportunidadRequest request)
        {
            if (request.Oportunidad == null || request.Oportunidad == string.Empty) throw new ArgumentException("oportunidadVacia");
            if (request.FechaTransaccion == null)
            {
                request.FechaTransaccion = System.DateTime.Now;
            }
            if (request.TipoOportunidad == null || request.TipoOportunidad == string.Empty) throw new ArgumentException("tipoOportunidadVacia");

            OportunidadesDTO oportunidadesDTO = new OportunidadesDTO
            {
                Oportunidad = request.Oportunidad,
                FechaTransaccion = request.FechaTransaccion,
                TipoOportunidad = request.TipoOportunidad,
            };

            OportunidadesDTO response = _oportunidadesRepositorio.GuardarOportunidad(oportunidadesDTO);
            return response;
        }


    }

}
