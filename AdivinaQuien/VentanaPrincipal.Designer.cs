namespace AdivinaQuien
{
    partial class VentanaPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose ( bool disposing ) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.lstPersonajes = new System.Windows.Forms.ListBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.gbRestantes = new System.Windows.Forms.GroupBox();
            this.gbResMaq = new System.Windows.Forms.GroupBox();
            this.lblMaquina = new System.Windows.Forms.Label();
            this.gbResLocal = new System.Windows.Forms.GroupBox();
            this.lblLocal = new System.Windows.Forms.Label();
            this.gbTurno = new System.Windows.Forms.GroupBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cbDificultad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstPreguntas = new System.Windows.Forms.ListBox();
            this.btnPreguntar = new System.Windows.Forms.Button();
            this.pnlSeleccionado = new System.Windows.Forms.Panel();
            this.pnlMaquina = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSelection.SuspendLayout();
            this.gbRestantes.SuspendLayout();
            this.gbResMaq.SuspendLayout();
            this.gbResLocal.SuspendLayout();
            this.gbTurno.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPersonajes
            // 
            this.lstPersonajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPersonajes.FormattingEnabled = true;
            this.lstPersonajes.ItemHeight = 16;
            this.lstPersonajes.Location = new System.Drawing.Point(543, 319);
            this.lstPersonajes.Name = "lstPersonajes";
            this.lstPersonajes.Size = new System.Drawing.Size(270, 244);
            this.lstPersonajes.TabIndex = 0;
            this.lstPersonajes.SelectedIndexChanged += new System.EventHandler(this.lstPersonajes_SelectedIndexChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(630, 571);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 36);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // pnlSelection
            // 
            this.pnlSelection.Controls.Add(this.gbRestantes);
            this.pnlSelection.Controls.Add(this.gbTurno);
            this.pnlSelection.Location = new System.Drawing.Point(563, 4);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(227, 296);
            this.pnlSelection.TabIndex = 2;
            // 
            // gbRestantes
            // 
            this.gbRestantes.Controls.Add(this.gbResMaq);
            this.gbRestantes.Controls.Add(this.gbResLocal);
            this.gbRestantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRestantes.Location = new System.Drawing.Point(15, 152);
            this.gbRestantes.Name = "gbRestantes";
            this.gbRestantes.Size = new System.Drawing.Size(198, 136);
            this.gbRestantes.TabIndex = 1;
            this.gbRestantes.TabStop = false;
            this.gbRestantes.Text = "Restantes";
            this.gbRestantes.Visible = false;
            // 
            // gbResMaq
            // 
            this.gbResMaq.Controls.Add(this.lblMaquina);
            this.gbResMaq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResMaq.Location = new System.Drawing.Point(107, 25);
            this.gbResMaq.Name = "gbResMaq";
            this.gbResMaq.Size = new System.Drawing.Size(81, 91);
            this.gbResMaq.TabIndex = 3;
            this.gbResMaq.TabStop = false;
            this.gbResMaq.Text = "Máquina";
            // 
            // lblMaquina
            // 
            this.lblMaquina.AutoSize = true;
            this.lblMaquina.Font = new System.Drawing.Font("Baskerville Old Face", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaquina.Location = new System.Drawing.Point(20, 30);
            this.lblMaquina.Name = "lblMaquina";
            this.lblMaquina.Size = new System.Drawing.Size(38, 43);
            this.lblMaquina.TabIndex = 2;
            this.lblMaquina.Text = "0";
            // 
            // gbResLocal
            // 
            this.gbResLocal.Controls.Add(this.lblLocal);
            this.gbResLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResLocal.Location = new System.Drawing.Point(10, 25);
            this.gbResLocal.Name = "gbResLocal";
            this.gbResLocal.Size = new System.Drawing.Size(85, 91);
            this.gbResLocal.TabIndex = 2;
            this.gbResLocal.TabStop = false;
            this.gbResLocal.Text = "Player";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Font = new System.Drawing.Font("Baskerville Old Face", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocal.Location = new System.Drawing.Point(19, 30);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(38, 43);
            this.lblLocal.TabIndex = 1;
            this.lblLocal.Text = "0";
            // 
            // gbTurno
            // 
            this.gbTurno.Controls.Add(this.lblTurno);
            this.gbTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTurno.Location = new System.Drawing.Point(25, 10);
            this.gbTurno.Name = "gbTurno";
            this.gbTurno.Size = new System.Drawing.Size(178, 136);
            this.gbTurno.TabIndex = 0;
            this.gbTurno.TabStop = false;
            this.gbTurno.Text = "Nº de turno";
            this.gbTurno.Visible = false;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Baskerville Old Face", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.Location = new System.Drawing.Point(68, 48);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(38, 43);
            this.lblTurno.TabIndex = 0;
            this.lblTurno.Text = "0";
            // 
            // cbDificultad
            // 
            this.cbDificultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDificultad.FormattingEnabled = true;
            this.cbDificultad.Items.AddRange(new object[] {
            "Fácil",
            "Normal",
            "Difícil"});
            this.cbDificultad.Location = new System.Drawing.Point(846, 341);
            this.cbDificultad.Name = "cbDificultad";
            this.cbDificultad.Size = new System.Drawing.Size(167, 21);
            this.cbDificultad.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(843, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione la dificultad:";
            // 
            // lstPreguntas
            // 
            this.lstPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPreguntas.FormattingEnabled = true;
            this.lstPreguntas.ItemHeight = 15;
            this.lstPreguntas.Location = new System.Drawing.Point(848, 14);
            this.lstPreguntas.Name = "lstPreguntas";
            this.lstPreguntas.Size = new System.Drawing.Size(490, 334);
            this.lstPreguntas.TabIndex = 5;
            this.lstPreguntas.Visible = false;
            // 
            // btnPreguntar
            // 
            this.btnPreguntar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreguntar.Location = new System.Drawing.Point(1226, 352);
            this.btnPreguntar.Name = "btnPreguntar";
            this.btnPreguntar.Size = new System.Drawing.Size(103, 28);
            this.btnPreguntar.TabIndex = 6;
            this.btnPreguntar.Text = "Preguntar";
            this.btnPreguntar.UseVisualStyleBackColor = true;
            this.btnPreguntar.Visible = false;
            this.btnPreguntar.Click += new System.EventHandler(this.btnPreguntar_Click);
            // 
            // pnlSeleccionado
            // 
            this.pnlSeleccionado.Location = new System.Drawing.Point(24, 29);
            this.pnlSeleccionado.Name = "pnlSeleccionado";
            this.pnlSeleccionado.Size = new System.Drawing.Size(227, 296);
            this.pnlSeleccionado.TabIndex = 3;
            // 
            // pnlMaquina
            // 
            this.pnlMaquina.Location = new System.Drawing.Point(283, 29);
            this.pnlMaquina.Name = "pnlMaquina";
            this.pnlMaquina.Size = new System.Drawing.Size(227, 296);
            this.pnlMaquina.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Personaje Escogido";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Personaje de la Computadora";
            this.label3.Visible = false;
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlMaquina);
            this.Controls.Add(this.pnlSeleccionado);
            this.Controls.Add(this.btnPreguntar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDificultad);
            this.Controls.Add(this.pnlSelection);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lstPreguntas);
            this.Controls.Add(this.lstPersonajes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VentanaPrincipal";
            this.Text = "Adivina Quién";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSelection.ResumeLayout(false);
            this.gbRestantes.ResumeLayout(false);
            this.gbResMaq.ResumeLayout(false);
            this.gbResMaq.PerformLayout();
            this.gbResLocal.ResumeLayout(false);
            this.gbResLocal.PerformLayout();
            this.gbTurno.ResumeLayout(false);
            this.gbTurno.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnAceptar;
        internal System.Windows.Forms.ListBox lstPersonajes;
        internal System.Windows.Forms.Panel pnlSelection;
        internal System.Windows.Forms.ComboBox cbDificultad;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnPreguntar;
        internal System.Windows.Forms.ListBox lstPreguntas;
        internal System.Windows.Forms.Panel pnlSeleccionado;
        internal System.Windows.Forms.Panel pnlMaquina;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.GroupBox gbTurno;
        internal System.Windows.Forms.Label lblTurno;
        internal System.Windows.Forms.GroupBox gbRestantes;
        internal System.Windows.Forms.GroupBox gbResMaq;
        internal System.Windows.Forms.Label lblMaquina;
        internal System.Windows.Forms.GroupBox gbResLocal;
        internal System.Windows.Forms.Label lblLocal;




    }
}

