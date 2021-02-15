using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Aplicacion.DTOs.Clientes.DatosSeguimiento;
using EnergymApp.API.DTO.DTOs.Clientes.DatosSeguimiento;

using EnergymApp.API.Infraestructura.Repositorios.Cliente.DatosSeguimientoRepositorio;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.DatosSeguimiento
{
    public class DatosSeguimientoAppService : IDatosSeguimientoAppService
    {

        private readonly IDatosSeguimientoRepositorio _DatosSeguimientoRepositorio;
       
        public DatosSeguimientoAppService(IDatosSeguimientoRepositorio DatosSeguimientoRepositorio)
        {
            if (DatosSeguimientoRepositorio == null) throw new ArgumentNullException("DatosSeguimientoRepositorio");
            _DatosSeguimientoRepositorio = DatosSeguimientoRepositorio;
        }

        public List<DatosSeguimientoDTO> ObtenerDatoSeguimiento(ObtenerDatosSeguimientoRequest request)
        {
            List<DatosSeguimientoDTO> DatosseguimientoListados = _DatosSeguimientoRepositorio.ObtenerDatosSegumiento();
            return DatosseguimientoListados;

        }
        public DatosSeguimientoDTO CrearNuevoDatoSeguimiento(NuevoDatosSeguimientoRequest request)
        {
            if (request.IdCliente == null) throw new ArgumentNullException("idClienteVacio");
            if (request.DatoSeguimiento == null) throw new ArgumentNullException("datoSeguimientoVacio");
            if (request.FechaRegistro == null)
            {
                request.FechaRegistro = System.DateTime.Now;
            }


            DatosSeguimientoDTO datoSeguimiento = new DatosSeguimientoDTO
            {
                IdCliente = request.IdCliente,
                DatoSeguimiento = request.DatoSeguimiento,
                FechaRegistro = request.FechaRegistro,
                

            }; ;
            DatosSeguimientoDTO response = _DatosSeguimientoRepositorio.GuardarDatosSeguimiento(datoSeguimiento);
            return response;
        
    }

        public DatosSeguimientoDTO ModificarDatoSeguimiento(ModificarDatosSeguimientoRequest request)
        {
            throw new NotImplementedException();
        }

        
    }


}



