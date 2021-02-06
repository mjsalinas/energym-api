using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Aplicacion.DTOs.Clientes.Clientes
{
    public class ObtenerClientesRequest
    {

    }

    public class ObtenerClienteIdRequest
    {
        public int IdCliente { get; set; }
    }

    public class NuevoClienteRequest
    {
        public string Nombre { get; set; }
        public string NumeroTelefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Correo { get; set; }
        public int TipoPlan { get; set; }
        public int IdGrupo { get; set; }
    }
    public class ModificarClienteRequest
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string NumeroTelefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Correo { get; set; }
        public int TipoPlan { get; set; }
        public int IdGrupo { get; set; }
    }
}
