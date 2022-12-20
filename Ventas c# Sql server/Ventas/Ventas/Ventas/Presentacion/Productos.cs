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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private Entidades.producto regActual;


        private void Productos_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button4.Enabled = false;

            panel3.Visible=false;

            panel1.Visible = false;

            panel2.Visible = false;

            Leer(txtbuscar.Text.Trim());
            //limpiar();
        }



       
        


        private void limpiar()
        {

            txtcodigo.Text = "";
            txtproducto.Text = "";
            txtcompra.Text = "";
            txtventa.Text = "";
            txtproveedor.Text = "";
            txtmarca.Text = "";
            txtcategoria.Text = "";
            txtstock.Text = "";
            txtunidad.Text = "";
            txtfecha.Text = "";
            txtproveedores.Text = "";
            txtcategoriass.Text = "";
            txtmarcass.Text = "";

        }
        private void Leer(string dato)
        {
            try
            {

                dataGridView1.DataSource = Negocio.cnproducto.Listar(dato);

                dataGridView2.DataSource = Negocio.cnproveedor.Listar(dato);

                dataGridView4.DataSource = Negocio.cncategoria.Listar(dato);

                dataGridView3.DataSource = Negocio.cnmarca.Listar(dato);


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {


            var oEntidad = new Entidades.producto();
            if (regActual != null)



                oEntidad.id_producto = regActual.id_producto;



            oEntidad.id_producto = txtcodigo.Text.Trim();
            oEntidad.des_producto = txtproducto.Text.Trim();
            oEntidad.precio_compra = txtcompra.Text.Trim();
            oEntidad.precio_venta= txtventa.Text.Trim();
            oEntidad.id_proveedor = txtproveedor.Text.Trim();
            oEntidad.id_marca = txtmarca.Text.Trim();
            oEntidad.id_categoria= txtcategoria.Text.Trim();

            oEntidad.stock_actual= txtstock.Text.Trim();
            oEntidad.unidad_medida = txtunidad.Text.Trim();
            oEntidad.fecha_ingreso = txtfecha.Text.Trim();




            MessageBox.Show("Registro Ingresado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnproducto.Grabar(oEntidad);
                Leer(txtbuscar.Text.Trim());
                limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { oEntidad = null; }



            //limpiar();


        }

        private void button5_Click(object sender, EventArgs e)
        {

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

            txtcodigo.Text = dataGridView1.CurrentRow.Cells["id_producto"].Value.ToString();
            txtproducto.Text = dataGridView1.CurrentRow.Cells["des_producto"].Value.ToString();
            txtcompra.Text = dataGridView1.CurrentRow.Cells["precio_compra"].Value.ToString();
            txtventa.Text = dataGridView1.CurrentRow.Cells["precio_venta"].Value.ToString();
            txtproveedor.Text = dataGridView1.CurrentRow.Cells["id_proveedor"].Value.ToString();
            txtmarca.Text = dataGridView1.CurrentRow.Cells["id_marca"].Value.ToString();
            txtcategoria.Text = dataGridView1.CurrentRow.Cells["id_categoria"].Value.ToString();
            txtstock.Text = dataGridView1.CurrentRow.Cells["stock_actual"].Value.ToString();


            txtunidad.Text = dataGridView1.CurrentRow.Cells["unidad_medida"].Value.ToString();
            txtfecha.Text = dataGridView1.CurrentRow.Cells["fecha_ingreso"].Value.ToString();

            button6.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {



            var oEntidad = new Entidades.producto();
            if (regActual != null)



                oEntidad.id_producto = regActual.id_producto;



            oEntidad.id_producto = txtcodigo.Text.Trim();
            oEntidad.des_producto = txtproducto.Text.Trim();
            oEntidad.precio_compra = txtcompra.Text.Trim();
            oEntidad.precio_venta = txtventa.Text.Trim();
            oEntidad.id_proveedor = txtproveedor.Text.Trim();
            oEntidad.id_marca = txtmarca.Text.Trim();
            oEntidad.id_categoria = txtcategoria.Text.Trim();

            oEntidad.stock_actual = txtstock.Text.Trim();
            oEntidad.unidad_medida = txtunidad.Text.Trim();
            oEntidad.fecha_ingreso = txtfecha.Text.Trim();




            MessageBox.Show("Asido Modificado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Negocio.cnproducto.Grabar(oEntidad);
                Leer(txtbuscar.Text.Trim());
                limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { oEntidad = null; }

        }

        private void button4_Click(object sender, EventArgs e)
        {


            var oEntidad = new Entidades.producto();
            //if (regActual != null)

            //oEntidad.id_cliente = regActual.id_cliente;


            oEntidad.id_producto = txtcodigo.Text.Trim();



            //try
            //{
            Negocio.cnproducto.Eliminar(oEntidad);




            MessageBox.Show("Se a Eliminado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //try
            //{
            //    Negocio.cncliente.Grabar(oEntidad);

            Leer(txtbuscar.Text.Trim());
            limpiar();


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Producto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            button3.Enabled = true;
            Leer(txtbuscar.Text.Trim());
            limpiar();
            button6.Enabled = false;
            button4.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Leer(txtconsultarproveedor.Text.Trim());
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtproveedor.Text = dataGridView2.CurrentRow.Cells["id_proveedor"].Value.ToString();
            txtproveedores.Text = dataGridView2.CurrentRow.Cells["DES_PROVEEDOR"].Value.ToString();

            panel1.Visible = false;

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcategoria.Text = dataGridView4.CurrentRow.Cells["id_categoria"].Value.ToString();
            txtcategoriass.Text = dataGridView4.CurrentRow.Cells["nombrecategoria"].Value.ToString();

            panel3.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Leer(txtconsultarcategoria.Text.Trim());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Leer(txtconsultarmarca.Text.Trim());


        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmarca.Text = dataGridView3.CurrentRow.Cells["id_marca"].Value.ToString();
            txtmarcass.Text = dataGridView3.CurrentRow.Cells["nombremarca"].Value.ToString();

            panel2.Visible = false;
        }
    }
}
