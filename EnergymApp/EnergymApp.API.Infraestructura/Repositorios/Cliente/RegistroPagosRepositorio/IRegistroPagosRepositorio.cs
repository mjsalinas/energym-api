using EnergymApp.API.Aplicacion.DTOs.Clientes.RegistroPagosDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Infraestructura.Repositorios.Cliente.RegistroPagosRepositorio
{
    public interface IRegistroPagosRepositorio
    {
        public List<RegistroPagosDTO> RegistroPagosDTOs();
        public RegistroPagosDTO GuardarRegistroPago(RegistroPagosDTO RegistroPagos);
        public RegistroPagosDTO ModificarRegistroPago(RegistroPagosDTO RegistroPagos);

       
    }
}
