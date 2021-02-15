using EnergymApp.API.Aplicacion.DTOs.Configuraciones.TipoPlanes;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.TiposDePlanes;
using EnergymApp.API.DTO.DTOs.Configuraciones.TipoPlanes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergymApp.Controllers.Clientes
{
    
        [ApiController]
        [Route("[controller]")]
        public class TipoPlanController : Controller
        {
            private readonly ITipoPlanesAppService _iTipoPlanesAppService;
            public TipoPlanController(ITipoPlanesAppService iTipoPlanesAppService)
            {
                _iTipoPlanesAppService = iTipoPlanesAppService;
            }
            [HttpGet]
            public IActionResult ObtenerTipoPlanes()
            {
                ObtenerTipoPlanesRequest ObtenerTipoPlanesRequest = new ObtenerTipoPlanesRequest { };
                List<TipoPlanesDTO> TipoPlanes = _iTipoPlanesAppService.ObtenerTipoPlanes(ObtenerTipoPlanesRequest);
                return Ok(TipoPlanes);
            }
            [HttpPost]
            public IActionResult NuevoTipoPlanRequest(NuevoTipoPlanRequest request)
            {
                var TipoPlanes = _iTipoPlanesAppService.GuardarTipoPlan(request);
                if (TipoPlanes.MensajeDeError == string.Empty)
                {
                    return Ok(TipoPlanes);
                }
                else
                {
                    return BadRequest(TipoPlanes);
                }
            }
            [HttpPut]
            public IActionResult ModificarTipoPlanRequest(ModificarTipoPlanRequest request)
            {
                var TipoPlanes = _iTipoPlanesAppService.ModificarTipoPlan(request);
                if (TipoPlanes.MensajeDeError == string.Empty)
                {
                    return Ok(TipoPlanes);
                }
                else
                {
                    return BadRequest(TipoPlanes);
                }
            }

        }
}
