namespace Presentacion
{
    partial class Impresion_Marcas_Catalogos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtconsultar = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(-1, 106);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1139, 684);
            this.crystalReportViewer1.TabIndex = 23;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.button8);
            this.GroupBox1.Controls.Add(this.txtconsultar);
            this.GroupBox1.Controls.Add(this.button6);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(336, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(479, 80);
            this.GroupBox1.TabIndex = 22;
            this.GroupBox1.TabStop = false;
            // 
            // txtconsultar
            // 
            this.txtconsultar.Location = new System.Drawing.Point(153, 29);
            this.txtconsultar.Name = "txtconsultar";
            this.txtconsultar.Size = new System.Drawing.Size(192, 20);
            this.txtconsultar.TabIndex = 75;
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Image = global::Presentacion.Properties.Resources.imprimiendo;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(351, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(118, 59);
            this.button6.TabIndex = 74;
            this.button6.Text = "Imprimir";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 32);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(114, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Catalogo de Marca";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView4);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Location = new System.Drawing.Point(150, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 252);
            this.panel3.TabIndex = 172;
            // 
            // dataGridView4
            // 
            this.dataGridView4.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.GridColor = System.Drawing.Color.White;
            this.dataGridView4.Location = new System.Drawing.Point(15, 40);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(274, 197);
            this.dataGridView4.TabIndex = 36;
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Catologo de Marcas";
            // 
            // button8
            // 
            this.button8.Image = global::Presentacion.Properties.Resources.Find;
            this.button8.Location = new System.Drawing.Point(121, 27);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(26, 23);
            this.button8.TabIndex = 172;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Impresion_Marcas_Catalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1144, 750);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Impresion_Marcas_Catalogos";
            this.Text = "Imprimir Catalogo de Marcas";
            this.Load += new System.EventHandler(this.Impresion_Marcas_Catalogos_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox txtconsultar;
        private System.Windows.Forms.Button button6;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Button button8;
    }
}