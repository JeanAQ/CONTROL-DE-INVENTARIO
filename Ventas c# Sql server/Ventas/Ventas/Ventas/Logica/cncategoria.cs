using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public sealed class cncategoria
    {
        public static bool Grabar(Entidades.categorias pEntidad)
        {


            return AccesoDato.adcategoria.Grabar(pEntidad);

        }

        public static List<Entidades.categorias> Listar(string dato)
        {
            return AccesoDato.adcategoria.Listar(dato);

        }

        public static bool Eliminar(Entidades.categorias pEntidad)
        {


            return AccesoDato.adcategoria.Eliminar(pEntidad);
        }

    }
}
