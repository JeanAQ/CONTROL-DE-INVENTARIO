using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;


namespace AccesoDato
{
    public sealed class adentrada 

    {
        public static bool Grabar(Entidades.entradas pEntidad)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {

                using (var cmd = new SqlCommand(@"select * from  entrada where ID_ENTRADA=@ID_ENTRADA;", cn))
                {


 

                    cmd.Parameters.AddWithValue("@ID_ENTRADA", pEntidad.id_entrada);
                    cmd.Parameters.AddWithValue("@SERIE", pEntidad.serie);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", pEntidad.documento);
                    cmd.Parameters.AddWithValue("@FECHA", pEntidad.fecha);
                    cmd.Parameters.AddWithValue("@IDPROVEEDOR", pEntidad.id_proveedor);
                    cmd.Parameters.AddWithValue("@N_FACTURA", pEntidad.n_factura);
                    cmd.Parameters.AddWithValue("@ORDEN_COMPRA", pEntidad.orden_compra);

                    cmd.Parameters.AddWithValue("@DESTINO", pEntidad.destino);
                    cmd.Parameters.AddWithValue("@OBSERVACION", pEntidad.observacion);
                    cmd.Parameters.AddWithValue("@COD_USUARIO", pEntidad.cod_usuario);



                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {


                        //cmd.CommandText = @"update CATEGORIA set ID_CATEGORIA=@ID_CATEGORIA,NOMBRECATEGORIA=@NOMBRECATEGORIA where ID_CATEGORIA=@ID_CATEGORIA;";

                    }
                    else
                        cmd.CommandText = @"insert into ENTRADA(ID_ENTRADA,SERIE,DOCUMENTO,FECHA,IDPROVEEDOR,N_FACTURA,ORDEN_COMPRA,DESTINO,OBSERVACION,COD_USUARIO) values (@ID_ENTRADA,@SERIE,@DOCUMENTO,@FECHA,@IDPROVEEDOR,@N_FACTURA,@ORDEN_COMPRA,@DESTINO,@OBSERVACION,@COD_USUARIO);";


                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

      
            

        


    }
}

