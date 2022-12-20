using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

//Imports Negocios
//using Usuarios;
//using Usuarios;


namespace Presentacion

{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {





           

            Usuarios UsuarioOb = new Usuarios();



            
            
       
            UsuarioOb.Usuario = this.TextBox1.Text;
            UsuarioOb.Contraseña = this.TextBox2.Text;

            UsuarioOb.Tipo = this.comboBox1.Text;


            if (UsuarioOb.Buscar() == true)
            {
                if (this.comboBox1.Text == "Administrador")
                {

                    MessageBox.Show(UsuarioOb.Mensaje);

                    Menu_Principal obAdmini = new Menu_Principal();
                    obAdmini.Show();
                    this.Hide();
                    //}

                }

                else if (this.comboBox1.Text == "Vendedor")
                {

                    MessageBox.Show(UsuarioOb.Mensaje);

                    Vendedores odCliente = new Vendedores();
                    odCliente.Show();
                    this.Hide();
                }

            }

            else
            {




                MessageBox.Show(UsuarioOb.Mensaje);


            }



            //System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SISTEMA_VENTAS;Integrated Security=SSPI");

            //conn.Open();
            //SqlCommand consulta = new SqlCommand("select * from USUARIOS where USUARIO= '" + TextBox1.Text + "'and CONTRASEÑA='" + TextBox2.Text + "'", conn);
            //SqlDataReader ejecuta = consulta.ExecuteReader();

            //if (ejecuta.Read() == true)
            //{


            //    progressBar1.Maximum = 100000;

               
            //    progressBar1.Minimum = 0;

               
            //    progressBar1.Value = 10000;

               
               
            //    progressBar1.Step = 1;


            //    for (int i = progressBar1.Minimum; i < progressBar1.Maximum; i = i + progressBar1.Step)
            //    {
                   
            //        progressBar1.PerformStep();



            //    }
               

            //    this.Hide();
            //    Menu_Principal abrir = new Menu_Principal();

              



            //    abrir.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Los Datos Ingresados Son Incorrectos", "Acceso Denegado");

            //    TextBox1.Clear();


            //    TextBox2.Clear();

            //    TextBox1.Focus();


            //    conn.Close();
            //}

        }

        //


        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir del Sistema Almacen/Inventarios/Compras/Ventas?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();






        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.comboBox1.Text = "Administrador";

        }
    }
}
