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
    public partial class Personall : Form
    {
        public Personall()
        {
            InitializeComponent();
        }
        private Entidades.personal regActual;


        private void button3_Click(object sender, EventArgs e)
        {


            var oEntidad = new Entidades.personal();
            if (regActual != null)



                oEntidad.id_personal= regActual.id_personal;



            oEntidad.id_personal= txtcodigo.Text.Trim();
            oEntidad.persona= txtpersonal.Text.Trim();
            oEntidad.direccion= txtdireccion.Text.Trim();
            oEntidad.telefono= txttelefono.Text.Trim();
            oEntidad.id_cargo= txtcodcargo.Text.Trim();
            oEntidad.fecha_ingreso= txtfecha.Text.Trim();
            oEntidad.cod_usuario= txtcodusuario.Text.Trim();





            MessageBox.Show("Registro Ingresado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnpersonal.Grabar(oEntidad);

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

            var oEntidad = new Entidades.personal();
            //if (regActual != null)

            //oEntidad.id_cliente = regActual.id_cliente;


            oEntidad.id_personal = txtcodigo.Text.Trim();



            //try
            //{
            Negocio.cnpersonal.Eliminar(oEntidad);

            limpiar();
            autogenerar();
            Leer(txtbuscar.Text.Trim());



            MessageBox.Show("Se a Eliminado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //try
            //{
            //    Negocio.cncliente.Grabar(oEntidad);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            var oEntidad = new Entidades.personal();
            if (regActual != null)



                oEntidad.id_personal = regActual.id_personal;



            oEntidad.id_personal = txtcodigo.Text.Trim();
            oEntidad.persona = txtpersonal.Text.Trim();
            oEntidad.direccion = txtdireccion.Text.Trim();
            oEntidad.telefono = txttelefono.Text.Trim();
            oEntidad.id_cargo = txtcodcargo.Text.Trim();
            oEntidad.fecha_ingreso = txtfecha.Text.Trim();
            oEntidad.cod_usuario = txtcodusuario.Text.Trim();





            MessageBox.Show("Asido Modificado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnpersonal.Grabar(oEntidad);

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
            txtpersonal.Text = "";
            txttelefono.Text = "";
            txtdireccion.Text = "";
            txtcodcargo.Text = "";
            txtcodusuario.Text = "";
            txtfecha.Text = "";
            txtcargo.Text = "";
            txtusuario.Text = "";


        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Personal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                dataGridView1.DataSource = Negocio.cnpersonal.Listar(dato);

                 dataGridView3.DataSource = Negocio.cnusuario.Listar(dato);

               dataGridView2.DataSource = Negocio.cncargo.Listar(dato);

            }
            catch (Exception ex)
            {
               
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            button6.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = true;

            autogenerar();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dataGridView1.CurrentRow.Cells["ID_PERSONAL"].Value.ToString();
            txtpersonal.Text = dataGridView1.CurrentRow.Cells["PERSONA"].Value.ToString();
            txtdireccion.Text = dataGridView1.CurrentRow.Cells["DIRECCION"].Value.ToString();
            txttelefono.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
            txtcodcargo.Text = dataGridView1.CurrentRow.Cells["ID_CARGO"].Value.ToString();
            txtcodusuario.Text = dataGridView1.CurrentRow.Cells["COD_USUARIO"].Value.ToString();
            txtfecha.Text = dataGridView1.CurrentRow.Cells["FECHA_INGRESO"].Value.ToString();

            button6.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Leer(txtbuscar.Text.Trim());

            button6.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;
        }

        public void autogenerar()
        {

            string ca;
            int t;
            SqlConnection miconexion = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            string sql1 = "select ID_PERSONAL  from  PERSONAL";
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

        private void Personall_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button4.Enabled = false;
            Leer(txtbuscar.Text.Trim());
            panel1.Visible = false;
            panel2.Visible = false;

            autogenerar();

        }


        private void button8_Click(object sender, EventArgs e)
        {
            Leer(txtconsultarusuario.Text.Trim());

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Leer(txtconsultarcargo.Text.Trim());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodcargo.Text = dataGridView2.CurrentRow.Cells["ID_CARGO"].Value.ToString();
            txtcargo.Text = dataGridView2.CurrentRow.Cells["DES_CARGO"].Value.ToString();

            panel1.Visible = false;

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtcodusuario.Text = dataGridView3.CurrentRow.Cells["COD_USUARIO"].Value.ToString();
            txtusuario.Text = dataGridView3.CurrentRow.Cells["USUARIOS"].Value.ToString();


            panel2.Visible = false;
        }
    }
}
