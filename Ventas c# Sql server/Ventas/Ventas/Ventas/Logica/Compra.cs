using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios


{
    public static class Compra
    {

        public static void Grabar(Entidades.Compra pEntidad)
        {
            AccesoDato.Comprass.Registrar(pEntidad);

        }

    }
}