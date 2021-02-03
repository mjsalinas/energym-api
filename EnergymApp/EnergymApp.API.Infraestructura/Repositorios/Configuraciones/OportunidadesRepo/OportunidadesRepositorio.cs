using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.Contexto;
using EnergymApp.API.Domino.ModelosDB;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.OportunidadesDTO;
using System.Linq;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.OportunidadesRepo
{
    public class OportunidadesRepositorio
    {
        public List<OportunidadesDTO> ObtenerOportunidades()
        {
            ContextoEnergym db = new ContextoEnergym();
            List<Oportunidades> oportunidades = db.Oportunidades.ToList();
            List<OportunidadesDTO> oportunidadesDTO = new List<OportunidadesDTO>();

            foreach (var oportunidad in oportunidades)
            {
                oportunidadesDTO.Add(new OportunidadesDTO
                {
                    IdOportunidad = oportunidad.IdOportunidad,
                    Oportunidad = oportunidad.Oportunidad,
                    TipoOportunidad = oportunidad.TipoOportunidad,
                });
            }
            return oportunidadesDTO;
        }

        public OportunidadesDTO GuardarOportunidad(OportunidadesDTO oportunidad)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();
                Oportunidades unidadMedidaEntidad = new Oportunidades
                {
                    Oportunidad = oportunidad.Oportunidad,
                    TipoOportunidad = oportunidad.TipoOportunidad,
                    FechaTransaccion = System.DateTime.Now,
                };
                db.Oportunidades.Add(unidadMedidaEntidad);
                db.SaveChanges();
                oportunidad.IdOportunidad = unidadMedidaEntidad.IdOportunidad;
                return oportunidad;
            }
            catch (Exception ex)
            {
                return new OportunidadesDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }
    }
}
