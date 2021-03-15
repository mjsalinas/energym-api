using EnergymApp.API.Aplicacion.DTOs.Configuraciones.UnidadesMedida;
using EnergymApp.API.DTO.DTOs.Configuraciones.UnidadesMedida;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.UnidadesDeMedida;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Configuraciones.UnidadesMedida
{
    public class UnidadesMedidaAppService : IUnidadesMedidaAppService
    {
        private readonly IUnidadesMedidaRepositorio _unidadesMedidaRepositorio;

        public UnidadesMedidaAppService(IUnidadesMedidaRepositorio unidadesMedidaRepositorio)
        {
            if (unidadesMedidaRepositorio == null) throw new ArgumentNullException("unidadesMedidaRepositorio");
            _unidadesMedidaRepositorio = unidadesMedidaRepositorio;

        }

        public List<UnidadesMedidaDTO> ObtenerUnidadesMedida(ObtenerUnidadesMedidaRequest request)
        {
            List<UnidadesMedidaDTO> UnidadesMedidaListados = _unidadesMedidaRepositorio.ObtenerUnidadesMedida();
            return UnidadesMedidaListados;
        }

        public UnidadesMedidaDTO CrearNuevaUnidadMedida(NuevaUnidadMedidadRequest request)
        {
            if (request.UnidadMedida == null || request.UnidadMedida == string.Empty) throw new ArgumentException("unidadMedidaVacia");
            
            UnidadesMedidaDTO unidadMedidaDTO = new UnidadesMedidaDTO
            {
                UnidadMedida = request.UnidadMedida,
                RegistroOculto = 0,
            };

            UnidadesMedidaDTO response = _unidadesMedidaRepositorio.GuardarUnidadMedida(unidadMedidaDTO);
            return response;

        }

        public UnidadesMedidaDTO ModificarUnidadMedida(ModificarUnidadMedidadRequest request)
        {
            if (request.IdUnidadMedida == null) throw new ArgumentException("unidadMedidaVacia");

            UnidadesMedidaDTO unidadMedidaDTO = new UnidadesMedidaDTO
            {
                IdUnidadMedida = request.IdUnidadMedida,
                UnidadMedida = request.UnidadMedida,
                RegistroOculto = request.RegistroOculto,
            };

            UnidadesMedidaDTO response = _unidadesMedidaRepositorio.ModificarUnidadMedida(unidadMedidaDTO);
            return response;

        }
    }
}
