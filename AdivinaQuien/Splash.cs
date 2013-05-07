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
    public partial class Splash : Form{
        public static Boolean mostrar = true;
        public Splash () {
            InitializeComponent ();
            Image imagen = Image.FromFile ( "Images/Splash.png" );
            BackgroundImage = imagen;
            this.Size = imagen.Size;
        }
    }
}
