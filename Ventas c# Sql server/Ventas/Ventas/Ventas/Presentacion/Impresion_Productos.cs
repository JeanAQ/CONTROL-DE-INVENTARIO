using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;



namespace Presentacion
{
    public partial class Impresion_Productos : Form
    {
        public Impresion_Productos()
        {
            InitializeComponent();
        }
        private void Leer(string dato)
        {
            try
            {

            

                dataGridView2.DataSource = Negocio.cnproducto.Listar(dato);

          

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
      
        private void Impresion_Productos_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReportDocument oRep = new ReportDocument();

            ParameterField pf = new ParameterField();


            ParameterFields pfs = new ParameterFields();

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();

       
            pf.Name = "@v1";

            /////////////////////////////////////////////
            pdv.Value = txtconsultar.Text;

            pf.CurrentValues.Add(pdv);

            pfs.Add(pf);

            crystalReportViewer1.ParameterFieldInfo = pfs;

           

            oRep.Load("C:/Users/juan/Desktop/Ventas C# y Sqlserver/Ventas c# Sql server/Ventas/Ventas/Ventas/Presentacion/Prove_reporte_productos.rpt");

           


            crystalReportViewer1.ReportSource = oRep;

          

        }

        private void txtproducto_TextChanged(object sender, EventArgs e)
        {
            Leer(txtproducto.Text.Trim());
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtconsultar.Text = dataGridView2.CurrentRow.Cells["id_producto"].Value.ToString();
            panel1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

            Leer("");
        }
    }
}
