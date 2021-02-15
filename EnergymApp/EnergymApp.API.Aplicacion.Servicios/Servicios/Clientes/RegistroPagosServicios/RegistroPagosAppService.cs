using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Aplicacion.DTOs.Clientes.RegistroPagosDTO;
using EnergymApp.API.DTO.DTOs.Clientes.RegistroPagosDTO;
using EnergymApp.API.Infraestructura.Repositorios.Cliente.RegistroPagosRepositorio;



namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.RegistroPagosServicios
{
    public class RegistroPagosAppService : IRegistroPagosAppService
    {
        private readonly IRegistroPagosRepositorio _RegistroPagosRepositorio;


        public RegistroPagosAppService(IRegistroPagosRepositorio RegistroPagosRepositorio)
        {
            if (RegistroPagosRepositorio == null) throw new ArgumentNullException("RegistroPagosRepositorio");
            _RegistroPagosRepositorio = RegistroPagosRepositorio;
        }

        public List<RegistroPagosDTO> ObtenerRegistroPagos(ObtenerRegistroPagosRequest request)
        {
            List<RegistroPagosDTO> registropagosListados = _RegistroPagosRepositorio.RegistroPagosDTOs();
            return registropagosListados;
        }

        public RegistroPagosDTO CrearNuevoRegistroPagos(NuevoRegistroPagosRequest request)
        {
            if (request.IdPagos == null) throw new ArgumentNullException("idPagosVacio");
            if (request.IdCliente == null) throw new ArgumentNullException("idClienteVacio");
            if (request.EstadoDePago == null || request.EstadoDePago == String.Empty) throw new ArgumentNullException("estadoDePagoVacio");
            if (request.FechaRealizacionPago == null)
            {
                request.FechaRealizacionPago = System.DateTime.Now;
            }


            RegistroPagosDTO regsitroPagoDTO = new RegistroPagosDTO
            {
                IdPagos = request.IdPagos,
                IdCliente = request.IdCliente,
                EstadoDePago = "Pendiente",
                FechaPago = request.FechaRealizacionPago,
                
            };;
            RegistroPagosDTO response = _RegistroPagosRepositorio.GuardarRegistroPago(regsitroPagoDTO);
            return response;
        }

    

        public RegistroPagosDTO ModificarRegistroPagos(ModificarRegistroPagosRequest request)
        {
            throw new NotImplementedException();
        }
    }

}
