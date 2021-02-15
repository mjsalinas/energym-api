using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergymApp.API.Aplicacion.DTOs.Clientes.RegistroPagosDTO;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.RegistroPagosServicios;
using EnergymApp.API.DTO.DTOs.Clientes.RegistroPagosDTO;
using Microsoft.AspNetCore.Mvc;

namespace EnergymApp.Controllers.RegistroPagos
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroPagosController : ControllerBase
    {
         private readonly IRegistroPagosAppService _iRegistroPagosAppService;
        public RegistroPagosController(IRegistroPagosAppService iRegitroPagosAppService)
        {
            _iRegistroPagosAppService = iRegitroPagosAppService;
        }
        [HttpGet]

        public IActionResult ObtenerRegistroPagos()
        {
            ObtenerRegistroPagosRequest obtenerRegistroPagosRequest = new ObtenerRegistroPagosRequest { };
            List<RegistroPagosDTO> registroPagos = _iRegistroPagosAppService.ObtenerRegistroPagos(obtenerRegistroPagosRequest);
            return Ok(registroPagos);
        }
        [HttpPost]
        public IActionResult CrearNuevoRegistroPagos(NuevoRegistroPagosRequest request)
        {
            var registroPagos = _iRegistroPagosAppService.CrearNuevoRegistroPagos(request);
            if (registroPagos.MensajeDeError == string.Empty)
            {
                return Ok(registroPagos);
            }
            else
            {
                return BadRequest(registroPagos);
            }
        }
        [HttpPut]
        public IActionResult ModificarRegistroPagos(ModificarRegistroPagosRequest request)
        {
            var registropagos = _iRegistroPagosAppService.ModificarRegistroPagos(request);
            if (registropagos.MensajeDeError == string.Empty)
            {
                return Ok(registropagos);
            }
            else
            {
                return BadRequest(registropagos);
            }
        }
    }
}

