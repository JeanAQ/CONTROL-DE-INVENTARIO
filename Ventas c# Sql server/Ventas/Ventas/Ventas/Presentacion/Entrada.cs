using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Data.SqlClient;


namespace Presentacion
{
    public partial class Entrada : Form
    {

        //private List<Entidades.DetalleEntrada  Detalles = new List<Entidades.DetalleEntrada>();


        //private Entidades.Proveedor regActual;


        private Entidades.entradas regActual;


        public Entrada()
        {
            InitializeComponent();
        }

       


        private void Entrada_Load(object sender, EventArgs e)
        {
             panel1.Visible = false;
            panel2.Visible = false;
      
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;


            autogenerar();
        }
          public void autogenerar()
        {

            string ca;
            int t;
            SqlConnection miconexion = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            string sql1 = "select ID_ENTRADA  from  ENTRADA";
            SqlDataAdapter dacategoria = new SqlDataAdapter(sql1, miconexion);
            DataTable dtcategoria = new DataTable();
            dacategoria.Fill(dtcategoria);
            t = dtcategoria.Rows.Count;
            miconexion.Close();
            ca = (t + 1).ToString();
            do
            {
                ca = "0" + ca;
            } while (ca.Length < 5);
            this.txtfactura.Text = ca;



        }

          private void Detalle()
        {

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            Int32 i;

            for (i = 0; i < dgDatos.Rows.Count - 1; i++)
            {

                String sql;

                SqlCommand comando;

                sql = "insert into DETALLE_ENTRADA(ID_ENTRADA,ID_PRODUCTO,DES_PRODUCTO,CANTIDAD) Values ('" + dgDatos.Rows[i].Cells[0].Value + "','" + dgDatos.Rows[i].Cells[1].Value + "','" + dgDatos.Rows[i].Cells[2].Value + "','" + dgDatos.Rows[i].Cells[3].Value + "')";

                comando = new SqlCommand(sql, conn);
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void Leer(string dato)
        {
            try
            {

                dataGridView1.DataSource = Negocio.cnproveedor.Listar(dato);

                dataGridView2.DataSource = Negocio.cnproducto.Listar(dato);


         

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void limpiar()
        {



            cboproveedor.Text = "";
            txtdireccion.Text = "";
            txtruc.Text = "";
            cboproducto.Text = "";
            txtruc.Text = "";
            txtcodfactura.Text = "";

            txtcodigoproveedor.Text = "";

            txtcodigoproducto.Text = "";
            txtcantidad.Text = "";
           
   

            txtcodigoproducto.Text = "";
            txtmarca.Text = "";
            txtcompra.Text = "";
            txtcodfactura.Text = "";
            
            txtobservacion.Text = "";
            txtpago.Text = "";
          txtfactura.Text = "";
txtdestino.Text = "";
txtcompra.Text = "";
txtstock.Text = "";






        }
        private void Button3_Click(object sender, EventArgs e)
        {
            //var c = new Entidades.entrada();

            //try
            //{
            //    //oEntidad.codigo = txtfactura.Text.Trim();


            //    c.id_entrada = txtfactura.Text.Trim();


            //    c.serie = txtserie.Text.Trim();

            //    c.documento = cbodocumento.Text.Trim();

            //    c.fecha = dtfecha.Text.Trim();

            //    c.id_proveedor = txtcodigoproveedor.Text.Trim();


            //    c.n_factura = txtcodfactura.Text.Trim();

            //    c.orden_compra = txtcompra.Text.Trim();
            //    c.destino = txtdestino.Text.Trim();
            //    c.observacion = txtobservacion.Text.Trim();
            //    c.cod_usuario = txtcodigousuario.Text.Trim();





            //    //c.Detalles = Detalles;


            //    //Negocio.cnentrada.Grabar(oEntidad);


            //    Negocios.entrada.Grabar(c);




            var oEntidad = new Entidades.entradas();
            if (regActual != null)



                oEntidad.id_entrada = regActual.id_entrada;



            //oEntidad.id_categoria = txtfo.Text.Trim();
            //oEntidad.nombrecategoria = txtdescripcion.Text.Trim();


            //oEntidad.codigo = txtfactura.Text.Trim();


            oEntidad.id_entrada = txtfactura.Text.Trim();


            oEntidad.serie = txtserie.Text.Trim();

            oEntidad.documento = cbodocumento.Text.Trim();

            oEntidad.fecha = dtfecha.Text.Trim();

            oEntidad.id_proveedor = txtcodigoproveedor.Text.Trim();


            oEntidad.n_factura = txtcodfactura.Text.Trim();

            oEntidad.orden_compra = txtcompra.Text.Trim();
            oEntidad.destino = txtdestino.Text.Trim();
            oEntidad.observacion = txtobservacion.Text.Trim();
            oEntidad.cod_usuario = txtcodigousuario.Text.Trim();
             

      MessageBox.Show("Entrada de Mercaderia realizada exitosamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                Negocio.cnentrada.Grabar(oEntidad);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { oEntidad = null; }



            //limpiar();
            //autogenerar();

                Detalle();











            //    MessageBox.Show("Entrada de Mercaderia realizada exitosamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    // Limpiar datos
            //    //dgDatos.DataSource = null;
            //    //Detalles.Clear();
            //    //dgDatos.DataSource = Detalles;
            //    dgDatos.Rows.Clear();


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    c = null;
            //}

            limpiar();

            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;

            autogenerar();
            dgDatos.Rows.Clear();

        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            Button2.Enabled = true;

            Button4.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            int rowEscribir = dgDatos.Rows.Count - 1;

            dgDatos.Rows.Add(1);
            dgDatos.Rows[rowEscribir].Cells[0].Value = this.txtfactura.Text;
            dgDatos.Rows[rowEscribir].Cells[1].Value = this.txtcodigoproducto.Text;
            dgDatos.Rows[rowEscribir].Cells[2].Value = this.cboproducto.Text;


            dgDatos.Rows[rowEscribir].Cells[3].Value = this.txtcantidad.Text;

            Button3.Enabled = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            int Todo = dgDatos.RowCount; //cuenta todas las filas del dgDatos
            if (Todo >= 1) //las filas del dgDatos tienen que ser mayor o igual a 2 para poder remover
            {
                int Fil = dgDatos.CurrentRow.Index;


                dgDatos.Rows.RemoveAt(dgDatos.CurrentRow.Index);
            }
            else //en caso contrario no remueve la fila
            {
                MessageBox.Show("No Existe Ninguna Detalle!",
                "Aviso", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Salida de Mercaderias?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
              panel2.Visible = true;
            txtcantidad.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
              Leer(txtconsulta.Text.Trim());
        }

        private void button6_Click(object sender, EventArgs e)
        {
             Leer(txtbuscar.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigoproducto.Text = dataGridView2.CurrentRow.Cells["id_producto"].Value.ToString();
            cboproducto.Text = dataGridView2.CurrentRow.Cells["des_producto"].Value.ToString();

            //txtmarca.Text = dataGridView2.CurrentRow.Cells["id_marca"].Value.ToString();
            txtstock.Text = dataGridView2.CurrentRow.Cells["stock_actual"].Value.ToString();

            panel2.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigoproveedor.Text = dataGridView1.CurrentRow.Cells["id_proveedor"].Value.ToString();
            cboproveedor.Text = dataGridView1.CurrentRow.Cells["des_proveedor"].Value.ToString();
            txtdireccion.Text = dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
            txtruc.Text = dataGridView1.CurrentRow.Cells["rit"].Value.ToString();
            

            panel1.Visible = false;
        }
    }
}
