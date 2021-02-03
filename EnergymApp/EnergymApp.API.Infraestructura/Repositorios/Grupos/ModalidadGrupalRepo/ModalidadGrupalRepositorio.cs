using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.ModalidadGrupal;


namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.ModalidadGrupalRepo
{
        public class ModalidadGrupalRepositorio
        {
        private const string MensajeErrorInexistencia = "Unidad de Medida no existe";
        public List<ModalidadGrupalDTO> ObtenerModalidadGrupal()
        {
            ContextoEnergym db = new ContextoEnergym();
            List<ModalidadGrupal> modalidadesGrupales = db.ModalidadGrupal.ToList();
            List<ModalidadGrupalDTO> modalidadGrupalDTO = new List<ModalidadGrupalDTO>();

            foreach (var modalidadGrupal in modalidadesGrupales)
            {
                modalidadGrupalDTO.Add(new ModalidadGrupalDTO
                {
                    IdGrupo = modalidadGrupal.IdGrupo,
                    IdPlan = modalidadGrupal.IdPlan,
                    LiderDeGrupo = modalidadGrupal.LiderGrupo,
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
                    IdGrupo = modalidadGrupal.IdGrupo,
                    IdPlan = modalidadGrupal.IdPlan,
                    LiderGrupo = modalidadGrupal.LiderDeGrupo,
                    GrupoActivo = modalidadGrupal.GrupoActivo,
                };
                db.ModalidadGrupal.Add(modalidadGrupalEntidad);
                db.SaveChanges();
                modalidadGrupal.IdPlan = modalidadGrupalEntidad.IdPlan;
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

        public ModalidadGrupalDTO ModificarModalidadGrupal(ModalidadGrupalDTO ModalidadGrupal)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();

                ModalidadGrupal modalidadGrupalEntidad = db.ModalidadGrupal.FirstOrDefault(camSeg => camSeg.IdGrupo == ModalidadGrupal.IdGrupo);
                if (modalidadGrupalEntidad == null)
                {
                    return new ModalidadGrupalDTO
                    {
                        MensajeDeError = MensajeErrorInexistencia
                    };
                };
                modalidadGrupalEntidad.IdGrupo = ModalidadGrupal.IdGrupo;
                modalidadGrupalEntidad.IdPlan = ModalidadGrupal.IdPlan;
                modalidadGrupalEntidad.LiderGrupo = ModalidadGrupal.LiderDeGrupo;
                modalidadGrupalEntidad.GrupoActivo = ModalidadGrupal.GrupoActivo;
                db.SaveChanges();
                return ModalidadGrupal;
            }
            catch (Exception ex)
            {
                return new ModalidadGrupalDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }

    }
        }
    
