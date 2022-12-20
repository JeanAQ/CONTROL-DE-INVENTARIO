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
    public partial class Impresion_Productos_Catoalogos : Form
    {
        public Impresion_Productos_Catoalogos()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {


            ReportDocument oRep = new ReportDocument();

            ParameterField pf = new ParameterField();


            ParameterFields pfs = new ParameterFields();

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();


            pf.Name = "@V7";

            /////////////////////////////////////////////
            pdv.Value = txtconsultar.Text;
            /////////////// PERTENECE A LA CAJA DE TEXTO DEL FORMULARIO

            pf.CurrentValues.Add(pdv);

            pfs.Add(pf);

            crystalReportViewer1.ParameterFieldInfo = pfs;




            oRep.Load("C:/Users/juan/Desktop/Ventas C# y Sqlserver/Ventas c# Sql server/Ventas/Ventas/Ventas/Presentacion/Prove_reporte_Categorias.rpt");






            crystalReportViewer1.ReportSource = oRep;

           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Leer("");
            panel3.Visible = true;
        }
        private void Leer(string dato)
        {
            try
            {



                dataGridView4.DataSource = Negocio.cncategoria.Listar(dato);




            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Impresion_Productos_Catoalogos_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtconsultar.Text = dataGridView4.CurrentRow.Cells["nombrecategoria"].Value.ToString();

            panel3.Visible = false;
        }
    }
}
