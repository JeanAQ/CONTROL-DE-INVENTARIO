using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;


namespace AccesoDato
{
    public sealed class adcategoria
    {
        public static bool Grabar(Entidades.categorias pEntidad)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {

                using (var cmd = new SqlCommand(@"select * from CATEGORIA where ID_CATEGORIA=@ID_CATEGORIA;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_CATEGORIA", pEntidad.id_categoria);
                    cmd.Parameters.AddWithValue("NOMBRECATEGORIA", pEntidad.nombrecategoria);



                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {


                        cmd.CommandText = @"update CATEGORIA set ID_CATEGORIA=@ID_CATEGORIA,NOMBRECATEGORIA=@NOMBRECATEGORIA where ID_CATEGORIA=@ID_CATEGORIA;";

                    }
                    else
                        cmd.CommandText = @"insert into CATEGORIA(ID_CATEGORIA,NOMBRECATEGORIA) values (@ID_CATEGORIA,@NOMBRECATEGORIA);";


                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        //----------------listado de  grilla mostar-------------------------------------------

        public static List<Entidades.categorias> Listar(string dato)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                var lista = new List<Entidades.categorias>();
                using (var cmd = new SqlCommand("select ID_CATEGORIA,NOMBRECATEGORIA from CATEGORIA where NOMBRECATEGORIA  like @des +'%'", cn))
                {
                    cmd.Parameters.AddWithValue("des", dato);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oCategoria = new Entidades.categorias();

                            oCategoria.id_categoria = Convert.ToString(dr["ID_CATEGORIA"]);

                            oCategoria.nombrecategoria= Convert.ToString(dr["NOMBRECATEGORIA"]);




                            lista.Add(oCategoria);
                            oCategoria = null;
                        }
                    }
                    return lista;
                }
            }
        }


        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





        public static bool Eliminar(Entidades.categorias pEntidad)
        {

            using (var cn = new SqlConnection(conexion.LeerCC))
            {

                using (var cmd = new SqlCommand(@"select ID_CATEGORIA from CATEGORIA where ID_CATEGORIA=@ID_CATEGORIA;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_CATEGORIA", pEntidad.id_categoria);

                    cn.Open();


                    cmd.CommandText = "delete from CATEGORIA where ID_CATEGORIA=@ID_CATEGORIA;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }


            }

        }


    }
}

