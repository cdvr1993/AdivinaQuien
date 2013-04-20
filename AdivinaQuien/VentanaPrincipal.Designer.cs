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
            this.lstPersonajes = new System.Windows.Forms.ListBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.cbDificultad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstPreguntas = new System.Windows.Forms.ListBox();
            this.btnPreguntar = new System.Windows.Forms.Button();
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
            this.pnlSelection.Location = new System.Drawing.Point(563, 4);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(227, 296);
            this.pnlSelection.TabIndex = 2;
            // 
            // cbDificultad
            // 
            this.cbDificultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDificultad.FormattingEnabled = true;
            this.cbDificultad.Items.AddRange(new object[] {
            "Fácil",
            "Normal"});
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
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.btnPreguntar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDificultad);
            this.Controls.Add(this.pnlSelection);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lstPersonajes);
            this.Controls.Add(this.lstPreguntas);
            this.Name = "VentanaPrincipal";
            this.Text = "Adivina Quién";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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




    }
}

