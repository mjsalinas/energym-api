using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.CamposSeguimiento;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.CamposSeguimiento
{
  
        public class CamposSeguimientoRepositorio: ICamposSeguimientoRepositorio
    {
            private const string MensajeErrorInexistencia = "Unidad de Medida no existe";
            public List<CamposSeguimientoDTO> ObtenerCamposSeguimiento()
            {
                ContextoEnergym db = new ContextoEnergym();
                List<CampoSeguimiento> CamposSeguimiento = db.CampoSeguimiento.ToList();
                List<CamposSeguimientoDTO> CamposSeguimientoDTO = new List<CamposSeguimientoDTO>();

                foreach (var campoSeguimiento in CamposSeguimiento)
                {
                    CamposSeguimientoDTO.Add(new CamposSeguimientoDTO
                    {
                        IdCampoSeguimiento = campoSeguimiento.IdCampoSeguimiento,
                        IdUnidadMedida = campoSeguimiento.IdUnidadMedida,
                        CampoSeguimiento1 = campoSeguimiento.CampoSeguimiento1,
                        RegistroOculto = campoSeguimiento.RegistroOculto,
                    });
                }
                return CamposSeguimientoDTO;
            }

            public CamposSeguimientoDTO GuardarCamposSeguimiento(CamposSeguimientoDTO campoSeguimiento)
            {
                try
                {
                    ContextoEnergym db = new ContextoEnergym();
                    CampoSeguimiento campoSeguimientoEntidad = new CampoSeguimiento
                    {
                        IdUnidadMedida = campoSeguimiento.IdUnidadMedida,
                        CampoSeguimiento1 = campoSeguimiento.CampoSeguimiento1,
                        RegistroOculto = campoSeguimiento.RegistroOculto,
                    };
                    db.CampoSeguimiento.Add(campoSeguimientoEntidad);
                    db.SaveChanges();
                    campoSeguimiento.IdUnidadMedida = campoSeguimientoEntidad.IdUnidadMedida;
                    return campoSeguimiento;
                }
                catch (Exception ex)
                {
                    return new CamposSeguimientoDTO
                    {
                        MensajeDeError = ex.Message
                    };
                }
            }

            

            public CamposSeguimientoDTO modificarCamposSeguimiento(CamposSeguimientoDTO campoSeguimiento)
            {
                try
                {
                    ContextoEnergym db = new ContextoEnergym();

                    CampoSeguimiento campoSeguimientoEntidad = db.CampoSeguimiento.FirstOrDefault(camSeg => camSeg.IdCampoSeguimiento == campoSeguimiento.IdCampoSeguimiento);
                    if (campoSeguimientoEntidad == null)
                    {
                        return new CamposSeguimientoDTO
                        {
                            MensajeDeError = MensajeErrorInexistencia
                        };
                    };
                    campoSeguimientoEntidad.IdUnidadMedida = campoSeguimiento.IdUnidadMedida;
                    campoSeguimientoEntidad.CampoSeguimiento1 = campoSeguimiento.CampoSeguimiento1;
                    campoSeguimientoEntidad.RegistroOculto = campoSeguimiento.RegistroOculto;
                    db.SaveChanges();
                    return campoSeguimiento;
                }
                catch (Exception ex)
                {
                    return new CamposSeguimientoDTO
                    {
                        MensajeDeError = ex.Message
                    };
                }
            }
        }
    
}
