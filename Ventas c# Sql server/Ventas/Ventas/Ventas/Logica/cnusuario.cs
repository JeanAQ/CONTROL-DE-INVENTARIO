using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public sealed class cnusuario
    {
        public static bool Grabar(Entidades.usuario pEntidad)
        {


            return AccesoDato.adusuario.Grabar(pEntidad);

        }

        public static List<Entidades.usuario> Listar(string dato)
        {
            return AccesoDato.adusuario.Listar(dato);
        }

        public static bool Eliminar(Entidades.usuario pEntidad)
        {


            return AccesoDato.adusuario.Eliminar(pEntidad);
        }

    }
}
