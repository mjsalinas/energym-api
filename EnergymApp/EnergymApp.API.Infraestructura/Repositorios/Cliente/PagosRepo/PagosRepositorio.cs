using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.Pagos;

namespace EnergymApp.API.Infraestructura.Repositorios.Cliente.PagosRepo
{
    public class PagosRepositorio
    {
        private const string MensajeErrorInexistencia = "Pago no existe";
        public List<PagosDTO> ObtenerPagos()
        {
            ContextoEnergym db = new ContextoEnergym();
            List<Pagos> pagos= db.Pagos.ToList();
            List<PagosDTO> PagosDTO = new List<PagosDTO>();

            foreach (var Pagos in pagos)
            {
                PagosDTO.Add(new PagosDTO
                {
                    IdPago = Pagos.IdPagos,
                    IdCliente = Pagos.IdCliente,
                    EstadoDePago = Pagos.EstadoDePago,
                    FechaDeMaximaDePago = Pagos.FechaMaximaPago,
                });
            }
            return PagosDTO;
        }

        public PagosDTO GuardarPagos(PagosDTO pagos)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();
                Pagos PagosEntidad = new Pagos
                {
                    IdPagos = pagos.IdPago,
                    IdCliente = pagos.IdCliente,
                    EstadoDePago = pagos.EstadoDePago,
                    FechaMaximaPago = pagos.FechaDeMaximaDePago,
                };
                db.Pagos.Add(PagosEntidad);
                db.SaveChanges();
                pagos.IdPago = PagosEntidad.IdPagos;
                return pagos;
            }
            catch (Exception ex)
            {
                return new PagosDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }

        public PagosDTO ModificarPagos(PagosDTO Pagos)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();

                Pagos PagosEntidad = db.Pagos.FirstOrDefault(camSeg => camSeg.IdPagos == Pagos.IdPago);
                if (PagosEntidad == null)
                {
                    return new PagosDTO
                    {
                        MensajeDeError = MensajeErrorInexistencia
                    };
                };
                PagosEntidad.IdPagos = Pagos.IdPago;
                PagosEntidad.IdCliente = Pagos.IdCliente;
                PagosEntidad.EstadoDePago = Pagos.EstadoDePago;
                PagosEntidad.FechaMaximaPago = Pagos.FechaDeMaximaDePago;
                db.SaveChanges();
                return Pagos;
            }
            catch (Exception ex)
            {
                return new PagosDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }
    }
}
