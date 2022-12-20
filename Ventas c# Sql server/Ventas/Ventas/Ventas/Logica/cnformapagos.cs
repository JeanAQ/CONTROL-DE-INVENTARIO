using System;
using System.Collections.Generic;


namespace Negocio
{
    public sealed class cnformapagos
    {
        public static bool Grabar(Entidades.formapagos pEntidad)
        {


            return AccesoDato.adformapagos.Grabar(pEntidad);

        }

        public static List<Entidades.formapagos> Listar(string dato)
        {
            return AccesoDato.adformapagos.Listar(dato);
        }

        public static bool Eliminar(Entidades.formapagos pEntidad)
        {


            return AccesoDato.adformapagos.Eliminar(pEntidad);
        }

    }
}

