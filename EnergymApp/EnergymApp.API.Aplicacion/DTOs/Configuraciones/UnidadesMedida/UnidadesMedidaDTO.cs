using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Configuraciones.UnidadesMedida
{
    public class UnidadesMedidaDTO
    {
        public int IdUnidadMedida { get; set; }
        public string UnidadMedida { get; set; }
        public byte? RegistroOculto { get; set; }
        public string MensajeDeError { get; set; }
    }
}
