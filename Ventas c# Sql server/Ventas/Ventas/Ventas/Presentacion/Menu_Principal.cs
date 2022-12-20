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
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void balanceDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

  Proveedor abrir = new  Proveedor  ();

            abrir.Show();


        }

        private void entradaDeAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Compras abrir = new Compras();

            abrir.Show();
        }

        //private void tipoDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        //{


            
        //}

        private void costroDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

           


        }

        private void pagoDeProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void reporteProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            impresion_proveedores abrir = new impresion_proveedores();

            abrir.Show();


        }

        private void reporteDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Impresion_Compras_list abrir = new    Impresion_Compras_list();

            abrir.Show();
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {

        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas abrir = new Ventas();

            abrir.Show();
        }

        private void mercanciaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes abrir = new Clientes();

            abrir.Show();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

             Productos abrir = new  Productos();

            abrir.Show();

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorias  abrir = new Categorias();

            abrir.Show();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marcas abrir = new Marcas();

            abrir.Show();
        }

        private void imprimirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Impresion_Productos abrir = new Impresion_Productos();

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

        private void acercaDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Acerca abrir = new Acerca();

            abrir.Show();
        }

        private void reporteVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impresion_Ventass_list abrir = new Impresion_Ventass_list();



            abrir.Show();
        }

        private void reporteProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Impresion_productosss abrir = new Impresion_productosss();

            abrir.Show();


        }

        private void reporteClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impresion_clientes abrir = new Impresion_clientes();

            abrir.Show();

        }

        private void personalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Personall abrir = new Personall();

            abrir.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            permisos abrir = new permisos();

            abrir.Show();
        }

        private void verProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver_Proveedores abrir = new Ver_Proveedores();

            abrir.Show();
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver_Clientes abrir = new Ver_Clientes();

            abrir.Show();
        }

        private void imprimirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Impresion_Ventas abrir = new Impresion_Ventas();

            abrir.Show();
        }

        private void verProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impresion_Marcas_Catalogos abrir = new Impresion_Marcas_Catalogos();

            abrir.Show();
        }

        private void catalogoProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impresion_Productos_Catoalogos abrir = new Impresion_Productos_Catoalogos();

            abrir.Show();


        }

        private void porFechasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Impresion_ComprasFechas abrir = new Impresion_ComprasFechas();

            abrir.Show();

        }

        private void porFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Impresion_VentasFechas abrir = new Impresion_VentasFechas();

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

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      
       
    }
}
