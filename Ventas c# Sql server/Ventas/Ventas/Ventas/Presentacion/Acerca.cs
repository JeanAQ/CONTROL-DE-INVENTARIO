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
    public partial class Acerca : Form
    {
        public Acerca()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("¿Desea Salir de Informe de Sistema?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        
        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }
    }
}
