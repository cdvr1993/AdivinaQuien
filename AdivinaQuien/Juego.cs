using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdivinaQuien
{
    public class Juego
    {
        private VentanaPrincipal interfaz = null;
        public Juego ( VentanaPrincipal interfaz ) {
            this.interfaz = interfaz;
        }

        public void start (int id) {
            //Limpiamos la pantalla de Selección
            interfaz.lstPersonajes.Dispose ();
            interfaz.btnAceptar.Dispose ();
            interfaz.cbDificultad.Dispose ();
            interfaz.label1.Dispose ();
            //A partir de aquí comenzará el juego.
            Program.personajeElegido = Program.personajes[id];
            interfaz.agregarPersonajesAleatoriamente ();
            //  Mostramos también la lista de preguntas y su respectivo botón.
            interfaz.lstPreguntas.Show ();
            interfaz.btnPreguntar.Show ();
            agregarPreguntasALaLista ();
          
        }

        public void agregarPreguntasALaLista () {
            foreach (Categorias c in Program.categorias) {
                foreach (Preguntas p in c.Preguntas)
                    interfaz.lstPreguntas.Items.Add ( p );
            }
        }

        public void preguntar () {
            if (interfaz.lstPreguntas.SelectedIndex == -1)
                MessageBox.Show ( "Debe de seleccionar una pregunta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            else {
                interfaz.lstPreguntas.Items.RemoveAt ( interfaz.lstPreguntas.SelectedIndex );
            }
            interfaz.lstPreguntas.SelectedIndex = -1;
        }
    }
}
