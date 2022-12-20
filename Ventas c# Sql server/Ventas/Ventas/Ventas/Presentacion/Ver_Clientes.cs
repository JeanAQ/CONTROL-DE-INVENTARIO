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
    public partial class Ver_Clientes : Form
    {
        public Ver_Clientes()
        {
            InitializeComponent();
        }
        private Entidades.cliente regActual;

        private void button1_Click(object sender, EventArgs e)
        {
            Leer(txtbuscar.Text.Trim());

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
        

        private void Ver_Clientes_Load(object sender, EventArgs e)
        {
            Leer(txtbuscar.Text.Trim());
        }
    }
}
