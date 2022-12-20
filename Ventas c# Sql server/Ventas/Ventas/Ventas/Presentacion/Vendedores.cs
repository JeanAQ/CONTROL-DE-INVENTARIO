using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Vendedores : Form
    {
        public Vendedores()
        {
            InitializeComponent();
        }

       

       

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedor abrir = new Proveedor();

            abrir.Show();
        }

        private void verProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver_Proveedores abrir = new Ver_Proveedores();

            abrir.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes abrir = new Clientes();

            abrir.Show();
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver_Clientes abrir = new Ver_Clientes();

            abrir.Show();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Productos abrir = new Productos();

            abrir.Show();
        }

        private void imprimirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Impresion_Productos abrir = new Impresion_Productos();

            abrir.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorias abrir = new Categorias();

            abrir.Show();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marcas abrir = new Marcas();

            abrir.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salida abrir = new Salida();

            abrir.Show();
        }

        private void entradaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entrada abrir = new Entrada();

            abrir.Show();
        }

        private void imprimirToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Impresion_salida abrir = new Impresion_salida();

            abrir.Show();
        }

        private void imprimirToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Impresion_Entrada abrir = new Impresion_Entrada();

            abrir.Show();
        }

        private void registrarComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras abrir = new Compras();

            abrir.Show();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impresion_Compras abrir = new Impresion_Compras();

            abrir.Show();
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas abrir = new Ventas();

            abrir.Show();
        }

        private void imprimirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Impresion_Ventas abrir = new Impresion_Ventas();

            abrir.Show();
        }

        private void acercaDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca abrir = new Acerca();

            abrir.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir del Sistema Almacen/Inventarios/Compras/Ventas?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void Vendedores_Load(object sender, EventArgs e)
        {

        }
    }
}
