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
    public partial class Impresion_Marcas_Catalogos : Form
    {
        public Impresion_Marcas_Catalogos()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Leer(string dato)
        {
            try
            {

               

                dataGridView4.DataSource = Negocio.cnmarca.Listar(dato);

              


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

            ReportDocument oRep = new ReportDocument();

            ParameterField pf = new ParameterField();


            ParameterFields pfs = new ParameterFields();

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();


            pf.Name = "@V6";

            /////////////////////////////////////////////
            pdv.Value = txtconsultar.Text;
            /////////////// PERTENECE A LA CAJA DE TEXTO DEL FORMULARIO

            pf.CurrentValues.Add(pdv);

            pfs.Add(pf);

            crystalReportViewer1.ParameterFieldInfo = pfs;




            oRep.Load("C:/Users/juan/Desktop/Ventas C# y Sqlserver/Ventas c# Sql server/Ventas/Ventas/Ventas/Presentacion/Prove_reporte_marca.rpt");






            crystalReportViewer1.ReportSource = oRep;

           
        }

        private void Impresion_Marcas_Catalogos_Load(object sender, EventArgs e)
        {
                           

                           panel3.Visible = false;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtconsultar.Text = dataGridView4.CurrentRow.Cells["nombremarca"].Value.ToString();

            panel3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Leer("");
            panel3.Visible = true;
        }
    }
}
