using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public sealed class cncliente
    {
        public static bool Grabar(Entidades.cliente pEntidad)
        {


            return AccesoDato.adcliente.Grabar(pEntidad);

        }

        public static List<Entidades.cliente> Listar(string dato)
        {
            return AccesoDato.adcliente.Listar(dato);
        }

        public static bool Eliminar(Entidades.cliente pEntidad)
        {


            return AccesoDato.adcliente.Eliminar(pEntidad);
        }

    }
}
