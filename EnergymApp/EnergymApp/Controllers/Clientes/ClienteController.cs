using EnergymApp.API.Aplicacion.DTOs.Clientes.Clientes;
using EnergymApp.API.Aplicacion.Servicios.Clientes.Clientes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergymApp.Controllers.Clientes
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesAppService _iClientesAppService;
        public ClienteController(IClientesAppService iClientesAppService)
        {
            _iClientesAppService = iClientesAppService;
        }
        [HttpGet]
        public IActionResult ObtenerClientes()
        {
            ObtenerClientesRequest obtenerClientesRequest = new ObtenerClientesRequest { };
            List<ClientesDTO> clientes = _iClientesAppService.ObtenerClientes(obtenerClientesRequest);
            return Ok(clientes);
        }
        [HttpPost]
        public IActionResult CrearCliente(NuevoClienteRequest request)
        {
            var cliente = _iClientesAppService.CrearNuevoCliente(request);
            if (cliente.MensajeDeError == string.Empty)
            {
                return Ok(cliente);
            }
            else
            {
                return BadRequest(cliente);
            }
        }
        [HttpPut]
        public IActionResult ModificarCliente(ModificarClienteRequest request)
        {
            var cliente = _iClientesAppService.ModificarCliente(request);
            if (cliente.MensajeDeError == string.Empty)
            {
                return Ok(cliente);
            }
            else
            {
                return BadRequest(cliente);
            }
        }
    }
}
