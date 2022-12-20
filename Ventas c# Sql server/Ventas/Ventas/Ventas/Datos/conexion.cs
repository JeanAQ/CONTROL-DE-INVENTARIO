using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccesoDato
{
    class conexion
    {
        public static string LeerCC
        {
            

            get { return "Server=.\\SQLEXPRESS;Initial Catalog=SISTEMA_VENTAS;Integrated Security=True"; }



        }
    }
}