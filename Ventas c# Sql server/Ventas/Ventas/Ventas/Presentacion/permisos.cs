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
    public partial class permisos : Form
    {
        public permisos()
        {
            InitializeComponent();
        }
        private Entidades.usuario regActual;


        private void button3_Click(object sender, EventArgs e)
        {


            var oEntidad = new Entidades.usuario();
            if (regActual != null)



                oEntidad.cod_usuario= regActual.cod_usuario;



            oEntidad.cod_usuario = txtcodigo.Text.Trim();
            oEntidad.usuarios = txtusuario.Text.Trim();
            oEntidad.contraseña= txtcontraseña.Text.Trim();
            oEntidad.cargo = txtcargo.Text.Trim();





            MessageBox.Show("Registro Ingresado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnusuario.Grabar(oEntidad);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { oEntidad = null; }



            limpiar();
            autogenerar();
        }
        private void limpiar()
        {

            txtcodigo.Text = "";
            txtusuario.Text = "";
            txtcontraseña.Text = "";


                 txtcargo.Text = "";



        }

        private void button6_Click(object sender, EventArgs e)
        {



            var oEntidad = new Entidades.usuario();
            if (regActual != null)



                oEntidad.cod_usuario = regActual.cod_usuario;



            oEntidad.cod_usuario = txtcodigo.Text.Trim();
            oEntidad.usuarios = txtusuario.Text.Trim();
            oEntidad.contraseña = txtcontraseña.Text.Trim();
            oEntidad.cargo = txtcargo.Text.Trim();




            MessageBox.Show("Asido Modificado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnusuario.Grabar(oEntidad);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { oEntidad = null; }


        }

        private void button4_Click(object sender, EventArgs e)
        {

            var oEntidad = new Entidades.usuario();
            //if (regActual != null)

            //oEntidad.id_cliente = regActual.id_cliente;


            oEntidad.cod_usuario= txtcodigo.Text.Trim();



            //try
            //{
            Negocio.cnusuario.Eliminar(oEntidad);




            MessageBox.Show("Se a Eliminado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //try
            //{

            autogenerar();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Usuario?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();

            button6.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = true;
           




            MessageBox.Show("Ingresa los Datos Correctamente", "Informacion de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            autogenerar();
        }

        private void Leer(string dato)
        {
            try
            {

                dataGridView1.DataSource = Negocio.cnusuario.Listar(dato);



            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        

        private void Usuarioss_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();


        }

        public void autogenerar()
        {

            string ca;
            int t;
            SqlConnection miconexion = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            string sql1 = "select COD_USUARIO  from  USUARIOS";
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
        private void button1_Click(object sender, EventArgs e)
        {
            Leer(txtbuscar.Text.Trim());

            button6.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dataGridView1.CurrentRow.Cells["COD_USUARIO"].Value.ToString();
            txtusuario.Text = dataGridView1.CurrentRow.Cells["USUARIOS"].Value.ToString();
            txtcontraseña.Text = dataGridView1.CurrentRow.Cells["CONTRASEÑA"].Value.ToString();
            txtcargo.Text = dataGridView1.CurrentRow.Cells["CARGO"].Value.ToString();

        }
    }
}
