using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;


namespace Presentacion

{
    class Usuarios : cone
    {

        string usuario;
        string contraseña;
        string tipo;

        public Usuarios()
        {
            usuario = string.Empty;
            contraseña = string.Empty;
            sql = string.Empty;

        }
        public string Usuario
        {
            get { return this.usuario; }

            set { this.usuario = value; }



        }

        public string Contraseña
        {
            get { return this.contraseña; }

            set { this.contraseña = value; }



        }

        public string Tipo
        {
            get { return this.tipo; }

            set { this.tipo = value; }



        }

        public bool Buscar()
        {

            bool resultado = false;
            this.sql = string.Format(@"select COD_USUARIO,USUARIO,CONTRASEÑA,CARGO FROM USUARIOS WHERE USUARIO='{0}' AND CONTRASEÑA='{1}' AND CARGO='{2}'", this.usuario, this.contraseña, this.tipo);
            this.comandosql = new SqlCommand(this.sql, this.cnn);


            this.cnn.Open();
            SqlDataReader Reg = null;
            Reg = comandosql.ExecuteReader();
            if (Reg.Read())
            {

                resultado = true;

               this.mensaje = "Bienvenido al Sistema Almacen/Inventarios/Compras/Ventas";


            }

            else
            {

                resultado = false;
                this.mensaje = "Datos incorrecto,Verifique por favor";



            }

            this.cnn.Close();
            return resultado;


        }

    }

}





