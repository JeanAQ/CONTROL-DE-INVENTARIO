using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace AccesoDato
{
    public static class Venta
    {



        public static void Registrarr(Entidades.Venta ppEntidad)
        {




            var cn = new SqlConnection(conexion.LeerCC);




            var cmdC = new SqlCommand("SP_GUARDAR_VENTAS", cn);

            var cmdD = new SqlCommand("SP_GUARDAR_DETALLE_VENTAS", cn);
            SqlTransaction tr = null;

            cmdC.CommandType = CommandType.StoredProcedure;
            cmdD.CommandType = CommandType.StoredProcedure;


            cmdC.Parameters.AddWithValue("@ID_VENTAS", ppEntidad.id_Ventas);
            cmdC.Parameters.AddWithValue("@SERIE", ppEntidad.serie);
            cmdC.Parameters.AddWithValue("@DOCUMENTO", ppEntidad.documento);
            cmdC.Parameters.AddWithValue("@FECHA", ppEntidad.fecha);
            cmdC.Parameters.AddWithValue("@COD_USUARIO", ppEntidad.cod_usuario);
            cmdC.Parameters.AddWithValue("@ID_CLIENTE", ppEntidad.id_cliente);
            cmdC.Parameters.AddWithValue("@ID_PAGO", ppEntidad.id_pago);

            cmdC.Parameters.AddWithValue("@SUB_TOTAL", ppEntidad.sub_total);
            cmdC.Parameters.AddWithValue("@IVA", ppEntidad.igv);
            cmdC.Parameters.AddWithValue("@TOTAL", ppEntidad.total);





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

                    cmdD.Parameters.AddWithValue("@ID_COMPRA",det.id_ventas);
                    cmdD.Parameters.AddWithValue("@ID_PRODUCTO",det.id_producto);
                    cmdD.Parameters.AddWithValue("@DES_PRODUCTO", det.des_producto);
                    cmdD.Parameters.AddWithValue("@PRECIO",det.precio);
                    cmdD.Parameters.AddWithValue("@CANTIDAD",det.cantidad);
                    cmdD.Parameters.AddWithValue("@IMPORTE", det.importe);

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






     public static void Registra(Entidades.Venta ppEntidad)
        //public static bool Eliminar(Entidades.personal pEntidad)
        {

           

         using (SqlConnection  cn= new SqlConnection(conexion.LeerCC))


           {
             using(SqlCommand cmd = new SqlCommand ())
             {

                 cmd.Connection = cn;

                     cn.Open();



                   foreach (var det in ppEntidad.Detalles)



                {

                    cmd.Parameters.AddWithValue("@ID_COMPRA",det.id_ventas);
                    cmd.Parameters.AddWithValue("@ID_PRODUCTO",det.id_producto);
                    cmd.Parameters.AddWithValue("@DES_PRODUCTO", det.des_producto);
                    cmd.Parameters.AddWithValue("@PRECIO",det.precio);
                    cmd.Parameters.AddWithValue("@CANTIDAD",det.cantidad);
                    cmd.Parameters.AddWithValue("@IMPORTE", det.importe);



                    cmd.ExecuteNonQuery();
                }



                }


            }

        }


    }
}