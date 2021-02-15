using EnergymApp.API.Aplicacion.DTOs.Configuraciones.CamposSeguimiento;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.CamposSeguimiento;
using EnergymApp.API.DTO.DTOs.Configuraciones.CamposSeguimiento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EnergymApp.Controllers.Clientes
{
    [ApiController]
    [Route("[controller]")]
    public class CamposSeguimientoController : Controller
    {
        private readonly ICamposSeguimientoAppService _iCamposSeguimientoAppService;
        public CamposSeguimientoController(ICamposSeguimientoAppService iCamposSeguientoAppService)
        {
            _iCamposSeguimientoAppService = iCamposSeguientoAppService;
        }
        [HttpGet]
        public IActionResult ObtenerCamposSeguimiento()
        {
            ObtenerCamposSeguimientoRequest ObtenerCamposSeguimientoRequest = new ObtenerCamposSeguimientoRequest { };
            List<CamposSeguimientoDTO> CamposSeguimiento = _iCamposSeguimientoAppService.ObtenerCamposSeguimiento(ObtenerCamposSeguimientoRequest);
            return Ok(CamposSeguimiento);
        }
        [HttpPost]
        public IActionResult GuardarCamposSeguimiento(GuardarCamposSeguimientoRequest request)
        {
            var CamposSeguimiento = _iCamposSeguimientoAppService.GuardarCamposSeguimiento(request);
            if (CamposSeguimiento.MensajeDeError == string.Empty)
            {
                return Ok(CamposSeguimiento);
            }
            else
            {
                return BadRequest(CamposSeguimiento);
            }
        }
        [HttpPut]
        public IActionResult ModificarCamposSeguimiento(ModificarCamposSeguimientoRequest request)
        {
            var CamposSeguimiento = _iCamposSeguimientoAppService.ModificarCamposSeguimiento(request);
            if (CamposSeguimiento.MensajeDeError == string.Empty)
            {
                return Ok(CamposSeguimiento);
            }
            else
            {
                return BadRequest(CamposSeguimiento);
            }
        }
    }
}
