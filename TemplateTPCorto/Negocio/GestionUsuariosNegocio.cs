using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestionUsuariosNegocio
    {
        private readonly UsuarioPersistencia usuarioPersistencia;
        public GestionUsuariosNegocio()
        {
            this.usuarioPersistencia = new UsuarioPersistencia();
        }
        public Credencial BuscarCredencial(string legajo)
        { 
           return usuarioPersistencia.BuscarCredencial(legajo);            
        }
    }
}
