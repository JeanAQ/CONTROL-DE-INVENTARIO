using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Venta
    {

        public List<DetalleVenta> Detalles { get; set; }



        public string id_Ventas { get; set; }

        public string serie { get; set; }
        public string documento { get; set; }
        public string fecha { get; set; }


        public string id_cliente { get; set; }

        public string id_pago{ get; set; }


        public string cod_usuario { get; set; }

        

        public string sub_total { get; set; }
        public string igv { get; set; }

        public string total { get; set; }






        public string id_producto { get; set; }

        public string des_producto { get; set; }

        public string precio { get; set; }

        public string cantidad { get; set; }
        public string importe { get; set; }

    }
}
