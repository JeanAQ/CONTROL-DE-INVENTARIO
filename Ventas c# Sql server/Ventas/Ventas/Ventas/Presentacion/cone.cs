using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;


namespace Presentacion 

{
    class cone
    {

        public string cadenaconexion;

        protected string sql;
        //protected int resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosql;
        protected string mensaje;

        public cone()
        {
            this.cadenaconexion = (@"Data Source=.\SQLEXPRESS;Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            this.cnn = new SqlConnection(this.cadenaconexion);


        }


        public string Mensaje
        {
            get
            {

                return this.mensaje;


            }
        }
    }
}
