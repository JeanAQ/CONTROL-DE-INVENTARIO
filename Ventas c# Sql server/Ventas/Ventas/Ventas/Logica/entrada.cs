using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Negocios
{
    public static class entrada



    {

        public static void Grabar(Entidades.entrada ppEntidad)
        {
            AccesoDato.entrada.Registrarr(ppEntidad);




        }

        public static void Detalle_Guardar(Entidades.entrada ppEntidad)
        {
            AccesoDato.entrada.Registra(ppEntidad);


        }

    }
}