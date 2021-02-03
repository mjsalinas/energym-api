using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Configuraciones.TipoPlanes
{
    public class TipoPlanesDTO
    {
        public int IdPlan { get; set; }
        public string NombrePlan { get; set; }
        public int NoIntegrantes { get; set; }
        public decimal CostoPlan { get; set; }
        public sbyte RegistroOculto { get; set; }
        public string MensajeDeError { get; set; }
    }
}
