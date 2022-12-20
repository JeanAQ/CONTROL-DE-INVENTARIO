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
    public partial class Impresion_ComprasFechas : Form
    {
        public Impresion_ComprasFechas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string factu = null;



            DataSet dset = new DataSet();

            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");



            string x = dateTimePicker1.Text;
            string xx = dateTimePicker2.Text;


            factu = "select * from COMPRA where FECHA between '" + x + "' and '" + xx + "'";







            SqlDataAdapter fa = new SqlDataAdapter(factu, cn);


            fa.Fill(dset, "COMPRA");




            Prove_reporte_listado_comprass reportar = new Prove_reporte_listado_comprass();



            reportar.SetDataSource(dset);

            crystalReportViewer1.ReportSource = reportar;
        }
    }
}
