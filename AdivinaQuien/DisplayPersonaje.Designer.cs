namespace AdivinaQuien
{
    partial class DisplayPersonaje
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent () {
            this.lblNombre = new System.Windows.Forms.Label();
            this.pnlCruz = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.SystemColors.Window;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(27, 130);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "label1";
            // 
            // pnlCruz
            // 
            this.pnlCruz.Location = new System.Drawing.Point(0, 0);
            this.pnlCruz.Name = "pnlCruz";
            this.pnlCruz.Size = new System.Drawing.Size(116, 130);
            this.pnlCruz.TabIndex = 1;
            this.pnlCruz.Visible = false;
            this.pnlCruz.Click += new System.EventHandler(this.pnlCruz_Click);
            // 
            // DisplayPersonaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlCruz);
            this.Controls.Add(this.lblNombre);
            this.Name = "DisplayPersonaje";
            this.Size = new System.Drawing.Size(117, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel pnlCruz;

    }
}
