using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace AccesoDato
{
    public sealed class adcargo
    {
        public static bool Grabar(Entidades.cargo pEntidad)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
               
                using (var cmd = new SqlCommand(@"select * from CARGO where ID_CARGO=@ID_CARGO;", cn))
                {
               
                    cmd.Parameters.AddWithValue("ID_CARGO", pEntidad.id_cargo);
                    cmd.Parameters.AddWithValue("DES_CARGO", pEntidad.des_cargo);



                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {

                       
                        cmd.CommandText = @"update CARGO set ID_CARGO=@ID_CARGO,DES_CARGO=@DES_CARGO where ID_CARGO=@ID_CARGO;";

                    }
                    else
                        cmd.CommandText = @"insert into CARGO(ID_CARGO,DES_CARGO) values (@ID_CARGO,@DES_CARGO);";

                  
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        //----------------listado de  grilla mostar-------------------------------------------

        public static List<Entidades.cargo> Listar(string dato)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                var lista = new List<Entidades.cargo>();
                using (var cmd = new SqlCommand("select ID_CARGO,DES_CARGO from CARGO where DES_CARGO  like @des +'%'", cn))
                {
                    cmd.Parameters.AddWithValue("des", dato);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oCategoria = new Entidades.cargo();

                            oCategoria.id_cargo = Convert.ToString(dr["ID_CARGO"]);

                            oCategoria.des_cargo = Convert.ToString(dr["DES_CARGO"]);




                            lista.Add(oCategoria);
                            oCategoria = null;
                        }
                    }
                    return lista;
                }
            }
        }


        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




        public static bool Eliminar(Entidades.cargo pEntidad)
        {

            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                
                using (var cmd = new SqlCommand(@"select ID_CARGO from CARGO where ID_CARGO=@ID_CARGO;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_CARGO", pEntidad.id_cargo);

                    cn.Open();


                    cmd.CommandText = "delete from CARGO where ID_CARGO=@ID_CARGO;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }


            }

        }


    }
}

