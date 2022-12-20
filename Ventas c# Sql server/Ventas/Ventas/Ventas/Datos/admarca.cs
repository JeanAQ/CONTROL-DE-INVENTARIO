using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace AccesoDato
{
    public sealed class admarca
    {
        public static bool Grabar(Entidades.marca pEntidad)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                
                using (var cmd = new SqlCommand(@"select * from marca  where  ID_MARCA=@ID_marca;", cn))
                {
                  
                    cmd.Parameters.AddWithValue("ID_MARCA", pEntidad.id_marca);
                    cmd.Parameters.AddWithValue("NOMBREMARCA", pEntidad.nombremarca);



                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {

                      
                        cmd.CommandText = @"update marca set ID_MARCA=@ID_MARCA,NOMBREMARCA=@NOMBREMARCA where ID_MARCA=@ID_MARCA;";

                    }
                    else
                        cmd.CommandText = @"insert into MARCA(ID_MARCA,NOMBREMARCA) values (@ID_MARCA,@NOMBREMARCA);";

                 
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        //----------------listado de  grilla mostar-------------------------------------------

        public static List<Entidades.marca> Listar(string dato)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                var lista = new List<Entidades.marca>();
                using (var cmd = new SqlCommand("select ID_MARCA,NOMBREMARCA from MARCA where NOMBREMARCA like @des +'%'", cn))
                {
                    cmd.Parameters.AddWithValue("des", dato);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oCategoria = new Entidades.marca();

                            oCategoria.id_marca = Convert.ToString(dr["ID_MARCA"]);

                            oCategoria.nombremarca = Convert.ToString(dr["NOMBREMARCA"]);




                            lista.Add(oCategoria);
                            oCategoria = null;
                        }
                    }
                    return lista;
                }
            }
        }


        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





        public static bool Eliminar(Entidades.marca pEntidad)
        {

            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                
                using (var cmd = new SqlCommand(@"select ID_MARCA from MARCA  where ID_MARCA=@ID_MARCA;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_MARCA", pEntidad.id_marca);

                    cn.Open();


                    cmd.CommandText = "delete from MARCA where ID_MARCA=@ID_MARCA;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }


            }

        }


    }
}

