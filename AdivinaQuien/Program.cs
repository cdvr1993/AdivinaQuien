using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AdivinaQuien
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main () {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault ( false );
            Application.Run ( new VentanaPrincipal () );
        }

        static void generarPersonajes () {
            generarCategorias ();
            generarRelaciones ();
        }

        static void generarCategorias () {
        }

        static void generarRelaciones () {
        }

        static void cargarPersonajes () {
        }
    }
}
