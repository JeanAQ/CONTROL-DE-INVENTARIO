using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Negocios
{
    public static class Venta
    {

        public static void Grabar(Entidades.Venta ppEntidad)




        {
            AccesoDato.Venta.Registrarr(ppEntidad);




        }

         public static void Detalle_Guardar(Entidades.Venta ppEntidad)





        {
            AccesoDato.Venta.Registra(ppEntidad);


        }

    }
}