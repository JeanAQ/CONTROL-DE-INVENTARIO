using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class salida
    {

        public List<DetalleSalida> Detalles { get; set; }





        public string id_salida{ get; set; }

        public string serie { get; set; }
        public string documento { get; set; }
        public string fecha { get; set; }


        public string id_cliente { get; set; }

        public string n_factura { get; set; }


        public string orden_compra { get; set; }



        public string destino { get; set; }
        public string observacion{ get; set; }

        public string cod_usuario{ get; set; }






        public string id_producto { get; set; }

        public string des_producto { get; set; }

      

        public string cantidad { get; set; }
   

    }
}
