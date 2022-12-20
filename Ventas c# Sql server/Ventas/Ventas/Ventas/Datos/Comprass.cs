using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;
using System.Data;

namespace AccesoDato

{
    public static class Comprass



    {



        public static void Registrar(Entidades.Compra pEntidad)
        {




            var cn = new SqlConnection(conexion.LeerCC);




            var cmdC = new SqlCommand("sp_guardar_compra", cn);

            var cmdD = new SqlCommand("sp_guardar_detalle_compra", cn);
            SqlTransaction tr = null;

            cmdC.CommandType = CommandType.StoredProcedure;
            cmdD.CommandType = CommandType.StoredProcedure;

            
            cmdC.Parameters.AddWithValue("@id_compra",pEntidad.id_compra);
            cmdC.Parameters.AddWithValue("@serie", pEntidad.serie);
            cmdC.Parameters.AddWithValue("@documento", pEntidad.documento);
            cmdC.Parameters.AddWithValue("@fecha", pEntidad.fecha);
            cmdC.Parameters.AddWithValue("@id_proveedor", pEntidad.id_proveedor);
            cmdC.Parameters.AddWithValue("@cod_usuario", pEntidad.cod_usuario);
            cmdC.Parameters.AddWithValue("@sub_total", pEntidad.sub_total);
            cmdC.Parameters.AddWithValue("@igv", pEntidad.igv);
            cmdC.Parameters.AddWithValue("@total", pEntidad.total);



            

            cmdD.Parameters.AddWithValue("@id_Compra", 0);
            cmdD.Parameters.AddWithValue("@id_producto", 0);
            cmdD.Parameters.AddWithValue("@des_producto", 0);
            cmdD.Parameters.AddWithValue("@Precio", 0);
            cmdD.Parameters.AddWithValue("@cantidad", 0);
            cmdD.Parameters.AddWithValue("@importe",  0);

            try
            {
                cn.Open();
                tr = cn.BeginTransaction();
                cmdC.Transaction = tr;
                cmdD.Transaction = tr;

                cmdC.ExecuteNonQuery();
       

                foreach (var det in pEntidad.Detalles)
                {
                    cmdD.Parameters["@id_compra"].Value = det.id_compra;

                    cmdD.Parameters["@id_producto"].Value = det.id_producto;
                
                    cmdD.Parameters["@des_producto"].Value = det.des_producto;

                    cmdD.Parameters["@precio"].Value = det.precio;
                    cmdD.Parameters["@Cantidad"].Value = det.cantidad;
               
                    cmdD.Parameters["@importe"].Value = det.importe;

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

    }
    
}