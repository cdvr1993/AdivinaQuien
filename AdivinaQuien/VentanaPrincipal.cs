using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdivinaQuien
{
    public partial class VentanaPrincipal : Form
    {
        private List<Panel> paneles = new List<Panel>();
        private List<Personaje> agregados = new List<Personaje> ();
        private const int NUMPANELES = 24;
        public VentanaPrincipal () {
            InitializeComponent ();
            generarPaneles ();
            foreach (Personaje p in Program.personajes)
                lstPersonajes.Items.Add ( p.Nombre );
            String salida = "";
            foreach (Personaje p in Program.categorias[0][2].Aprobados)
                salida += p.Nombre + "\n";
            MessageBox.Show ( salida );
        }

        private void generarPaneles () {
            Point pos = new Point ( 20, 12 );
            for (int i = 0, x = 100, y = 140 ; i < NUMPANELES ; i++) {
                paneles.Add ( new Panel () );
                paneles[i].Location = pos;
                paneles[i].Name = "pnl" + i;
                paneles[i].Size = new Size ( x, y );
                paneles[i].TabIndex = i;
                this.Controls.Add ( paneles[i] );
                //  Cambiamos unicamente la posición para que no se sobreescriban.
                pos = new Point ( paneles[i].Bounds.X + paneles[i].Width + 10, paneles[i].Bounds.Y );
                if ((pos.X + x) > 1366)
                    pos = new Point ( paneles[0].Bounds.X, 12 + y + 10 );
            }
        }

        private void iniciarJuego (int id) {
            //Limpiamos la pantalla de Selección
            lstPersonajes.Dispose ();
            btnAceptar.Dispose ();
            //A partir de aquí comenzará el juego.
            Program.personajeElegido = Program.personajes[id];
            agregarPersonajesAleatoriamente ();
        }

        private void agregarPersonajesAleatoriamente () {
            Random r = new Random ( System.DateTime.Now.Millisecond );
            for (int i = 0, index = 0 ; i < NUMPANELES ; i++) {
                do {
                    index = r.Next ( Program.personajes.Count );
                } while (Program.personajeElegido.Equals ( Program.personajes[index] ) || agregados.Contains ( Program.personajes[index] ));
                paneles[i].Controls.Add ( new DisplayPersonaje ( Program.personajes[index], paneles[i].Size ) );
                agregados.Add ( Program.personajes[index] );
            }
        }

        private void btnAceptar_Click ( object sender, EventArgs e ) {
            iniciarJuego ( lstPersonajes.SelectedIndex );
        }
    }
}
