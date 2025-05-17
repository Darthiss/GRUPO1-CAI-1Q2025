using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public enum EstadoCambioContraseña
    {
        Exito,
        CredencialesInvalidas,
        UsuarioBloqueado,
        ContraseñaIgualALaAnterior,
        ErrorInterno
    }
}
