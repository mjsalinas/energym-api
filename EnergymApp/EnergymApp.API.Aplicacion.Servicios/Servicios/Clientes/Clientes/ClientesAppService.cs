using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Aplicacion.DTOs.Clientes.Clientes;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.ModalidadGrupal;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.TipoPlanes;
using EnergymApp.API.Infraestructura.Repositorios.Cliente.Cliente;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.TipoPlanes;
using EnergymApp.API.Infraestructura.Repositorios.Grupos.ModalidadGrupalRepo;

namespace EnergymApp.API.Aplicacion.Servicios.Clientes.Clientes
{
    public class ClientesAppService : IClientesAppService
    {
        private readonly IClientesRepositorio _clientesRepositorio;
        private readonly ITipoPlanesRepositorio _tipoPlanesRepositorio;
        private readonly IModalidadGrupalRepositorio _modalidadGrupalRepositorio;

        public ClientesAppService(IClientesRepositorio clientesRepositorio,
            ITipoPlanesRepositorio tipoPlanesRepositorio,
            IModalidadGrupalRepositorio modalidadGrupalRepositorio)
        {
            if (clientesRepositorio == null) throw new ArgumentNullException("clientesRepositorio");
            if (tipoPlanesRepositorio == null) throw new ArgumentNullException("tipoPlanesRepositorio");
            if (modalidadGrupalRepositorio == null) throw new ArgumentNullException("modalidadGrupalRepositorio");
            _clientesRepositorio = clientesRepositorio;
            _tipoPlanesRepositorio = tipoPlanesRepositorio;
            _modalidadGrupalRepositorio = modalidadGrupalRepositorio;
        }
        public List<ClientesDTO> ObtenerClientes(ObtenerClientesRequest request)
        {
            List<ClientesDTO> clientesListados = _clientesRepositorio.ObtenerClientes();
            return clientesListados;
        }
        public ClientesDTO CrearNuevoCliente(NuevoClienteRequest request)
        {
            if ( string.IsNullOrEmpty(request.Nombre)) throw new ArgumentNullException("nombreDeClienteVacio");
            if (string.IsNullOrEmpty(request.NumeroTelefono)) throw new ArgumentNullException("numeroTelefonoVacio");
            if (string.IsNullOrEmpty(request.Correo)) throw new ArgumentNullException("correoVacio");
            if (request.TipoPlan == null) throw new ArgumentNullException("idTipoDePlanVacio");
            if (request.IdGrupo == null) throw new ArgumentNullException("idGrupoVacio");
            if (request.FechaIngreso == null)
            {
                request.FechaIngreso = System.DateTime.Now;
            }
            TipoPlanesDTO existeTipoDePlan = _tipoPlanesRepositorio.ObtenerTipoPlanId(request.TipoPlan);
            if (existeTipoDePlan == null)
            {
                return new ClientesDTO
                {
                    MensajeDeError = "Tipo de plan no existe"
                };
            }
            ModalidadGrupalDTO existeGrupo = _modalidadGrupalRepositorio.ObtenerGrupoPorId(request.IdGrupo);
            if (existeGrupo == null)
            {
                return new ClientesDTO
                {
                    MensajeDeError = "Grupo no existe"
                };
            }
            ClientesDTO clienteDTO = new ClientesDTO
            {
                Nombre = request.Nombre,
                NumeroTelefono = request.NumeroTelefono,
                FechaIngreso = request.FechaIngreso,
                Correo = request.Correo,
                TipoPlan = request.TipoPlan,
                IdGrupo = request.IdGrupo,
                Activo = 1,
                EstadoCliente = "En mora",
            };
            ClientesDTO response = _clientesRepositorio.GuardarCliente(clienteDTO);
            return response;
        }
        public ClientesDTO ModificarCliente(ModificarClienteRequest request) { 
            return null; 
        }
    }
}
