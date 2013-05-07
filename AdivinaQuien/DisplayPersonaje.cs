using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AdivinaQuien
{
    public partial class DisplayPersonaje : UserControl
    {
        public Boolean activado = true;
        public Boolean tachado = false;
        public static int cantidadDeTachados = 0;
        private Personaje personaje;

        public DisplayPersonaje ( Personaje p, Size parentSize, Boolean activado ) {
            this.activado = activado;
            init ( p, parentSize );
        }

        public DisplayPersonaje (Personaje p, Size parentSize) {
            init ( p, parentSize );
        }

        private void init(Personaje p, Size parentSize) {
            InitializeComponent ();
            this.personaje = p;
            this.Size = parentSize;
            Image background = Image.FromFile ( "Images/" + p.Nombre + ".jpg" );
            lblNombre.Text = p.Nombre;
            this.BackgroundImage = background;
            int x = (parentSize.Width / 2) - (lblNombre.Width / 2);
            for (float size = lblNombre.Font.Size - (float)0.5 ; x < 0 ; x = (parentSize.Width / 2) - (lblNombre.Width / 2)) {
                this.lblNombre.Font = new System.Drawing.Font ( "Microsoft Sans Serif", size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)) );
                size -= (float) 0.5;
            }
            lblNombre.Location = new Point ( x, parentSize.Height - lblNombre.Height );
        }

        public void tacharPersonaje () {
            Image background = Image.FromFile ( "Images/tache.jpg" );
            pnlCruz.BackgroundImage = background;
            pnlCruz.Visible = true;
            tachado = true;
        }

        public Personaje Persona {
            get { return this.personaje; }
        }

        public Boolean Tachado {
            set { this.tachado = value; }
            get { return this.tachado; }
        }

        private void DisplayPersonaje_Click ( object sender, EventArgs e ) {
            if (activado) {
                if (!tachado) {
                    if ((VentanaPrincipal.NUMPANELES - cantidadDeTachados) > 6) {
                        if (MessageBox.Show ( "¿Seguro que desea eliminar por personaje cuando aún quedan tantos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question )
                            == DialogResult.No) return;
                    }
                    VentanaPrincipal.maquina.escogerRespuesta ();
                    if (VentanaPrincipal.maquina.personajeMaquina == this.personaje) VentanaPrincipal.game.ganar ();
                    else this.tacharPersonaje ();
                    if (VentanaPrincipal.game != null) {
                        VentanaPrincipal.game.cambiarTurno ();
                        VentanaPrincipal.game.escribirRestantes ();
                    }
                }
            }
        }
    }
}
