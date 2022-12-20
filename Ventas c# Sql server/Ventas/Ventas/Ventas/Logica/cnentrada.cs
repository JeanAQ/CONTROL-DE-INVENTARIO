using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public sealed class cnentrada 
    {
        public static bool Grabar(Entidades.entradas pEntidad)
        {


            return AccesoDato.adentrada.Grabar(pEntidad);

        }

      

    }
}
