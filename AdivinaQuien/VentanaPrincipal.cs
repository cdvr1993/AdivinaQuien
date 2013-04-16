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
        public VentanaPrincipal () {
            InitializeComponent ();
            foreach (Personaje p in Program.personajes)
                listBox1.Items.Add ( p.Nombre );
        }
    }
}
