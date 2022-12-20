using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Negocio
{
    public sealed class cnpersonal
    {
        public static bool Grabar(Entidades.personal pEntidad)
        {


            return AccesoDato.adpersonal.Grabar(pEntidad);

        }

        public static List<Entidades.personal> Listar(string dato)
        {
            return AccesoDato.adpersonal.Listar(dato);
        }

        public static bool Eliminar(Entidades.personal pEntidad)
        {


            return AccesoDato.adpersonal.Eliminar(pEntidad);
        }

    }
}
