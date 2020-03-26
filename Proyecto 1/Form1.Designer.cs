namespace Proyecto_1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pruebaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarLexemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteLexicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteLexemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtConsola = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picAFN = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelAFD = new System.Windows.Forms.Panel();
            this.picAFD = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picTable = new System.Windows.Forms.PictureBox();
            this.tabla = new System.Windows.Forms.Label();
            this.afn = new System.Windows.Forms.Label();
            this.afd = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAFN)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panelAFD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAFD)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.nuevaPestañaToolStripMenuItem,
            this.eliminarPestañaToolStripMenuItem,
            this.pruebaToolStripMenuItem});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            this.nuevaPestañaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nuevaPestañaToolStripMenuItem.Text = "Nueva pestaña";
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.nuevaPestañaToolStripMenuItem_Click);
            // 
            // eliminarPestañaToolStripMenuItem
            // 
            this.eliminarPestañaToolStripMenuItem.Name = "eliminarPestañaToolStripMenuItem";
            this.eliminarPestañaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.eliminarPestañaToolStripMenuItem.Text = "Eliminar pestaña";
            this.eliminarPestañaToolStripMenuItem.Click += new System.EventHandler(this.eliminarPestañaToolStripMenuItem_Click);
            // 
            // pruebaToolStripMenuItem
            // 
            this.pruebaToolStripMenuItem.Name = "pruebaToolStripMenuItem";
            this.pruebaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.pruebaToolStripMenuItem.Text = "Prueba";
            this.pruebaToolStripMenuItem.Click += new System.EventHandler(this.pruebaToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analizarDocumentoToolStripMenuItem,
            this.analizarLexemasToolStripMenuItem,
            this.limpiarProgramaToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // analizarDocumentoToolStripMenuItem
            // 
            this.analizarDocumentoToolStripMenuItem.Name = "analizarDocumentoToolStripMenuItem";
            this.analizarDocumentoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.analizarDocumentoToolStripMenuItem.Text = "Analizar Pestaña";
            this.analizarDocumentoToolStripMenuItem.Click += new System.EventHandler(this.analizarDocumentoToolStripMenuItem_Click);
            // 
            // analizarLexemasToolStripMenuItem
            // 
            this.analizarLexemasToolStripMenuItem.Name = "analizarLexemasToolStripMenuItem";
            this.analizarLexemasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.analizarLexemasToolStripMenuItem.Text = "Analizar Lexemas";
            this.analizarLexemasToolStripMenuItem.Click += new System.EventHandler(this.analizarLexemasToolStripMenuItem_Click);
            // 
            // limpiarProgramaToolStripMenuItem
            // 
            this.limpiarProgramaToolStripMenuItem.Name = "limpiarProgramaToolStripMenuItem";
            this.limpiarProgramaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.limpiarProgramaToolStripMenuItem.Text = "Limpiar programa";
            this.limpiarProgramaToolStripMenuItem.Click += new System.EventHandler(this.limpiarProgramaToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteLexicoToolStripMenuItem,
            this.reporteXMLToolStripMenuItem,
            this.reporteLexemasToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteLexicoToolStripMenuItem
            // 
            this.reporteLexicoToolStripMenuItem.Name = "reporteLexicoToolStripMenuItem";
            this.reporteLexicoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reporteLexicoToolStripMenuItem.Text = "Reporte Lexico";
            this.reporteLexicoToolStripMenuItem.Click += new System.EventHandler(this.reporteLexicoToolStripMenuItem_Click);
            // 
            // reporteXMLToolStripMenuItem
            // 
            this.reporteXMLToolStripMenuItem.Name = "reporteXMLToolStripMenuItem";
            this.reporteXMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reporteXMLToolStripMenuItem.Text = "Reporte XML";
            // 
            // reporteLexemasToolStripMenuItem
            // 
            this.reporteLexemasToolStripMenuItem.Name = "reporteLexemasToolStripMenuItem";
            this.reporteLexemasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reporteLexemasToolStripMenuItem.Text = "Reporte Lexemas";
            this.reporteLexemasToolStripMenuItem.Click += new System.EventHandler(this.reporteLexemasToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(938, 497);
            this.splitContainer1.SplitterDistance = 503;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(503, 497);
            this.splitContainer3.SplitterDistance = 328;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 334);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivos";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 309);
            this.tabControl1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtConsola);
            this.groupBox2.Location = new System.Drawing.Point(0, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 162);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consola";
            // 
            // txtConsola
            // 
            this.txtConsola.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsola.Location = new System.Drawing.Point(0, 19);
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.Size = new System.Drawing.Size(487, 140);
            this.txtConsola.TabIndex = 0;
            this.txtConsola.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer2.Panel1.Controls.Add(this.tabControl2);
            this.splitContainer2.Panel1.Tag = "";
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer2.Panel2.Controls.Add(this.tabla);
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2.Controls.Add(this.button6);
            this.splitContainer2.Panel2.Controls.Add(this.button5);
            this.splitContainer2.Size = new System.Drawing.Size(431, 497);
            this.splitContainer2.SplitterDistance = 306;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(412, 287);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.afn);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(404, 261);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AFN";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picAFN);
            this.panel1.Location = new System.Drawing.Point(29, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 214);
            this.panel1.TabIndex = 5;
            // 
            // picAFN
            // 
            this.picAFN.Location = new System.Drawing.Point(3, 3);
            this.picAFN.Name = "picAFN";
            this.picAFN.Size = new System.Drawing.Size(358, 168);
            this.picAFN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAFN.TabIndex = 4;
            this.picAFN.TabStop = false;
            this.picAFN.Click += new System.EventHandler(this.picAFN_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(386, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(15, 252);
            this.button3.TabIndex = 3;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 252);
            this.button4.TabIndex = 2;
            this.button4.Text = "<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.afd);
            this.tabPage2.Controls.Add(this.panelAFD);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(404, 261);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "AFD";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelAFD
            // 
            this.panelAFD.AutoScroll = true;
            this.panelAFD.Controls.Add(this.picAFD);
            this.panelAFD.Location = new System.Drawing.Point(29, 32);
            this.panelAFD.Name = "panelAFD";
            this.panelAFD.Size = new System.Drawing.Size(339, 223);
            this.panelAFD.TabIndex = 2;
            // 
            // picAFD
            // 
            this.picAFD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAFD.Location = new System.Drawing.Point(-2, 0);
            this.picAFD.Name = "picAFD";
            this.picAFD.Size = new System.Drawing.Size(341, 169);
            this.picAFD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAFD.TabIndex = 2;
            this.picAFD.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(373, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 255);
            this.button2.TabIndex = 1;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 255);
            this.button1.TabIndex = 0;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Archivos ER (*.er)|*.er";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 181);
            this.button5.TabIndex = 0;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(393, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(35, 181);
            this.button6.TabIndex = 1;
            this.button6.Text = ">";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picTable);
            this.panel2.Location = new System.Drawing.Point(36, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 140);
            this.panel2.TabIndex = 2;
            // 
            // picTable
            // 
            this.picTable.Location = new System.Drawing.Point(5, 3);
            this.picTable.Name = "picTable";
            this.picTable.Size = new System.Drawing.Size(353, 175);
            this.picTable.TabIndex = 0;
            this.picTable.TabStop = false;
            // 
            // tabla
            // 
            this.tabla.AutoSize = true;
            this.tabla.Location = new System.Drawing.Point(130, 11);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(0, 13);
            this.tabla.TabIndex = 3;
            // 
            // afn
            // 
            this.afn.AutoSize = true;
            this.afn.Location = new System.Drawing.Point(163, 25);
            this.afn.Name = "afn";
            this.afn.Size = new System.Drawing.Size(0, 13);
            this.afn.TabIndex = 6;
            // 
            // afd
            // 
            this.afd.AutoSize = true;
            this.afd.Location = new System.Drawing.Point(158, 16);
            this.afd.Name = "afd";
            this.afd.Size = new System.Drawing.Size(0, 13);
            this.afd.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 521);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Proyecto1_201709140";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAFN)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panelAFD.ResumeLayout(false);
            this.panelAFD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAFD)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizarDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizarLexemasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limpiarProgramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteLexicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteLexemasToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox txtConsola;
        private System.Windows.Forms.ToolStripMenuItem eliminarPestañaToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem pruebaToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picAFN;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox picAFD;
        private System.Windows.Forms.Panel panelAFD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picTable;
        private System.Windows.Forms.Label tabla;
        private System.Windows.Forms.Label afn;
        private System.Windows.Forms.Label afd;
    }
}

