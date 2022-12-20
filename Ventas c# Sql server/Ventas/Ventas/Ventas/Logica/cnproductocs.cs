using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio

{
   
    public sealed class cnproducto
    {
        public static bool Grabar(Entidades.producto pEntidad)
        {


            return AccesoDato.adproducto.Grabar(pEntidad);
        }

        public static List<Entidades.producto> Listar(string dato)
        {
            return AccesoDato.adproducto.Listar(dato);
        }

        public static bool Eliminar(Entidades.producto pEntidad)
        {


            return AccesoDato.adproducto.Eliminar(pEntidad);
        }

    }
}
