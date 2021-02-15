using EnergymApp.API.Aplicacion.DTOs.Clientes.DatosSeguimiento;
using EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.DatosSeguimiento;
using EnergymApp.API.DTO.DTOs.Clientes.DatosSeguimiento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergymApp.Controllers.DatosSeguimiento
{
     [ApiController] 
     [Route("[controller]")]
public class DatosSeguimientoController :ControllerBase
    {
    private readonly IDatosSeguimientoAppService _iDatosSeguimientoAppService;
    public DatosSeguimientoController(IDatosSeguimientoAppService iDatosSeguimientoAppService)
    {
        _iDatosSeguimientoAppService = iDatosSeguimientoAppService;
    }
    [HttpGet]
    public IActionResult ObtenerDatoSeguimiento()
    {
        ObtenerDatosSeguimientoRequest obtenerDatosSeguimientoRequest = new ObtenerDatosSeguimientoRequest { };
        List<DatosSeguimientoDTO> registroPagos = _iDatosSeguimientoAppService.ObtenerDatoSeguimiento(obtenerDatosSeguimientoRequest);
        return Ok(registroPagos);
    }
    [HttpPost]
    public IActionResult CrearNuevoDatoSeguimiento(NuevoDatosSeguimientoRequest request)
    {
        var datoSeguimiento = _iDatosSeguimientoAppService.CrearNuevoDatoSeguimiento(request);
        if (datoSeguimiento.MensajeDeError == string.Empty)
        {
            return Ok(datoSeguimiento);
        }
        else
        {
            return BadRequest(datoSeguimiento);
        }
    }
    [HttpPut]
    public IActionResult ModificarDatoSeguimiento(ModificarDatosSeguimientoRequest request)
    {
        var datoSeguimiento = _iDatosSeguimientoAppService.ModificarDatoSeguimiento(request);
        if (datoSeguimiento.MensajeDeError == string.Empty)
        {
            return Ok(datoSeguimiento);
        }
        else
        {
            return BadRequest(datoSeguimiento);
        }
    }
}

}

