using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
///////////////////////////////////////////////////datos nuevos
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Presentacion
{
    public partial class Impresion_Ventas : Form
    {
        public Impresion_Ventas()
        {
            InitializeComponent();
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





            oRep.Load("C:/Users/juan/Desktop/Ventas C# y Sqlserver/Ventas c# Sql server/Ventas/Ventas/Ventas/Presentacion/Prove_reporte_ventasss.rpt");

           
           


            crystalReportViewer1.ReportSource = oRep;

         
        }

        private void Impresion_Ventas_Load(object sender, EventArgs e)
        {

        }
    }
        }
 