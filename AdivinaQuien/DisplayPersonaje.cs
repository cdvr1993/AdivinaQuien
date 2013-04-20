using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdivinaQuien
{
    public partial class DisplayPersonaje : UserControl
    {
        private Boolean activado = true;

        public DisplayPersonaje ( Personaje p, Size parentSize, Boolean activado ) {
            this.activado = activado;
            init ( p, parentSize );
        }

        public DisplayPersonaje (Personaje p, Size parentSize) {
            init ( p, parentSize );
        }

        private void init(Personaje p, Size parentSize) {
            InitializeComponent ();
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
        }

        private void pnlCruz_Click ( object sender, EventArgs e ) {

        }
    }
}
