using System;
using System.Collections.Generic;

namespace Negocio
{
    public sealed class cncargo
    {
        public static bool Grabar(Entidades.cargo pEntidad)
        {


            return AccesoDato.adcargo.Grabar(pEntidad);

        }

        public static List<Entidades.cargo> Listar(string dato)
        {
            return AccesoDato.adcargo.Listar(dato);
        }

        public static bool Eliminar(Entidades.cargo pEntidad)
        {


            return AccesoDato.adcargo.Eliminar(pEntidad);
        }

    }
}

