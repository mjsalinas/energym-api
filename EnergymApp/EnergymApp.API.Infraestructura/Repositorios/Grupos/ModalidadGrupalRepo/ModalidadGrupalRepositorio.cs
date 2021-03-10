using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.ModalidadGrupal;
using EnergymApp.API.Infraestructura.Repositorios.Grupos.ModalidadGrupalRepo;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.ModalidadGrupalRepo
{
        public class ModalidadGrupalRepositorio: IModalidadGrupalRepositorio
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

        public ModalidadGrupalDTO ModificarModalidadGrupal(ModalidadGrupalDTO modalidadGrupal)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();

                ModalidadGrupal modalidadGrupalEntidad = db.ModalidadGrupal.FirstOrDefault(camSeg => camSeg.IdGrupo == modalidadGrupal.IdGrupo);
                if (modalidadGrupalEntidad == null)
                {
                    return new ModalidadGrupalDTO
                    {
                        MensajeDeError = MensajeErrorInexistencia
                    };
                };
                modalidadGrupalEntidad.IdGrupo = modalidadGrupal.IdGrupo;
                modalidadGrupalEntidad.IdPlan = modalidadGrupal.IdPlan;
                modalidadGrupalEntidad.LiderGrupo = modalidadGrupal.LiderDeGrupo;
                modalidadGrupalEntidad.GrupoActivo = modalidadGrupal.GrupoActivo;
                db.SaveChanges();
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
        public ModalidadGrupalDTO ObtenerGrupoPorId(int id)
        {
            ContextoEnergym db = new ContextoEnergym();
            ModalidadGrupal modalidadGrupalEntidad = new ModalidadGrupal();
            modalidadGrupalEntidad = db.ModalidadGrupal.FirstOrDefault(grupo => grupo.IdGrupo == id);
            return new ModalidadGrupalDTO
            {
                IdGrupo = modalidadGrupalEntidad.IdGrupo,
                IdPlan = modalidadGrupalEntidad.IdPlan,
                LiderDeGrupo = modalidadGrupalEntidad.LiderGrupo,
                GrupoActivo = modalidadGrupalEntidad.GrupoActivo,
            };
        }

    }
}
    
