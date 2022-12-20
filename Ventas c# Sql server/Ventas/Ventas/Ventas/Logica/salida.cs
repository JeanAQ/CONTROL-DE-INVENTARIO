using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Negocios
{
    public static class salida
    {

        public static void Grabar(Entidades.salida ppEntidad)
        {
            AccesoDato.salida.Registrarr(ppEntidad);




        }

        public static void Detalle_Guardar(Entidades.salida ppEntidad)
        {
            AccesoDato.salida.Registra(ppEntidad);


        }

    }
}