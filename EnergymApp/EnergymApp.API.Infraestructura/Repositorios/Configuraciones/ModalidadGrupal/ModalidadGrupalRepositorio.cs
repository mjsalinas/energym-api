using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.ModalidadGrupal;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.ModalidadGrupal
{
    public class ModalidadGrupalRepositorio
    {
            public List<ModalidadGrupalDTO> ObtenerModalidadGrupal()
            {
                ContextoEnergym db = new ContextoEnergym();
                List<ModalidadGrupal> modalidadGrupal = db.ModalidadGrupal.ToList();
                List<ModalidadGrupalCDTO> modalidadGrupalDTO = new List<ModalidadGrupalDTO>();

                foreach (var ModalidadGrupal in modalidadGrupal)
                {
                    modalidadGrupalDTO.Add(new ModalidadGrupalDTO
                    {
                        IdGrupo = modalidadGrupal.IdGrupo,
                        IdPlan = modalidadGrupal.IdPlan,
                        LiderDeGrupo = modalidadGrupal.LiderDeGrupo
                        GrupoActivo = modalidadGrupal.GrupoActivo,
                    });
                }
                return modalidadGrupalDTO;
            }

            public ModalidadGrupalDTO GuardarModalidadGrupal(ModalidadGrupalDTO modalidadGrupal)
            {
                try
                {
                    ContextoEnergym db = new ContextoEnergym();
                    ModalidadGrupal modalidadGrupalEntidad = new ModalidadGrupal
                    {
                    IdPlan = modalidadGrupal.IdPlan;
                    LiderDeGrupo = modalidadGrupal.LiderDeGrupo;
                    GrupoActivo = modalidadGrupal.GrupoActivo;
                    };
                    db.ModalidadGrupal.Add( modalidadGrupal);
                    db.SaveChanges();
                    modalidadGrupal.IdGrupo = modalidadGrupal.IdGrupo;
                    return modalidadGrupal;
                }
                catch (Exception ex)
                {
                    return new ModalidadGrupalDTO
                    {
                        MensajeDeError = ex.Message
                    };
                }
            }

            public ModalidadGrupalDTO Modificarplan(ModalidadGrupalDTO modalidadGrupal)
            {
                try
                {
                    ContextoEnergym db = new ContextoEnergym();

                    ModalidadGrupal modalidadGrupalEntidad = db.ModalidaGrupal.FirstOrDefault(camSeg => camSeg.IdGrupo == modalidadGrupal.IdGrupo);
                    if (modalidadGrupalEntidad == null)
                    {
                        return new ModalidadGrupalDTO
                        {
                            MensajeDeError = MensajeErrorInexistencia
                        };
                    };
                    modalidadGrupalEntidad.IdPlan = modalidadGrupal.IdPlan;
                    modalidadGrupalEntidad.LiderDeGrupo = modalidadGrupal.LiderDeGrupo;
                    modalidadGrupalEntidad.GrupoActivo = modalidadGrupal.GrupoActivo;
                    db.SaveChanges();
                    return modalidadGrupal;
                }
                catch (Exception ex)
                {
                    return new ModalidadGruplaDTO
                    {
                        MensajeDeError = ex.Message
                    };
                }
            }
        }
    }
}