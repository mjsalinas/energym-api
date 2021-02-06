using EnergymApp.API.Aplicacion.DTOs.Configuraciones.ModalidadGrupal;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergymApp.API.Infraestructura.Repositorios.Grupos.ModalidadGrupalRepo
{
    public interface IModalidadGrupalRepositorio
    {
        public ModalidadGrupalDTO ObtenerGrupoPorId(int id);
    }
}
