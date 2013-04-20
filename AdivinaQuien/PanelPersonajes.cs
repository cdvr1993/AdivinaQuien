using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class PanelPersonajes : System.Windows.Forms.Panel
    {
        private DisplayPersonaje display = null;
        public PanelPersonajes () { }

        public DisplayPersonaje Display {
            get { return display; }
            set {
                display = value;
                Controls.Add ( display );
            }
        }
    }
}
