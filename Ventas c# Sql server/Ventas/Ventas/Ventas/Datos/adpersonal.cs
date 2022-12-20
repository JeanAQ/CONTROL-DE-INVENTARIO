using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace AccesoDato
{
    public sealed class adpersonal
    {
        public static bool Grabar(Entidades.personal pEntidad)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {

                using (var cmd = new SqlCommand(@"select * from PERSONAL where ID_PERSONAL=@ID_PERSONAL;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_PERSONAL", pEntidad.id_personal);
                    cmd.Parameters.AddWithValue("PERSONAL", pEntidad.persona);
                    cmd.Parameters.AddWithValue("DIRECCION", pEntidad.direccion);
                    cmd.Parameters.AddWithValue("TELEFONO", pEntidad.telefono);

                    cmd.Parameters.AddWithValue("ID_CARGO", pEntidad.id_cargo);
                    cmd.Parameters.AddWithValue("FECHA_INGRESO", pEntidad.fecha_ingreso);

                    cmd.Parameters.AddWithValue("COD_USUARIO", pEntidad.cod_usuario);


                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {


                        cmd.CommandText = @"update PERSONAL set ID_PERSONAL=@ID_PERSONAL,PERSONAL=@PERSONAL,DIRECCION=@DIRECCION,TELEFONO=@TELEFONO,ID_CARGO=@ID_CARGO,FECHA_INGRESO=@FECHA_INGRESO,COD_USUARIO=@COD_USUARIO where ID_PERSONAL=@ID_PERSONAL;";

                    }
                    else
                        cmd.CommandText = @"insert into PERSONAL (ID_PERSONAL,PERSONAL,DIRECCION,TELEFONO,ID_CARGO,FECHA_INGRESO,COD_USUARIO) values (@ID_PERSONAL,@PERSONAL,@DIRECCION,@TELEFONO,@ID_CARGO,@FECHA_INGRESO,@COD_USUARIO);";


                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        //----------------listado de  grilla mostar-------------------------------------------

        public static List<Entidades.personal> Listar(string dato)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                var lista = new List<Entidades.personal>();
                using (var cmd = new SqlCommand("select  ID_PERSONAL,PERSONAL,DIRECCION,TELEFONO,ID_CARGO,FECHA_INGRESO,COD_USUARIO from PERSONAL where PERSONAL  like @des +'%'", cn))
                {
                    cmd.Parameters.AddWithValue("des", dato);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oCategoria = new Entidades.personal();



                            oCategoria.id_personal = Convert.ToString(dr["ID_PERSONAL"]);

                            oCategoria.persona = Convert.ToString(dr["PERSONAL"]);
                            oCategoria.direccion = Convert.ToString(dr["DIRECCION"]);
                            oCategoria.telefono = Convert.ToString(dr["TELEFONO"]);
                            oCategoria.id_cargo = Convert.ToString(dr["ID_CARGO"]);
                            oCategoria.fecha_ingreso = Convert.ToString(dr["FECHA_INGRESO"]);


                            oCategoria.cod_usuario = Convert.ToString(dr["COD_USUARIO"]);








                            lista.Add(oCategoria);
                            oCategoria = null;
                        }
                    }
                    return lista;
                }
            }
        }


        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





        public static bool Eliminar(Entidades.personal pEntidad)
        {

            using (var cn = new SqlConnection(conexion.LeerCC))
            {
               
                using (var cmd = new SqlCommand(@"select ID_PERSONAL     from PERSONAL where ID_PERSONAL=@ID_PERSONAL;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_PERSONAL", pEntidad.id_personal);

                    cn.Open();


                    cmd.CommandText = "delete from PERSONAL  where ID_PERSONAL=@ID_PERSONAL;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }


            }

        }


    }
}

