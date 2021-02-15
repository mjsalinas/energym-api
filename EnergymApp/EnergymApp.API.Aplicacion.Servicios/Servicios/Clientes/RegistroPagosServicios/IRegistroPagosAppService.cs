using EnergymApp.API.Aplicacion.DTOs.Clientes.RegistroPagosDTO;
using EnergymApp.API.DTO.DTOs.Clientes.RegistroPagosDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.Servicios.Servicios.Clientes.RegistroPagosServicios
{
    public interface IRegistroPagosAppService
    {

        public List<RegistroPagosDTO> ObtenerRegistroPagos(ObtenerRegistroPagosRequest request);
        public RegistroPagosDTO CrearNuevoRegistroPagos(NuevoRegistroPagosRequest request);
        public RegistroPagosDTO ModificarRegistroPagos(ModificarRegistroPagosRequest request);
        
    }
}


