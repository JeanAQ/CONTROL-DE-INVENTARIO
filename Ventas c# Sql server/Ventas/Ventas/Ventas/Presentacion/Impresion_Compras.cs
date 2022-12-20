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
    public partial class Impresion_Compras : Form
    {
        public Impresion_Compras()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

             ReportDocument oRep = new ReportDocument();

            ParameterField pf = new ParameterField();


            ParameterFields pfs = new ParameterFields();

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();

           
            pf.Name = "@V1";

            /////////////////////////////////////////////
            pdv.Value = txtconsultar.Text;
            /////////////// PERTENECE A LA CAJA DE TEXTO DEL FORMULARIO

            pf.CurrentValues.Add(pdv);

            pfs.Add(pf);

            crystalReportViewer1.ParameterFieldInfo = pfs;




            oRep.Load("C:/Users/juan/Desktop/Ventas C# y Sqlserver/Ventas c# Sql server/Ventas/Ventas/Ventas/Presentacion/Prove_reporte_compras.rpt");

           

          


            crystalReportViewer1.ReportSource = oRep;

           
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
        


        }
    