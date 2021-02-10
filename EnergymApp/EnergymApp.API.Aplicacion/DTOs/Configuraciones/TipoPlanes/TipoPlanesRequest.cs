using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.DTO.DTOs.Configuraciones.TipoPlanes
{
   public class ObtenerTipoPlanesRequest
    {

    }
    public class ObtenerIdTipoPlanesRequest
    {
        public int IdPlan { get; set;}
    }

    public class NuevoTipoPlanRequest
    {
        public string NombrePlan { get; set; }
        public int NoIntegrantes { get; set; }
        public decimal CostoPlan { get; set; }
    }

    public class ModificarTipoPlanRequest
    {

        public string NombrePlan { get; set; }
        public int NoIntegrantes { get; set; }
        public decimal CostoPlan { get; set; }
    }
}
