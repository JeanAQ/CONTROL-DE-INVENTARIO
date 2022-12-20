using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;





namespace AccesoDato
{
    public sealed class adformapagos
    {
        public static bool Grabar(Entidades.formapagos pEntidad)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {

                using (var cmd = new SqlCommand(@"select * from CARGO where ID_CARGO=@ID_CARGO;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_PAGO", pEntidad.id_pago);
                    cmd.Parameters.AddWithValue("DESCRIPCION", pEntidad.descripcion);
                    cmd.Parameters.AddWithValue("OBSERVACION", pEntidad.descripcion);



                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {


                        cmd.CommandText = @"update FORMA_PAGO set ID_PAGO=@ID_PAGO,DESCRIPCION=@DESCRIPCION,OBSERVACION=@OBSERVACION where ID_PAGO=@ID_PAGO;";

                    }
                    else
                        cmd.CommandText = @"insert into FORMA_PAGO(ID_PAGO,DESCRIPCION,OBSERVACION) values (@ID_PAGO,@DESCRIPCION,@OBSERVACION);";


                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        //----------------listado de  grilla mostar-------------------------------------------

        public static List<Entidades.formapagos> Listar(string dato)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                var lista = new List<Entidades.formapagos>();
                using (var cmd = new SqlCommand("select ID_PAGO,DESCRIPCION,OBSERVACION from FORMA_PAGO where DESCRIPCION  like @des +'%'", cn))
                {
                    cmd.Parameters.AddWithValue("des", dato);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oCategoria = new Entidades.formapagos();

                            oCategoria.id_pago = Convert.ToString(dr["ID_PAGO"]);

                            oCategoria.descripcion = Convert.ToString(dr["DESCRIPCION"]);

                            oCategoria.observacion = Convert.ToString(dr["OBSERVACION"]);




                            lista.Add(oCategoria);
                            oCategoria = null;
                        }
                    }
                    return lista;
                }
            }
        }


        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





        public static bool Eliminar(Entidades.formapagos pEntidad)
        {

            using (var cn = new SqlConnection(conexion.LeerCC))
            {

                using (var cmd = new SqlCommand(@"select ID_PAGO from FORMA_PAGO where ID_PAGO=@ID_PAGO;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_PAGO", pEntidad.id_pago);

                    cn.Open();


                    cmd.CommandText = "delete from FORMA_PAGO where ID_PAGO=@ID_PAGO;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }


            }

        }


    }
}

