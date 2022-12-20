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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        //private Entidades.Proveedor regActual;



        private List<Entidades.DetalleVenta> Detalles = new List<Entidades.DetalleVenta>();

        private Entidades.cliente regActual;




        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void Detalle()
        {

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            Int32 i;

            for (i = 0; i < dgDatos.Rows.Count - 1; i++)
            {

                String sql;

                SqlCommand comando;

                sql = "insert into DETALLE_VENTAS(ID_VENTAS,ID_PRODUCTO,DES_PRODUCTO,PRECIO,CANTIDAD,IMPORTE) Values ('" + dgDatos.Rows[i].Cells[0].Value + "','" + dgDatos.Rows[i].Cells[1].Value + "','" + dgDatos.Rows[i].Cells[2].Value + "','" + dgDatos.Rows[i].Cells[3].Value + "','" + dgDatos.Rows[i].Cells[4].Value + "','" + dgDatos.Rows[i].Cells[5].Value + "')";

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

                dataGridView1.DataSource = Negocio.cncliente.Listar(dato);

                dataGridView2.DataSource = Negocio.cnproducto.Listar(dato);


                dataGridView3.DataSource = Negocio.cnformapagos.Listar(dato);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void stock()
        {



            using (SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=SISTEMA_VENTAS;Integrated Security=True"))
            {
                conn.Open();

                string query = "UPDATE Productos SET STOCK_ACTUAL = STOCK_ACTUAL - @cantidad WHERE  ID_PRODUCTO= @ID_PRODUCTO";
                SqlCommand cmd = new SqlCommand(query, conn);


                foreach (DataGridViewRow item in dgDatos.Rows)
                {

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@ID_PRODUCTO", Convert.ToInt32(item.Cells[1].Value));
                    cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(item.Cells[4].Value));

                    cmd.ExecuteNonQuery();

                    //conn.Close();


                }

            }






        }
        public void autogenerar()
        {

            string ca;
            int t;
            SqlConnection miconexion = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            string sql1 = "select ID_VENTAS  from  VENTAS";
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

        private void Ventas_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;


            autogenerar();


        }


        private void limpiar()
        {



            cboproveedor.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            cboproducto.Text = "";
            txtruc.Text = "";

            txtprecio.Text = "";
            txtcodigoproveedor.Text = "";

            txtcodigoproducto.Text = "";
            txtcantidad.Text = "";
            txtimporte.Text = "";
            txtsubtotal.Text = "";
            txtigv.Text = "";
            txttotal.Text = "";
            txtcategoria.Text = "";

            txtcodigoproducto.Text = "";
            txtmarca.Text = "";
            txtcategoria.Text = "";
            txtobservacion.Text = "";
                txtpago.Text = "";
                txtforma.Text = "";



                checkBox1.Checked = false;


        }



        private void Button2_Click(object sender, EventArgs e)
        {


            int rowEscribir = dgDatos.Rows.Count - 1;

            dgDatos.Rows.Add(1);
            dgDatos.Rows[rowEscribir].Cells[0].Value = this.txtfactura.Text;
            dgDatos.Rows[rowEscribir].Cells[1].Value = this.txtcodigoproducto.Text;
            dgDatos.Rows[rowEscribir].Cells[2].Value = this.cboproducto.Text;


            dgDatos.Rows[rowEscribir].Cells[3].Value = this.txtprecio.Text;
            dgDatos.Rows[rowEscribir].Cells[4].Value = this.txtcantidad.Text;
            dgDatos.Rows[rowEscribir].Cells[5].Value = this.txtimporte.Text;


            double sumatoria = 0;
            //Método con el que recorreremos todas las filas de nuestro Datagridview
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                //Aquí seleccionaremos la columna que contiene los datos numericos.
                sumatoria += Convert.ToDouble(row.Cells["importe"].Value);
            }
            //Por ultimo asignamos el resultado a el texto de nuestro Label
            //txtsubtotal.Text = Convert.ToString(sumatoria);

            txtsubtotal.Text = sumatoria.ToString("#0.00");
            ///////////////////////////////////////////////
            //try
            //{


            //int  mostrar;



            //  mostrar = Int32.Parse(txtsubtotal.Text);

            //txtsubtotal.Text = mostrar.ToString("#0.00");


            double igv = (sumatoria * 0.18);


            //txtigv.Text = Convert.ToString(igv);

            txtigv.Text = igv.ToString("#0.00");

            double suma = (sumatoria + igv);


            //txttotal.Text = Convert.ToString(suma);


            txttotal.Text = suma.ToString("#0.00");


            Button3.Enabled = true;

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            var c = new Entidades.Venta();

            try
            {
                //oEntidad.codigo = txtfactura.Text.Trim();


                c.id_Ventas = txtfactura.Text.Trim();


                c.serie = txtserie.Text.Trim();

                c.documento = cbodocumento.Text.Trim();

                c.fecha = dtfecha.Text.Trim();

                c.id_cliente = txtcodigoproveedor.Text.Trim();

                c.cod_usuario = txtcodigousuario.Text.Trim();
                c.id_pago = txtpago.Text.Trim();
                
                c.sub_total = txtsubtotal.Text.Trim();
                c.igv = txtigv.Text.Trim();
                c.total = txttotal.Text.Trim();






                c.Detalles= Detalles;


                //Negocio.cnentrada.Grabar(oEntidad);


                Negocios.Venta.Grabar(c);

                Detalle();







                stock();



                MessageBox.Show("Operación realizada exitosamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar datos
                //dgDatos.DataSource = null;
                //Detalles.Clear();
                //dgDatos.DataSource = Detalles;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                c = null;
            }

            limpiar();

            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;

            autogenerar();

            dgDatos.Rows.Clear();


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

            double sumatoria = 0;
            //Método con el que recorreremos todas las filas de nuestro Datagridview
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                //Aquí seleccionaremos la columna que contiene los datos numericos.
                sumatoria += Convert.ToDouble(row.Cells["importe"].Value);
            }
            //Por ultimo asignamos el resultado a el texto de nuestro Label
            //txtsubtotal.Text = Convert.ToString(sumatoria);

            txtsubtotal.Text = sumatoria.ToString("#0.00");
            ///////////////////////////////////////////////


            double igv = (sumatoria * 0.18);



            txtigv.Text = igv.ToString("#0.00");

            double suma = (sumatoria + igv);



            txttotal.Text = suma.ToString("#0.00");



        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Ventas?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigoproducto.Text = dataGridView2.CurrentRow.Cells["id_producto"].Value.ToString();
            cboproducto.Text = dataGridView2.CurrentRow.Cells["des_producto"].Value.ToString();
            txtprecio.Text = dataGridView2.CurrentRow.Cells["precio_venta"].Value.ToString();
            txtmarca.Text = dataGridView2.CurrentRow.Cells["id_marca"].Value.ToString();
            txtcategoria.Text = dataGridView2.CurrentRow.Cells["stock_actual"].Value.ToString();

            panel2.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigoproveedor.Text = dataGridView1.CurrentRow.Cells["id_cliente"].Value.ToString();
            cboproveedor.Text = dataGridView1.CurrentRow.Cells["clientes"].Value.ToString();
            txtdireccion.Text = dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
            txtruc.Text = dataGridView1.CurrentRow.Cells["tipo_cliente"].Value.ToString();
            txttelefono.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();

            panel1.Visible = false;

        }

        private void txtforma_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Leer(txtbuscar.Text.Trim());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Leer(txtconsulta.Text.Trim());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Leer(txtdescripcion.Text.Trim());
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            txtpago.Text = dataGridView3.CurrentRow.Cells["ID_PAGO"].Value.ToString();
            txtforma.Text = dataGridView3.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
            txtobservacion.Text = dataGridView3.CurrentRow.Cells["OBSERVACION"].Value.ToString();
            panel3.Visible = false;
        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

            //txtcantidad.Text = "";
            txtcantidad.Text = "";
            txtimporte.Text = "";

        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            Button2.Enabled = true;
           
            Button4.Enabled = true;
            try
            {


                decimal a, b, total;




                a = decimal.Parse(txtprecio.Text);
                b = decimal.Parse(txtcantidad.Text);


                total = a * b;

                txtimporte.Text = total.ToString();


            }
            catch (Exception)
            {

            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            double sumatoria = 0;
            //Método con el que recorreremos todas las filas de nuestro Datagridview
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                //Aquí seleccionaremos la columna que contiene los datos numericos.
                sumatoria += Convert.ToDouble(row.Cells["importe"].Value);
            }
            //Por ultimo asignamos el resultado a el texto de nuestro Label
            //txtsubtotal.Text = Convert.ToString(sumatoria);

            txtsubtotal.Text = sumatoria.ToString("#0.00");
            ///////////////////////////////////////////////
            //try
            //{


            //int  mostrar;



            //  mostrar = Int32.Parse(txtsubtotal.Text);

            //txtsubtotal.Text = mostrar.ToString("#0.00");


            double igv = (sumatoria * 0.00);


            //txtigv.Text = Convert.ToString(igv);

            txtigv.Text = igv.ToString("#0.00");

            double suma = (sumatoria + igv);


            //txttotal.Text = Convert.ToString(suma);


            txttotal.Text = suma.ToString("#0.00");


            Button3.Enabled = true;
        }

        private void txtserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           


        }

        private void cbodocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
    }
}
