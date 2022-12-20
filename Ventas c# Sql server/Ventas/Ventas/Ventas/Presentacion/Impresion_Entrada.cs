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
    public partial class Impresion_Entrada : Form
    {
        public Impresion_Entrada()
        {
            InitializeComponent();
        }

        private void Impresion_Entrada_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDocument oRep = new ReportDocument();

            ParameterField pf = new ParameterField();


            ParameterFields pfs = new ParameterFields();

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();


            pf.Name = "@v1";

            /////////////////////////////////////////////
            pdv.Value = txtsalida.Text;


            pf.CurrentValues.Add(pdv);

            pfs.Add(pf);

            crystalReportViewer1.ParameterFieldInfo = pfs;





            oRep.Load("C:/Users/juan/Desktop/Ventas C# y Sqlserver/Ventas c# Sql server/Ventas/Ventas/Ventas/Presentacion/Prove_reporte_entrada.rpt");





            crystalReportViewer1.ReportSource = oRep;
        }
    }
}
