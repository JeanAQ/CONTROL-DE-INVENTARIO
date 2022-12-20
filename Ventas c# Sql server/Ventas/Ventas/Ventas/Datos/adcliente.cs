using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AccesoDato
{
    public sealed class adcliente

    {
        public static bool Grabar(Entidades.cliente pEntidad)

        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {

                using (var cmd = new SqlCommand(@"select * from CLIENTE where ID_CLIENTE=@ID_CLIENTE;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_CLIENTE", pEntidad.id_cliente);
                    cmd.Parameters.AddWithValue("CLIENTE", pEntidad.clientes);
                    cmd.Parameters.AddWithValue("TELEFONO", pEntidad.telefono);
                    cmd.Parameters.AddWithValue("DIRECCION", pEntidad.direccion);

                    cmd.Parameters.AddWithValue("TIPO_CLIENTE", pEntidad.tipo_cliente);
                    cmd.Parameters.AddWithValue("NUMERO_REGISTRO", pEntidad.numero_registro);

                    cmd.Parameters.AddWithValue("EMAIL", pEntidad.email);


                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {


                        cmd.CommandText = @"update CLIENTE set ID_CLIENTE=@ID_CLIENTE,CLIENTE=@CLIENTE,TELEFONO=@TELEFONO,DIRECCION=@DIRECCION,TIPO_CLIENTE=@TIPO_CLIENTE,NUMERO_REGISTRO=@NUMERO_REGISTRO,EMAIL=@EMAIL where ID_CLIENTE=@ID_CLIENTE;";

                    }
                    else
                        cmd.CommandText = @"insert into CLIENTE (ID_CLIENTE,CLIENTE,TELEFONO,DIRECCION,TIPO_CLIENTE,NUMERO_REGISTRO,EMAIL) values (@ID_CLIENTE,@CLIENTE,@TELEFONO,@DIRECCION,@TIPO_CLIENTE,@NUMERO_REGISTRO,@EMAIL);";


                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        //----------------listado de  grilla mostar-------------------------------------------

        public static List<Entidades.cliente> Listar(string dato)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                var lista = new List<Entidades.cliente>();
                using (var cmd = new SqlCommand("select  ID_CLIENTE,CLIENTE,TELEFONO,DIRECCION,TIPO_CLIENTE,NUMERO_REGISTRO,EMAIL from CLIENTE  where CLIENTE  like @des +'%'", cn))
                {
                    cmd.Parameters.AddWithValue("des", dato);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oCategoria = new Entidades.cliente();



                            oCategoria.id_cliente= Convert.ToString(dr["ID_CLIENTE"]);

                            oCategoria.clientes = Convert.ToString(dr["CLIENTE"]);
                            oCategoria.telefono = Convert.ToString(dr["TELEFONO"]);
                            oCategoria.direccion = Convert.ToString(dr["DIRECCION"]);
                            oCategoria.tipo_cliente = Convert.ToString(dr["TIPO_CLIENTE"]);
                            oCategoria.numero_registro = Convert.ToString(dr["NUMERO_REGISTRO"]);

                        
                            oCategoria.email = Convert.ToString(dr["EMAIL"]);








                            lista.Add(oCategoria);
                            oCategoria = null;
                        }
                    }
                    return lista;
                }
            }
        }


        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





        public static bool Eliminar(Entidades.cliente pEntidad)
        {

            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                
                using (var cmd = new SqlCommand(@"select ID_CLIENTE from CLIENTE where ID_CLIENTE=@ID_CLIENTE;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_CLIENTE", pEntidad.id_cliente);

                    cn.Open();


                    cmd.CommandText = "delete from CLIENTE  where ID_CLIENTE=@ID_CLIENTE;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }


            }

        }


    }
}

