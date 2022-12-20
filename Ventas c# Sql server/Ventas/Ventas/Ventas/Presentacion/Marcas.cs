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
    public partial class Marcas : Form
    {
        public Marcas()
        {
            InitializeComponent();
        }
        private Entidades.marca regActual;


        private void Marcas_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button4.Enabled = false;
            Leer(txtbuscar.Text.Trim());
            autogenerar();

        }
        private void limpiar()
        {

            txtcodigo.Text = "";
            txtdescripcion.Text = "";

            autogenerar();


        }

        public void autogenerar()
        {

            string ca;
            int t;
            SqlConnection miconexion = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            string sql1 = "select ID_MARCA  from  MARCA";
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

                dataGridView1.DataSource = Negocio.cnmarca.Listar(dato);



            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {


            var oEntidad = new Entidades.marca();
            if (regActual != null)



                oEntidad.id_marca = regActual.id_marca;



            oEntidad.id_marca= txtcodigo.Text.Trim();
            oEntidad.nombremarca = txtdescripcion.Text.Trim();





            MessageBox.Show("Registro Ingresado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnmarca.Grabar(oEntidad);
                autogenerar();
                limpiar();
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

            var oEntidad = new Entidades.marca();
            //if (regActual != null)

            //oEntidad.id_cliente = regActual.id_cliente;


            oEntidad.id_marca = txtcodigo.Text.Trim();



            //try
            //{
            Negocio.cnmarca.Eliminar(oEntidad);


            autogenerar();
            limpiar();
            Leer(txtbuscar.Text.Trim());


            MessageBox.Show("Se a Eliminado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //try
            //{
            //    Negocio.cncliente.Grabar(oEntidad);

        }

        private void button5_Click(object sender, EventArgs e) 
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Marca?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        
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
            txtcodigo.Text = dataGridView1.CurrentRow.Cells["ID_MARCA"].Value.ToString();
            txtdescripcion.Text = dataGridView1.CurrentRow.Cells["NOMBREMARCA"].Value.ToString();

            button6.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            var oEntidad = new Entidades.marca();
            if (regActual != null)



                oEntidad.id_marca = regActual.id_marca;



            oEntidad.id_marca = txtcodigo.Text.Trim();
            oEntidad.nombremarca = txtdescripcion.Text.Trim();





            MessageBox.Show("Asido Modificado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnmarca.Grabar(oEntidad);
                autogenerar();
                limpiar();
                Leer(txtbuscar.Text.Trim());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { oEntidad = null; }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            limpiar();
            autogenerar();
            limpiar();
            Leer(txtbuscar.Text.Trim());

            button6.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = true;




            MessageBox.Show("Ingresa los Datos Correctamente", "Informacion de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            autogenerar();
        }
    }
}
