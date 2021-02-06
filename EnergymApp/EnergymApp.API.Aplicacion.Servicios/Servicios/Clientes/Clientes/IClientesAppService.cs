using EnergymApp.API.Aplicacion.DTOs.Clientes.Clientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.Servicios.Clientes.Clientes
{
    public interface IClientesAppService
    {
        public List<ClientesDTO> ObtenerClientes(ObtenerClientesRequest request);
        public ClientesDTO CrearNuevoCliente(NuevoClienteRequest request);
        public ClientesDTO ModificarCliente(ModificarClienteRequest request);
    }
}
