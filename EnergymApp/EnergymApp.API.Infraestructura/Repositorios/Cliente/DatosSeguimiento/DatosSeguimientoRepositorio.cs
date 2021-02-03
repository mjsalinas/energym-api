using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Clientes.DatosSeguimiento;


namespace EnergymApp.API.Infraestructura.Repositorios.Cliente.DatosSeguimientoRepositorio
{
    public class DatosSeguimientoRepositorio
    {
        public List<DatosSeguimientoDTO> ObtenerDatosSegumiento()
        {
            ContextoEnergym db = new ContextoEnergym();
            List<DatosSeguimiento> datos = db.DatosSeguimiento.ToList();
            List<DatosSeguimientoDTO> datosDTO = new List<DatosSeguimientoDTO>();
            
            foreach (var dsDTO in datos)
            {
                datosDTO.Add(new DatosSeguimientoDTO
                {
                    IdCampoSeguimiento = dsDTO.IdCamposSeguimiento,
                    IdCliente = dsDTO.IdCliente,
                    DatoSeguimiento = dsDTO.DatoSeguimiento,
                    FechaRegistro = dsDTO.FechaRegistro
                });
            }
            return datosDTO;
        }

        public DatosSeguimientoDTO GuardarDatosSeguimiento(DatosSeguimientoDTO ds)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();
                DatosSeguimiento entDatoSeg = new DatosSeguimiento
                {
                    IdCamposSeguimiento = ds.IdCampoSeguimiento,
                    IdCliente = ds.IdCliente,
                    DatoSeguimiento = ds.DatoSeguimiento,
                    FechaRegistro = ds.FechaRegistro
                };
                db.DatosSeguimiento.Add(entDatoSeg);
                db.SaveChanges();
                ds.IdCampoSeguimiento = entDatoSeg.IdCamposSeguimiento;
                return ds;
            }
            catch (Exception ex)
            {
                return new DatosSeguimientoDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }
        
        public DatosSeguimientoDTO ModificarDatosSeguimiento(DatosSeguimientoDTO ds)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();
                DatosSeguimiento dsEnt = db.DatosSeguimiento.FirstOrDefault(x => x.IdCamposSeguimiento == ds.IdCampoSeguimiento);
                if (dsEnt == null)
                {
                    return new DatosSeguimientoDTO
                    {
                        MensajeDeError = "Dato de Seguimiento no existente"
                    };
                }

                dsEnt.IdCamposSeguimiento = ds.IdCampoSeguimiento;
                dsEnt.IdCliente = ds.IdCliente;
                dsEnt.DatoSeguimiento = ds.DatoSeguimiento;
                dsEnt.FechaRegistro = ds.FechaRegistro;

                db.SaveChanges();
                return ds;
            }
            catch (Exception ex)
            {
                return new DatosSeguimientoDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }

    }
}
