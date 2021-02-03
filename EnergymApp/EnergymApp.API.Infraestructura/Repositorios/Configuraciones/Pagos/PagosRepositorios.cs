using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.Pagos;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.Pagos
{
    public class PagosRepositorio
    {
            public List<PagosDTO> ObtenerPagos()
            {
                ContextoEnergym db = new ContextoEnergym();
                List<Pagos> Pagos = db.Pagos.ToList();
                List<PagosDTO> PagosDTO = new List<PagosDTO>();

                foreach (var Pagos in pagos)
                {
                    PagosDTO.Add(new PagosDTO
                    {
                        IdPago = Pagos.IdPagos,
                        IdCliente = Pagos.IdUCliente,
                        EstadoDelPago = Pagos.EstadoDelPago,
                        FechaMaximaDePago = Pagos.FechaMaximaDePago,
                    });
                }
                return PagosDTO;
            }

            public PagosDTO GuardarPagos(PagosDTO pagos)
            {
                try
                {
                    ContextoEnergym db = new ContextoEnergym();
                    Pagos pagosEntidad = new Pagos
                    {
                        IdClinte = pagos.IdCliente,
                        EstadoDelPago = pagos.EstadoDelPago,
                        FechaMaximaDePago = pagos.FechaMaximaDePago,
                    };
                    db.Pagos.Add(pagosEntidad);
                    db.SaveChanges();
                    pagos.IdCliente = pagosEntidad.IdCliente;
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

            public PagosDTO ModificarPagos(PagosDTO pagos)
            {
                try
                {
                    ContextoEnergym db = new ContextoEnergym();

                    Pagos pagosEntidad = db.Pagos.FirstOrDefault(camSeg => camSeg.IdPagos == pagos.IdPagos);
                    if (pagosEntidad == null)
                    {
                        return new PagosDTO
                        {
                            MensajeDeError = MensajeErrorInexistencia
                        };
                    };
                    pagosEntidad.IdCliente = pagos.IdCliente;
                    pagosEntidad.EstadoDelPago = pagos.EstadoDelPago;
                    pagosEntidad.FechaMaxmaDePago= pagos.FechaMaxmaDePago;
                    db.SaveChanges();
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
        }
    }
}