using System;
using System.Collections.Generic;

namespace Negocio
{
    public sealed class cnproveedor
    {
        public static bool Grabar(Entidades.Proveedor pEntidad)
        {


            return AccesoDato.adproveedor.Grabar(pEntidad);
        }

        public static List<Entidades.Proveedor> Listar(string dato)
        {
            return AccesoDato.adproveedor.Listar(dato);
        }

        public static bool Eliminar(Entidades.Proveedor pEntidad)
        {


            return AccesoDato.adproveedor.Eliminar(pEntidad);
        }

    }
}
