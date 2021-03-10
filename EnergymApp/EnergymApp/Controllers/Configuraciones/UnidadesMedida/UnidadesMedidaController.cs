
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.UnidadesMedida;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Configuraciones.UnidadesMedida;
using EnergymApp.API.DTO.DTOs.Configuraciones.UnidadesMedida;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergymApp.Controllers.Configuraciones.UnidadesMedida
{
    [ApiController]
    [Route("[controller]")]
    public class UnidadesMedidaController : ControllerBase
    {
        private readonly IUnidadesMedidaAppService _iUnidadesMedidaAppService;
        public UnidadesMedidaController(IUnidadesMedidaAppService iUnidadesMedidaAppService)
        {
            _iUnidadesMedidaAppService = iUnidadesMedidaAppService;
        }
        [HttpGet]
        public IActionResult ObtenerUnidadesMedida()
        {
            ObtenerUnidadesMedidaRequest obtenerUnidadesMedidaRequest = new ObtenerUnidadesMedidaRequest { };
            List<UnidadesMedidaDTO> unidadesMedida = _iUnidadesMedidaAppService.ObtenerUnidadesMedida(obtenerUnidadesMedidaRequest);
            return Ok(unidadesMedida);
        }
        [HttpPost]
        public IActionResult GuardarUnidadMedida(NuevaUnidadMedidadRequest request)
        {
            var unidadMedida = _iUnidadesMedidaAppService.CrearNuevaUnidadMedida(request);
            if (string.IsNullOrEmpty(unidadMedida.MensajeDeError))
            {
                return Ok(unidadMedida);
            }
            else
            {
                return BadRequest(unidadMedida);
            }
        }
        [HttpPut]
        public IActionResult ModificarCliente(ModificarUnidadMedidadRequest request)
        {
            var unidadMedida = _iUnidadesMedidaAppService.ModificarUnidadMedida(request);
            if (string.IsNullOrEmpty(unidadMedida.MensajeDeError))
            {
                return Ok(unidadMedida);
            }
            else
            {
                return BadRequest(unidadMedida);
            }
        }
    }
}
