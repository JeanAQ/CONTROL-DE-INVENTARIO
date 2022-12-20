using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace AccesoDato
{
    public sealed class adproducto

    {
        public static bool Grabar(Entidades.producto pEntidad)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {

                using (var cmd = new SqlCommand(@"select * from productos where  Id_Producto=@Id_Producto;", cn))
                {
                   
                    cmd.Parameters.AddWithValue("Id_Producto", pEntidad.id_producto);
                    cmd.Parameters.AddWithValue("des_Producto", pEntidad.des_producto);
                    cmd.Parameters.AddWithValue("precio_compra", pEntidad.precio_compra);
                    cmd.Parameters.AddWithValue("precio_venta", pEntidad.precio_venta);

                    cmd.Parameters.AddWithValue("Id_proveedor", pEntidad.id_proveedor);
                    cmd.Parameters.AddWithValue("Id_marca", pEntidad.id_marca);
                    cmd.Parameters.AddWithValue("Id_categorIa", pEntidad.id_categoria);
                    cmd.Parameters.AddWithValue("stock_actual", pEntidad.stock_actual);
                    cmd.Parameters.AddWithValue("unIdad_medIda", pEntidad.unidad_medida);
                    cmd.Parameters.AddWithValue("fecha_Ingreso", pEntidad.fecha_ingreso);


                    cn.Open();


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {

                       
                        cmd.CommandText = @"update productos set Id_producto=@Id_producto,des_producto=@des_producto,precio_compra=@precIo_compra,precio_venta=@precio_venta,Id_proveedor=@Id_proveedor,Id_marca=@Id_marca,Id_categoria=@Id_categoria,stock_actual=@stock_actual,unIdad_medida=@unIdad_medIda,fecha_Ingreso=@fecha_Ingreso  where Id_producto=@Id_producto;";

                    }
                    else
                        cmd.CommandText = @"insert into productos (Id_producto,des_producto,precIo_compra,precIo_venta,Id_proveedor,Id_marca,Id_categoria,stock_actual,unidad_medIda,fecha_Ingreso) values (@Id_producto,@des_producto,@precIo_compra,@precIo_venta,@Id_proveedor,@Id_marca,@Id_categorIa,@stock_actual,@unidad_medIda,@fecha_Ingreso);";

      
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        //----------------listado de  grilla mostar-------------------------------------------

        public static List<Entidades.producto> Listar(string dato)
        {
            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                var lista = new List<Entidades.producto>();
                using (var cmd = new SqlCommand("select ID_PRODUCTO,DES_PRODUCTO,PRECIO_COMPRA,PRECIO_VENTA,STOCK_ACTUAL,ID_PROVEEDOR,ID_MARCA,ID_CATEGORIA,UNIDAD_MEDIDA,FECHA_INGRESO from productos where des_producto  like @des +'%'", cn))
                {
                    cmd.Parameters.AddWithValue("des", dato);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oCategoria = new Entidades.producto();

                            oCategoria.id_producto= Convert.ToString(dr["Id_producto"]);

                            oCategoria.des_producto = Convert.ToString(dr["des_producto"]);



                            oCategoria.precio_compra = Convert.ToString(dr["precIo_compra"]);
                            oCategoria.precio_venta= Convert.ToString(dr["precIo_venta"]);
                            oCategoria.stock_actual = Convert.ToString(dr["stock_actual"]);
                            oCategoria.id_proveedor= Convert.ToString(dr["Id_proveedor"]);
                            oCategoria.id_marca = Convert.ToString(dr["Id_marca"]);



                            oCategoria.id_categoria = Convert.ToString(dr["Id_categorIa"]);
                           


                            oCategoria.unidad_medida= Convert.ToString(dr["unIdad_medIda"]);
                            oCategoria.fecha_ingreso = Convert.ToString(dr["fecha_Ingreso"]);





                            lista.Add(oCategoria);
                            oCategoria = null;
                        }
                    }
                    return lista;
                }
            }
        }


        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





        public static bool Eliminar(Entidades.producto pEntidad)
        {

            using (var cn = new SqlConnection(conexion.LeerCC))
            {
                
                using (var cmd = new SqlCommand(@"select id_producto from productos where id_producto=@id_producto;", cn))
                {

                    cmd.Parameters.AddWithValue("ID_PRODUCTO", pEntidad.id_producto);

                    cn.Open();


                    cmd.CommandText = "delete from productos where id_producto=@id_producto;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }


            }

        }


    }
}

