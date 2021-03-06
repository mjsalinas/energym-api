using EnergymApp.API.Aplicacion.DTOs.Clientes.Clientes;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.ModalidadGrupal;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.TipoPlanes;
using EnergymApp.API.Infraestructura.Repositorios.Cliente.Cliente;
using EnergymApp.API.Infraestructura.Repositorios.Configuraciones.TipoPlanes;
using EnergymApp.API.Infraestructura.Repositorios.Grupos.ModalidadGrupalRepo;
using System;
using System.Collections.Generic;
using System.Text;
using static EnergymApp.API.DTO.DTOs.Grupos.ModalidadGrupalDTO.ModalidadGrupalRequest;
//using static EnergymApp.API.DTO.DTOs.Grupos.ModalidadGrupalDTO.ModalidadGrupalRequest;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Grupos
{
    public class ModalidadGrupalAppService : IModalidadGrupalAppService
    {
        private readonly IModalidadGrupalRepositorio _modalidadGrupalRepositorio;
        private readonly IClientesRepositorio _clientesRepositorio;
        private readonly ITipoPlanesRepositorio _tipoPlanesRepositorio;

        public ModalidadGrupalAppService(IModalidadGrupalRepositorio modalidadGrupalRepositorio,
            IClientesRepositorio clientesRepositorio,
            ITipoPlanesRepositorio tipoPlanesRepositorio)
        {
           if (modalidadGrupalRepositorio == null) throw new ArgumentNullException("modalidadGrupalRepositorio");
           if (clientesRepositorio == null) throw new ArgumentNullException("clientesRepositorio");
           if (tipoPlanesRepositorio == null) throw new ArgumentNullException("tipoPlanesRepositorio");
            _modalidadGrupalRepositorio = modalidadGrupalRepositorio;
            _clientesRepositorio = clientesRepositorio;
            _tipoPlanesRepositorio = tipoPlanesRepositorio;
        }

        public List<ModalidadGrupalDTO> ObtenerModalidadGrupal(ObtenerGruposRequest request)
        {
            List<ModalidadGrupalDTO> gruposListados = _modalidadGrupalRepositorio.ObtenerModalidadGrupal();
            return gruposListados;
        }

        public ModalidadGrupalDTO CrearNuevoGrupo(NuevoGrupoRequest request) 
        {
           if (request.IdPlan == null) throw new ArgumentNullException("idTipoDePlanVacio");
           if (request.LiderGrupo == null) throw new ArgumentNullException("liderGrupoVacio");

            TipoPlanesDTO existeTipoDePlan = _tipoPlanesRepositorio.ObtenerTipoPlanId(request.IdPlan);
            if (existeTipoDePlan == null)
            {
                return new ModalidadGrupalDTO
                {
                    MensajeDeError = "Tipo de plan no existe"
                };
            }

            List<ClientesDTO> existeCliente = _clientesRepositorio.ObtenerClientes();
            if (existeCliente == null)
            {
                return new ModalidadGrupalDTO
                {
                    MensajeDeError = "Cliente no existe"
                };
            }

            ModalidadGrupalDTO modalidadGrupalDTO = new ModalidadGrupalDTO
            {
                LiderDeGrupo = request.LiderGrupo,
                IdPlan = request.IdPlan,
                GrupoActivo = 1,

            };
            ModalidadGrupalDTO response = _modalidadGrupalRepositorio.GuardarModalidadGrupal(modalidadGrupalDTO);
            return response;
        }
        public ModalidadGrupalDTO ModificarModalidadGrupal(ModificarGrupoRequest request)
        {
            return null;
        }
    }
}
