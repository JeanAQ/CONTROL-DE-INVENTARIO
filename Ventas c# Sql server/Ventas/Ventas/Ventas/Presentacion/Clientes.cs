using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;


using System.Configuration;

using System.Data.SqlClient;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private Entidades.cliente regActual;

        

        private void Clientes_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
                button4.Enabled=false;


                //MaxCod();

                autogenerar();

          
            Leer(txtbuscar.Text.Trim());

        }


        public int MaxCod()
        {
            string sql = @"SELECT MAX(ID_CLIENTE) FROM CLIENTE";


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["base"].ToString()))


        
            {
         

                SqlCommand command = new SqlCommand(sql, conn);

                conn.Open();
                //conn.Close();
                return Convert.ToInt32(command.ExecuteScalar());

            }
        }



        public void autogenerar()
        {

            string ca;
            int t;
            SqlConnection miconexion = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            string sql1 = "select ID_CLIENTE  from  CLIENTE";
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



        private void Leer(string dato)
        {
            try
            {

                dataGridView1.DataSource = Negocio.cncliente.Listar(dato);

              

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void limpiar()
         {

             txtcodigo.Text = "";
             txtcliente.Text = "";
             txttelefono.Text = "";
             txtdireccion.Text = "";
             txttipo.Text = "";
             txtnumero.Text = "";
             txtemail.Text = "";

             autogenerar();




        }
        private void button3_Click(object sender, EventArgs e)
        {

            var oEntidad = new Entidades.cliente();
            if (regActual != null)



               oEntidad.id_cliente= regActual.id_cliente;



            oEntidad.id_cliente  = txtcodigo.Text.Trim();
            oEntidad.clientes = txtcliente.Text.Trim();
            oEntidad.telefono = txttelefono.Text.Trim();
            oEntidad.direccion = txtdireccion.Text.Trim();
            oEntidad.tipo_cliente = txttipo.Text.Trim();
            oEntidad.numero_registro = txtnumero.Text.Trim();
            oEntidad.email = txtemail.Text.Trim();
            




            MessageBox.Show("Registro Ingresado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cncliente.Grabar(oEntidad);
                limpiar();
                Leer(txtbuscar.Text.Trim());

                autogenerar();

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

            var oEntidad = new Entidades.cliente();
            //if (regActual != null)

            //oEntidad.id_cliente = regActual.id_cliente;


            oEntidad.id_cliente = txtcodigo.Text.Trim();



            //try
            //{
            Negocio.cncliente.Eliminar(oEntidad);




            MessageBox.Show("Se a Eliminado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //try
            //{
            //    Negocio.cncliente.Grabar(oEntidad);

            limpiar();
            Leer(txtbuscar.Text.Trim());

            autogenerar();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //finally { oEntidad = null; }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            var oEntidad = new Entidades.cliente();
            if (regActual != null)



                oEntidad.id_cliente = regActual.id_cliente;



            oEntidad.id_cliente = txtcodigo.Text.Trim();
            oEntidad.clientes = txtcliente.Text.Trim();
            oEntidad.telefono = txttelefono.Text.Trim();
            oEntidad.direccion = txtdireccion.Text.Trim();
            oEntidad.tipo_cliente = txttipo.Text.Trim();
            oEntidad.numero_registro = txtnumero.Text.Trim();
            oEntidad.email = txtemail.Text.Trim();





            MessageBox.Show("Se a Modificado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cncliente.Grabar(oEntidad);
                limpiar();
                Leer(txtbuscar.Text.Trim());

                autogenerar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { oEntidad = null; }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtcodigo.Text = "";
            txtcliente.Text = "";
            txttelefono.Text = "";
            txtdireccion.Text = "";
            txttipo.Text = "";
            txtnumero.Text = "";
            txtemail.Text = "";
            button6.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = true;
            //dataGridView1.Rows.Clear();
            MessageBox.Show("Ingresa los Datos Correctamente", "Informacion de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            autogenerar();
            limpiar();
            Leer(txtbuscar.Text.Trim());

            autogenerar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Leer(txtbuscar.Text.Trim());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtcodigo.Text = dataGridView1.CurrentRow.Cells["ID_CLIENTE"].Value.ToString();
            txtcliente.Text = dataGridView1.CurrentRow.Cells["CLIENTES"].Value.ToString();
            txtdireccion.Text = dataGridView1.CurrentRow.Cells["DIRECCION"].Value.ToString();
            txttelefono.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
            txttipo.Text = dataGridView1.CurrentRow.Cells["TIPO_CLIENTE"].Value.ToString();
            txtnumero.Text = dataGridView1.CurrentRow.Cells["NUMERO_REGISTRO"].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells["EMAIL"].Value.ToString();
            button6.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;
        }
    }
}
