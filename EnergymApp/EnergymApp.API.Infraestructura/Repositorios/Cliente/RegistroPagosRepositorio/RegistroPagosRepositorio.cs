using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Clientes.RegistroPagosDTO;

namespace EnergymApp.API.Infraestructura.Repositorios.Cliente.RegistroPagosRepositorio
{
    class RegistroPagosRepositorio
    {
        public List<RegistroPagosDTO> RegistroPagosDTOs()
        {
            ContextoEnergym db = new ContextoEnergym();
            List<RegistroPagos> registropagos = db.RegistroPagos.ToList();
            List<RegistroPagosDTO> registropagosDTO = new List<RegistroPagosDTO>();

            foreach (var RegistroPagos in registropagos)
            {
                registropagosDTO.Add(new RegistroPagosDTO
                {
                    IdRegistroPago = RegistroPagos.IdRegistroPagos,
                    IdPagos= RegistroPagos.IdPagos,
                    IdCliente=RegistroPagos.IdCliente,
                    EstadoDePago=RegistroPagos.EstadoDePago,
                    FechaPago = RegistroPagos.FechaRealizacionPago,
                });

            }
            return registropagosDTO;
        }

        public RegistroPagosDTO GuardarRegistroPago(RegistroPagosDTO RegistroPagos)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();
                RegistroPagos RegistroPagoEntidad = new RegistroPagos
                {
                    IdRegistroPagos = RegistroPagos.IdRegistroPago,
                    IdPagos = RegistroPagos.IdPagos,
                    IdCliente = RegistroPagos.IdCliente,
                    EstadoDePago = RegistroPagos.EstadoDePago,
                    FechaRealizacionPago = RegistroPagos.FechaPago,
                };
                db.RegistroPagos.Add(RegistroPagoEntidad);
                db.SaveChanges();
                RegistroPagos.IdRegistroPago = RegistroPagoEntidad.IdRegistroPagos;
                return RegistroPagos;
            }
            catch (Exception ex)
            {
                return new RegistroPagosDTO
                {
                    MensajeDeError = ex.Message
                };
            }

        }

        public RegistroPagosDTO ModificarRegistroPago(RegistroPagosDTO RegistroPagos)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();

                RegistroPagos RegistroPagoEntidad = db.RegistroPagos.FirstOrDefault(x => x.IdRegistroPagos == RegistroPagos.IdRegistroPago);
                if (RegistroPagoEntidad == null)
                {
                    return new RegistroPagosDTO
                    {
                        MensajeDeError = "Registro de Pago no existe"
                    };
                };

                RegistroPagoEntidad.IdRegistroPagos = RegistroPagos.IdRegistroPago;
                RegistroPagoEntidad.IdPagos = RegistroPagos.IdPagos;
                RegistroPagoEntidad.IdCliente = RegistroPagos.IdCliente;
                RegistroPagoEntidad.EstadoDePago = RegistroPagos.EstadoDePago;
                RegistroPagoEntidad.FechaRealizacionPago = RegistroPagos.FechaPago;

                db.SaveChanges();
                return RegistroPagos;
            }
            catch (Exception ex)
            {
                return new RegistroPagosDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }
    }

}


