using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;


namespace AccesoDato
{
    public static class entrada
    {



        public static void Registrarr(Entidades.entrada ppEntidad)
        {




            var cn = new SqlConnection(conexion.LeerCC);




            var cmdC = new SqlCommand("sp_guuardar_ENTRADA", cn);

            var cmdD = new SqlCommand("SP_GUARDAR_DETALLE_ENTRADA", cn);
            SqlTransaction tr = null;

            cmdC.CommandType = CommandType.StoredProcedure;
            cmdD.CommandType = CommandType.StoredProcedure;


            cmdC.Parameters.AddWithValue("@ID_ENTRADA", ppEntidad.id_entrada);
            cmdC.Parameters.AddWithValue("@SERIE", ppEntidad.serie);
            cmdC.Parameters.AddWithValue("@DOCUMENTO", ppEntidad.documento);
            cmdC.Parameters.AddWithValue("@FECHA", ppEntidad.fecha);
            cmdC.Parameters.AddWithValue("@ID_PROVEEDOR", ppEntidad.id_proveedor);
            cmdC.Parameters.AddWithValue("@N_FACTURA", ppEntidad.n_factura);
            cmdC.Parameters.AddWithValue("@ORDEN_COMPRA", ppEntidad.orden_compra);

            cmdC.Parameters.AddWithValue("@DESTINO", ppEntidad.destino);
            cmdC.Parameters.AddWithValue("@OBSERVACION", ppEntidad.observacion);
            cmdC.Parameters.AddWithValue("@COD_USUARIO", ppEntidad.cod_usuario);





            //cmdD.Parameters.AddWithValue("@ID_COMPRA", 0);
            //cmdD.Parameters.AddWithValue("@ID_PRODUCTO", 0);
            //cmdD.Parameters.AddWithValue("@DES_PRODUCTO", 0);
            //cmdD.Parameters.AddWithValue("@PRECIO", 0);
            //cmdD.Parameters.AddWithValue("@CANTIDAD", 0);
            //cmdD.Parameters.AddWithValue("@IMPORTE", 0);

            try
            {
                cn.Open();
                tr = cn.BeginTransaction();
                cmdC.Transaction = tr;
                cmdD.Transaction = tr;

                cmdC.ExecuteNonQuery();


                foreach (var det in ppEntidad.Detalles)
                {

                    cmdD.Parameters.AddWithValue("@ID_ENTRADA", det.id_entrada);
                    cmdD.Parameters.AddWithValue("@ID_PRODUCTO", det.id_producto);
                    cmdD.Parameters.AddWithValue("@DES_PRODUCTO", det.des_producto);

                    cmdD.Parameters.AddWithValue("@CANTIDAD", det.cantidad);

                    //cmdD.Parameters["@ID_VENTAS"].Value = det.id_ventas;

                    //cmdD.Parameters["@ID_PRODUCTO"].Value = det.id_producto;

                    //cmdD.Parameters["@DES_PRODUCTO"].Value = det.des_producto;

                    //cmdD.Parameters["@PRECIO"].Value = det.precio;
                    //cmdD.Parameters["@CANTIDAD"].Value = det.cantidad;

                    //cmdD.Parameters["@IMPORTE"].Value = det.importe;

                    cmdD.ExecuteNonQuery();
                }

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    if (tr != null)
                    {
                        tr = null;
                    }
                    cn.Close();
                }
                cn = null;
                cmdC.Dispose();
                cmdC = null;
                cmdD.Dispose();
                cmdD = null;
            }

        }

        //    }

        //}






        public static void Registra(Entidades.entrada ppEntidad)
        //public static bool Eliminar(Entidades.personal pEntidad)
        {



            using (SqlConnection cn = new SqlConnection(conexion.LeerCC))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cn;

                    cn.Open();



                    foreach (var det in ppEntidad.Detalles)
                    {

                        cmd.Parameters.AddWithValue("@ID_ENTRADA", det.id_entrada);
                        cmd.Parameters.AddWithValue("@ID_PRODUCTO", det.id_producto);
                        cmd.Parameters.AddWithValue("@DES_PRODUCTO", det.des_producto);

                        cmd.Parameters.AddWithValue("@CANTIDAD", det.cantidad);




                        cmd.ExecuteNonQuery();
                    }



                }


            }

        }


    }
}