using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Clientes.Clientes;

namespace EnergymApp.API.Infraestructura.Repositorios.Cliente.Cliente
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        public List<ClientesDTO> ObtenerClientes()
        {
            ContextoEnergym db = new ContextoEnergym();
            List<Clientes> clientes = db.Clientes.ToList();
            List<ClientesDTO> clientesDTO = new List<ClientesDTO>();

            foreach (var cliente in clientes) 
            {
                clientesDTO.Add(new ClientesDTO
                {
                    IdCliente = cliente.IdCliente,
                    Nombre = cliente.Nombre,
                    NumeroTelefono = cliente.NumeroTelefono,
                    FechaIngreso = cliente.FechaIngreso,
                    Correo = cliente.Correo,
                    TipoPlan = cliente.TipoPlan,
                    IdGrupo = cliente.IdGrupo,
                    Activo = cliente.Activo,
                    EstadoCliente = cliente.EstadoCliente
                });
                
            }
            return clientesDTO;
        }

        public ClientesDTO GuardarCliente(ClientesDTO cliente)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();
                Clientes clienteEntidad = new Clientes
                //db.Clientes.Add(
                //new Clientes
                {
                    IdCliente = cliente.IdCliente,
                    Nombre = cliente.Nombre,
                    NumeroTelefono = cliente.NumeroTelefono,
                    FechaIngreso = cliente.FechaIngreso,
                    Correo = cliente.Correo,
                    TipoPlan = cliente.TipoPlan,
                    IdGrupo = cliente.IdGrupo,
                    Activo = cliente.Activo,
                    EstadoCliente = cliente.EstadoCliente
                };
                db.Clientes.Add(clienteEntidad);
                db.SaveChanges();
                cliente.IdCliente = clienteEntidad.IdCliente;
                return cliente;
            }
            catch (Exception ex)
            {
                return new ClientesDTO
                {
                    MensajeDeError = ex.Message
                };
            }

        }

        public ClientesDTO ModificarCliente(ClientesDTO cliente)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();

                Clientes clienteEntidad = db.Clientes.FirstOrDefault(x => x.IdCliente == cliente.IdCliente);
                if (clienteEntidad == null)
                {
                    return new ClientesDTO
                    {
                        MensajeDeError = "Cliente no existe"
                    };
                };

                clienteEntidad.Nombre = cliente.Nombre;
                clienteEntidad.NumeroTelefono = cliente.NumeroTelefono;
                clienteEntidad.FechaIngreso = cliente.FechaIngreso;
                clienteEntidad.Correo = cliente.Correo;
                clienteEntidad.TipoPlan = cliente.TipoPlan;
                clienteEntidad.IdGrupo = cliente.IdGrupo;
                clienteEntidad.Activo = cliente.Activo;
                clienteEntidad.EstadoCliente = cliente.EstadoCliente;
                db.SaveChanges();
                return cliente;
            }
            catch (Exception ex)
            {
                return new ClientesDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }
    }
}
