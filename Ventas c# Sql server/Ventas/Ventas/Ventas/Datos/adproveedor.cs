using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AccesoDato
{
    public sealed class adproveedor
    {
        public static bool Grabar(Entidades.Proveedor pEntidad)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {

                using (var cmd = new SqlCommand(@"select * from proveedor where  ID_Proveedor=@ID_Proveedor;", cn))
                {
                    
                    cmd.Parameters.AddWithValue("ID_PROVEEDOR", pEntidad.id_proveedor);
                    cmd.Parameters.AddWithValue("DES_PROVEEDOR", pEntidad.des_proveedor);
                    cmd.Parameters.AddWithValue("TELEFONO", pEntidad.telefono);
                    cmd.Parameters.AddWithValue("DIRECCION", pEntidad.direccion);
                    cmd.Parameters.AddWithValue("NOMBRE_BANCO", pEntidad.nombre_banco);
                    cmd.Parameters.AddWithValue("NUMERO_CUENTA", pEntidad.numero_cuenta);
                    cmd.Parameters.AddWithValue("RIT", pEntidad.rit);
                    cmd.Parameters.AddWithValue("EMAIL", pEntidad.email);


                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {

                        
                        cmd.CommandText = @"update proveedor set ID_PROVEEDOR=@ID_PROVEEDOR,des_proveedor=@des_proveedor,telefono=@telefono,DIRECCION=@DIRECCION,nombre_banco=@nombre_banco,numero_cuenta=@numero_cuenta,RIT=@RIT,EMAIL=@EMAIL where ID_PROVEEDOR=@ID_PROVEEDOR;";

                    }
                    else
                        cmd.CommandText = @"insert into proveedor (ID_PROVEEDOR,des_proveedor,telefono,DIRECCION,nombre_banco,numero_cuenta,RIT,EMAIL) values (@ID_proveedor,@des_proveedor,@telefono,@DIRECCION,@nombre_banco,@numero_cuenta,@RIt,@emaIl);";

                   
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

               //----------------listado de  grilla mostar-------------------------------------------

        public static List<Entidades.Proveedor> Listar(string dato)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                var lista = new List<Entidades.Proveedor>();
                using (var cmd = new SqlCommand("select ID_proveedor,des_proveedor,telefono,DIRECCION,nombre_banco,numero_cuenta,RIT,EMAIL from proveedor where des_proveedor  like @des +'%'", cn))
                {
                    cmd.Parameters.AddWithValue("des", dato);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oCategoria = new Entidades.Proveedor();

                            oCategoria.id_proveedor = Convert.ToString(dr["ID_proveedor"]);

                            oCategoria.des_proveedor = Convert.ToString(dr["des_proveedor"]);

                           

                            oCategoria.telefono = Convert.ToString(dr["telefono"]);
                            oCategoria.direccion = Convert.ToString(dr["DIRECCION"]);

                            oCategoria.nombre_banco= Convert.ToString(dr["nombre_banco"]);
                            oCategoria.numero_cuenta = Convert.ToString(dr["numero_cuenta"]);



                            oCategoria.rit = Convert.ToString(dr["RIT"]);
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





        public static bool Eliminar(Entidades.Proveedor pEntidad)
        {

            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                
                using (var cmd = new SqlCommand(@"select ID_proveedor from proveedor where ID_proveedor=@ID_proveedor;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_PROVEEDOR", pEntidad.id_proveedor);

                    cn.Open();


                    cmd.CommandText = "delete from proveedor where ID_proveedor=@ID_proveedor;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }


            }

        }
       
          
 }   
}

