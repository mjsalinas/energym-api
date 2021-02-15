using EnergymApp.API.Aplicacion.DTOs.Configuraciones.OportunidadesDTO;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Configuraciones.Oportunidades;
using EnergymApp.API.DTO.DTOs.Configuraciones.OportunidadesDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergymApp.Controllers.Configuraciones.Oportunidades
{
    [ApiController]
    [Route("[controller]")]
    public class OportunidadesController : ControllerBase
    {
        private readonly IOportunidadesAppService _IOportunidadesAppService;
        public OportunidadesController(IOportunidadesAppService iOportunidadesAppService)
        {
            _IOportunidadesAppService = iOportunidadesAppService;
        }
        [HttpGet]
        public IActionResult ObtenerOportunidades()
        {
            ObtenerOportunidadesRequest obtenerOportunidadesRequest = new ObtenerOportunidadesRequest { };
            List<OportunidadesDTO> oportunidades = _IOportunidadesAppService.ObtenerOportunidades(obtenerOportunidadesRequest);
            return Ok(oportunidades);
        }
        [HttpPost]
        public IActionResult GuardarOportunidad(NuevaOportunidadRequest request)
        {
            var oportunidad = _IOportunidadesAppService.GuardarOportunidad(request);
            if (oportunidad.MensajeDeError == string.Empty)
            {
                return Ok(oportunidad);
            }
            else
            {
                return BadRequest(oportunidad);
            }
        }
    }
}
