using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Domino.Contexto;
using System.Linq;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.UnidadesMedida;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.UnidadesDeMedida
{
    public class UnidadesMedidaRepositorio: IUnidadesMedidaRepositorio
    {
        public List<UnidadesMedidaDTO> ObtenerUnidadesMedida()
        {
            ContextoEnergym db = new ContextoEnergym();
            List<UnidadesMedida> unidadesMedida = db.UnidadesMedida.ToList();
            List<UnidadesMedidaDTO> unidadesMedidaDTO = new List<UnidadesMedidaDTO>();
            var a = db.UnidadesMedida.Count();
            foreach (var unidadMedida in unidadesMedida)
            {
                unidadesMedidaDTO.Add(new UnidadesMedidaDTO
                {
                    IdUnidadMedida = unidadMedida.IdUnidadMedida,
                    UnidadMedida = unidadMedida.UnidadMedida,
                    RegistroOculto = unidadMedida.RegistroOculto,
                });
            }
            return unidadesMedidaDTO;
        }

        public UnidadesMedidaDTO GuardarUnidadMedida(UnidadesMedidaDTO unidadMedida)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();
                UnidadesMedida unidadMedidaEntidad = new UnidadesMedida
                {
                    UnidadMedida = unidadMedida.UnidadMedida,
                    RegistroOculto = unidadMedida.RegistroOculto
                };
                db.UnidadesMedida.Add(unidadMedidaEntidad);
                db.SaveChanges();
                unidadMedida.IdUnidadMedida = unidadMedidaEntidad.IdUnidadMedida;
                return unidadMedida;
            }
            catch (Exception ex)
            {
                return new UnidadesMedidaDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }

        public UnidadesMedidaDTO ModificarUnidadMedida(UnidadesMedidaDTO unidadMedida)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();

                UnidadesMedida unidadMedidaEntidad = db.UnidadesMedida.FirstOrDefault(x => x.IdUnidadMedida == unidadMedida.IdUnidadMedida);
                if(unidadMedidaEntidad == null)
                {
                    return new UnidadesMedidaDTO
                    {
                        MensajeDeError = "Unidad de Medida no existe"
                    };
                };
                unidadMedidaEntidad.UnidadMedida = unidadMedida.UnidadMedida;
                unidadMedidaEntidad.RegistroOculto = unidadMedida.RegistroOculto;
                db.SaveChanges();
                return unidadMedida;
            }
            catch (Exception ex)
            {
                return new UnidadesMedidaDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }

    }
}
