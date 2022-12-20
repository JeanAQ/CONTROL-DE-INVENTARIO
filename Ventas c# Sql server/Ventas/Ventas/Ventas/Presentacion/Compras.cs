using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }
        private List<Entidades.DetalleCompra> Detalles = new List<Entidades.DetalleCompra>();

        private Entidades.Proveedor regActual;

        //private Entidades.producto

        private void Entradas_Load(object sender, EventArgs e)
        {
            //LeerTipo();
            //cboproductos.Text = "";

            //LeerTipos();
            //cboproveedor.Text = "";

            panel1.Visible = false;
            panel2.Visible = false;

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

 txtprecio.Text="";
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

        


        }


        public void stock()
        {



            using (SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=SISTEMA_VENTAS;Integrated Security=True"))
            {
                conn.Open();

                string query = "UPDATE Productos SET STOCK_ACTUAL = STOCK_ACTUAL + @cantidad WHERE  ID_PRODUCTO= @ID_PRODUCTO";
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

            string sql1 = "select ID_COMPRA  from  COMPRA";
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


        private void Detallesss()
        {

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            Int32 i;

            for (i = 0; i < dgDatos.Rows.Count - 1; i++)
            {

                String sql;

                SqlCommand comando;

                sql = "insert into DETALLE_COMPRA(ID_COMPRA,ID_PRODUCTO,DES_PRODUCTO,PRECIO,CANTIDAD,IMPORTE) Values ('" + dgDatos.Rows[i].Cells[0].Value + "','" + dgDatos.Rows[i].Cells[1].Value + "','" + dgDatos.Rows[i].Cells[2].Value + "','" + dgDatos.Rows[i].Cells[3].Value + "','" + dgDatos.Rows[i].Cells[4].Value + "','" + dgDatos.Rows[i].Cells[5].Value + "')";

                comando = new SqlCommand(sql, conn);
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
            }
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

            txtigv.Text =igv.ToString("#0.00");

            double suma = (sumatoria + igv);


            //txttotal.Text = Convert.ToString(suma);


            txttotal.Text = suma.ToString("#0.00");


          
            Button3.Enabled = true;
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            var c = new Entidades.Compra();

            try
            {
                //oEntidad.codigo = txtfactura.Text.Trim();


                c.id_compra = txtfactura.Text.Trim();

                c.serie = txtserie.Text.Trim();

                c.documento = cbodocumento.Text.Trim();

                c.fecha = dtfecha.Text.Trim();

                c.id_proveedor = txtcodigoproveedor.Text.Trim();

                c.cod_usuario = txtcodigousuario.Text.Trim();

                c.sub_total = txtsubtotal.Text.Trim();
             c.igv = txtigv.Text.Trim();
             c.total = txttotal.Text.Trim();






             c.Detalles = Detalles;
               
               

                Negocios.Compra.Grabar(c);

            
                Detallesss();
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
         
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            txtcantidad.Text = "";
            txtimporte.Text = "";


        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {


            Button2.Enabled = true;
          
            Button4.Enabled = true;
            try
            {


               decimal  a, b, total;




                a = decimal.Parse(txtprecio.Text);
                b = decimal.Parse(txtcantidad.Text);


                total = a * b;

                txtimporte.Text = total.ToString();


            }
            catch (Exception)
            {

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //txtfactura.Text = dataGridView1_.Rows(e.RowIndex).Cells(0).Value();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigoproveedor.Text = dataGridView1.CurrentRow.Cells["id_proveedor"].Value.ToString();
            cboproveedor.Text = dataGridView1.CurrentRow.Cells["des_proveedor"].Value.ToString();
            txtdireccion.Text = dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
            txtruc.Text = dataGridView1.CurrentRow.Cells["rit"].Value.ToString();
            txttelefono.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();

            panel1.Visible = false;

           
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
        private void button6_Click(object sender, EventArgs e)
        {
            Leer(txtbuscar.Text.Trim());





        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;

        }
       
        private void button8_Click(object sender, EventArgs e)
        {
            Leer(txtconsulta.Text.Trim());

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            txtcodigoproducto.Text = dataGridView2.CurrentRow.Cells["id_producto"].Value.ToString();
            cboproducto.Text = dataGridView2.CurrentRow.Cells["des_producto"].Value.ToString();
            txtprecio.Text = dataGridView2.CurrentRow.Cells["precio_compra"].Value.ToString();
            txtmarca.Text = dataGridView2.CurrentRow.Cells["id_marca"].Value.ToString();
            txtcategoria.Text = dataGridView2.CurrentRow.Cells["stock_actual"].Value.ToString();

            panel2.Visible = false;



        }

        private void Button5_Click(object sender, EventArgs e)
        {
              DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Compras?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        

        }

       
    }
}
