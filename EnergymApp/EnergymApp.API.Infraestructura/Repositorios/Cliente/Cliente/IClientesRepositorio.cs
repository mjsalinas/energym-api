using EnergymApp.API.Aplicacion.DTOs.Clientes.Clientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Infraestructura.Repositorios.Cliente.Cliente
{
    public interface IClientesRepositorio
    {
        public List<ClientesDTO> ObtenerClientes();
        public ClientesDTO GuardarCliente(ClientesDTO cliente);
        public ClientesDTO ModificarCliente(ClientesDTO cliente);
    }
}
