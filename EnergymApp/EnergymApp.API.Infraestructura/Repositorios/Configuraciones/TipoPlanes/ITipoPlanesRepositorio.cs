using EnergymApp.API.Aplicacion.DTOs.Configuraciones.TipoPlanes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Infraestructura.Repositorios.Configuraciones.TipoPlanes
{
    public interface ITipoPlanesRepositorio
    {
        public List<TipoPlanesDTO> ObtenerTipoPlanes();
        public TipoPlanesDTO ObtenerTipoPlanId(int id);
        public TipoPlanesDTO GuardarTipoPlan(TipoPlanesDTO tipoDePlan);


    }
}
