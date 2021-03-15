using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.DTO.DTOs.Configuraciones.UnidadesMedida
{
    public class ObtenerUnidadesMedidaRequest
    {

    }
    public class ObtenerUnidadesMedidaIdRequest
    {
        public int IdUnidadMedida { get; set; }
    }

    public class NuevaUnidadMedidadRequest
    {
        public string UnidadMedida { get; set; }
        public byte? RegistroOculto { get; set; }
    }

    public class ModificarUnidadMedidadRequest
    {
        public int IdUnidadMedida { get; set; }
        public string UnidadMedida { get; set; }
        public byte? RegistroOculto { get; set; }
    }
}

