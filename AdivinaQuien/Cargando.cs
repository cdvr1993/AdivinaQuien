using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AdivinaQuien
{
    public partial class Cargando : Form
    {
        public Cargando () {
            InitializeComponent ();
            this.Show ();
        }

        public static void cargarVentana () {
            Cargando carga = new Cargando ();
            while (true) {
                Thread.Sleep ( 1000 );
                if (carga.lblCargando.Text.CompareTo ( "Cargando" ) == 0)
                    carga.lblCargando.Text = "Cargando.";
                else if (carga.lblCargando.Text.CompareTo ( "Cargando." ) == 0)
                    carga.lblCargando.Text = "Cargando..";
                else if (carga.lblCargando.Text.CompareTo ( "Cargando.." ) == 0)
                    carga.lblCargando.Text = "Cargando...";
                else
                    carga.lblCargando.Text = "Cargando";
                carga.Refresh ();
            }
        }
    }
}
