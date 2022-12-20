using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Proveedor : Form
    {
        public Proveedor()
        {
            InitializeComponent();
        }
        private Entidades.Proveedor regActual;



        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void autogenerar()
        {

            string ca;
            int t;
            SqlConnection miconexion = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            string sql1 = "select ID_PROVEEDOR  from  PROVEEDOR";
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
            this.txtcodigo.Text = ca;



        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button4.Enabled = false;
            autogenerar();
            Leer(txtbuscar.Text.Trim());
        }
      
        private void button3_Click(object sender, EventArgs e)
        {

            var oEntidad = new Entidades.Proveedor();
            if (regActual != null)



                oEntidad.id_proveedor = regActual.id_proveedor;



            oEntidad.id_proveedor = txtcodigo.Text.Trim();
            oEntidad.des_proveedor = txtproveedor.Text.Trim();
            oEntidad.telefono = txttelefono.Text.Trim();
            oEntidad.direccion = txtdireccion.Text.Trim();
            oEntidad.nombre_banco = txtbanco.Text.Trim();
            oEntidad.numero_cuenta = txtcuenta.Text.Trim();
            oEntidad.rit = txtrit.Text.Trim();
            oEntidad.email = txtemail.Text.Trim();





            MessageBox.Show("Registro Ingresado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnproveedor.Grabar(oEntidad);

                limpiar();
                autogenerar();
                Leer(txtbuscar.Text.Trim());
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { oEntidad = null; }

            limpiar();

            autogenerar();


        }

        private void button4_Click(object sender, EventArgs e)
        {


            var oEntidad = new Entidades.Proveedor();
            //if (regActual != null)

            //oEntidad.id_cliente = regActual.id_cliente;


            oEntidad.id_proveedor = txtcodigo.Text.Trim();



            //try
            //{
            Negocio.cnproveedor.Eliminar(oEntidad);
            limpiar();
            autogenerar();
            Leer(txtbuscar.Text.Trim());




            MessageBox.Show("Se a Eliminado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Proveedor?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }
        private void Leer(string dato)
        {
            try
            {

                dataGridView1.DataSource = Negocio.cnproveedor.Listar(dato);



            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {

            var oEntidad = new Entidades.Proveedor();
            if (regActual != null)



                oEntidad.id_proveedor = regActual.id_proveedor;



            oEntidad.id_proveedor = txtcodigo.Text.Trim();

            oEntidad.des_proveedor = txtproveedor.Text.Trim();

            oEntidad.telefono = txttelefono.Text.Trim();
            oEntidad.direccion = txtdireccion.Text.Trim();
            oEntidad.nombre_banco = txtbanco.Text.Trim();
            oEntidad.numero_cuenta = txtcuenta.Text.Trim();
            oEntidad.rit = txtrit.Text.Trim();
            oEntidad.email = txtemail.Text.Trim();





            MessageBox.Show("Se a Modificado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnproveedor.Grabar(oEntidad);

                limpiar();
                autogenerar();
                Leer(txtbuscar.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { oEntidad = null; }

        }
        private void limpiar()
        {

            txtcodigo.Text = "";
            txtproveedor.Text = "";
            txttelefono.Text = "";
            txtdireccion.Text = "";
            txtbanco.Text = "";
            txtcuenta.Text = "";
            txtemail.Text = "";
            txtrit.Text = "";




        }
        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();

            button3.Enabled = true;

            button6.Enabled = false;
            button4.Enabled =false;
            autogenerar();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Leer(txtbuscar.Text.Trim());

            button6.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dataGridView1.CurrentRow.Cells["id_proveedor"].Value.ToString();
            txtproveedor.Text = dataGridView1.CurrentRow.Cells["DES_PROVEEDOR"].Value.ToString();
            txtdireccion.Text = dataGridView1.CurrentRow.Cells["DIRECCION"].Value.ToString();
            txttelefono.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
            txtbanco.Text = dataGridView1.CurrentRow.Cells["NOMBRE_BANCO"].Value.ToString();
            txtcuenta.Text = dataGridView1.CurrentRow.Cells["NUMERO_CUENTA"].Value.ToString();
            txtrit.Text = dataGridView1.CurrentRow.Cells["RIT"].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells["EMAIL"].Value.ToString();



            button6.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;





        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
