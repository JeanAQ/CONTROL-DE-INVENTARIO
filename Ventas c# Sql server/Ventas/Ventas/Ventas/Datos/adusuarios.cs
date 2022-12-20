using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace AccesoDato
{
    public sealed class adusuario
    {
        public static bool Grabar(Entidades.usuario pEntidad)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                
                using (var cmd = new SqlCommand(@"select * from USUARIOS where COD_USUARIO=@COD_USUARIO;", cn))
                {
                    
                    cmd.Parameters.AddWithValue("COD_USUARIO", pEntidad.cod_usuario);
                    cmd.Parameters.AddWithValue("USUARIO", pEntidad.usuarios);
                    cmd.Parameters.AddWithValue("CONTRASEÑA", pEntidad.contraseña);
                    cmd.Parameters.AddWithValue("CARGO", pEntidad.cargo);



                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {

                        cmd.CommandText = @"update USUARIOS set COD_USUARIO=@COD_USUARIO,USUARIO=@USUARIO,CONTRASEÑA=@CONTRASEÑA,CARGO=@CARGO where COD_USUARIO=@COD_USUARIO;";

                    }
                    else
                        cmd.CommandText = @"insert into USUARIOS(COD_USUARIO,USUARIO,CONTRASEÑA,CARGO) values (@COD_USUARIO,@USUARIO,@CONTRASEÑA,@CARGO);";

                    
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        //----------------listado de  grilla mostar-------------------------------------------

        public static List<Entidades.usuario> Listar(string dato)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                var lista = new List<Entidades.usuario>();
                using (var cmd = new SqlCommand("select COD_USUARIO,USUARIO,CONTRASEÑA,CARGO from USUARIOS  where USUARIO  like @des +'%'", cn))
                {
                    cmd.Parameters.AddWithValue("des", dato);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oCategoria = new Entidades.usuario();

                            oCategoria.cod_usuario = Convert.ToString(dr["COD_USUARIO"]);

                            oCategoria.usuarios = Convert.ToString(dr["USUARIO"]);
                            oCategoria.contraseña = Convert.ToString(dr["CONTRASEÑA"]);
                                 oCategoria.cargo = Convert.ToString(dr["CARGO"]);




                            lista.Add(oCategoria);
                            oCategoria = null;
                        }
                    }
                    return lista;
                }
            }
        }


        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





        public static bool Eliminar(Entidades.usuario pEntidad)
        {

            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                
                using (var cmd = new SqlCommand(@"select COD_USUARIO from USUARIOS where COD_USUARIO=@COD_USUARIO;", cn))
                {

                    cmd.Parameters.AddWithValue("COD_USUARIO", pEntidad.cod_usuario);

                    cn.Open();


                    cmd.CommandText = "delete from USUARIOS where COD_USUARIO=@COD_USUARIO;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }


            }

        }


    }
}

