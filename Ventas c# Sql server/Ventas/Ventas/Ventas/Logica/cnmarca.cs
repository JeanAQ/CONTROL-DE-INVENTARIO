using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public sealed class cnmarca

    {
        public static bool Grabar(Entidades.marca pEntidad)
        {


            return AccesoDato.admarca.Grabar(pEntidad);



        }

        public static List<Entidades.marca> Listar(string dato)
        {
            return AccesoDato.admarca.Listar(dato);

        }

        public static bool Eliminar(Entidades.marca pEntidad)
        {


            return AccesoDato.admarca.Eliminar(pEntidad);

        }

    }
}