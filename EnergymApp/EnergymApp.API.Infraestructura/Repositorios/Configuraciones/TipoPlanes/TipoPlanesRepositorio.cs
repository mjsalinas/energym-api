using System;
using System.Collections.Generic;
using System.Text;
using EnergymApp.API.Domino.Contexto;
using EnergymApp.API.Aplicacion.DTOs.Configuraciones.TipoPlanes;
using EnergymApp.API.Domino.ModelosDB;
using System.Linq;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.TipoPlanes
{
    public class TipoPlanesRepositorio
    {
       public List<TipoPlanesDTO> ObtenerTipoPlanes()
        {
            ContextoEnergym db = new ContextoEnergym();
            List<TipoDePlan> tipoPlanes = db.TipoDePlan.ToList();
            List<TipoPlanesDTO> tipoPlanesDTO = new List<TipoPlanesDTO>();

            foreach (var tipoPlan in tipoPlanes)
            {
                tipoPlanesDTO.Add(new TipoPlanesDTO
                {
                    IdPlan = tipoPlan.IdPlan,
                    NombrePlan = tipoPlan.NombrePlan,
                    NoIntegrantes = tipoPlan.NoIntegrantes,
                    CostoPlan = tipoPlan.CostoPlan,
                    RegistroOculto = tipoPlan.RegistroOculto,
                });
            }
            return tipoPlanesDTO;
        }

        public TipoPlanesDTO GuardarTipoPlan(TipoPlanesDTO tipoDePlan)
        {
            try
            {
                ContextoEnergym db = new ContextoEnergym();
                TipoDePlan tipoPlanEntidad = new TipoDePlan
                {

                    NombrePlan = tipoDePlan.NombrePlan,
                    NoIntegrantes = tipoDePlan.NoIntegrantes,
                    CostoPlan = tipoDePlan.CostoPlan,
                    RegistroOculto = tipoDePlan.RegistroOculto,
                };
                db.TipoDePlan.Add(tipoPlanEntidad);
                db.SaveChanges();
                tipoDePlan.IdPlan = tipoPlanEntidad.IdPlan;
                return tipoDePlan;
            }
            catch (Exception ex)
            {
                return new TipoPlanesDTO
                {
                    MensajeDeError = ex.Message
                };
            }
        }

    }
}
