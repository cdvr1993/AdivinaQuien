using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AdivinaQuien
{
    public class Juego
    {
        public static int turno = 0;
        public Juego (  ) {
        }

        public void start (int id) {
            //Limpiamos la pantalla de Selección
            VentanaPrincipal.Interfaz.lstPersonajes.Dispose ();
            VentanaPrincipal.Interfaz.btnAceptar.Dispose ();
            VentanaPrincipal.Interfaz.cbDificultad.Dispose ();
            VentanaPrincipal.Interfaz.label1.Dispose ();
            //A partir de aquí comenzará el juego.
            Program.personajeElegido = Program.personajes[id];
            VentanaPrincipal.Interfaz.pnlSeleccionado.Controls.Add ( new DisplayPersonaje ( Program.personajeElegido, VentanaPrincipal.Interfaz.pnlSeleccionado.Size, false ) );
            VentanaPrincipal.Interfaz.pnlMaquina.BackColor = System.Drawing.Color.Gray;
            VentanaPrincipal.Interfaz.label2.Visible = true;
            VentanaPrincipal.Interfaz.label3.Visible = true;
            VentanaPrincipal.Interfaz.gbTurno.Visible = true;
            VentanaPrincipal.Interfaz.gbRestantes.Visible = true;
            VentanaPrincipal.Interfaz.agregarPersonajesAleatoriamente ();
            //  Mostramos también la lista de preguntas y su respectivo botón.
            VentanaPrincipal.Interfaz.lstPreguntas.Show ();
            VentanaPrincipal.Interfaz.btnPreguntar.Show ();
            agregarPreguntasALaLista ();
            VentanaPrincipal.Interfaz.AcceptButton = VentanaPrincipal.Interfaz.btnPreguntar;
            VentanaPrincipal.Interfaz.lstPreguntas.SelectedIndex = 0;
            VentanaPrincipal.maquina.generarPersonajeDeLaMaquina ();
            escribirRestantes ();
        }

        public void agregarPreguntasALaLista () {
            foreach (Categorias c in Program.categorias) {
                foreach (Preguntas p in c.Preguntas)
                    VentanaPrincipal.Interfaz.lstPreguntas.Items.Add ( p );
            }
        }

        public void preguntar () {
            if (VentanaPrincipal.Interfaz.lstPreguntas.SelectedIndex == -1)
                MessageBox.Show ( "Debe de seleccionar una pregunta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            else {
                //  Cambia el número de turno y lo muestra.
                cambiarTurno ();
                //  Se crea un hilo el cual realizará el movimiento de la máquina.
                Thread movimientoMaquina = new Thread ( VentanaPrincipal.maquina.escogerRespuesta );
                movimientoMaquina.Start ();
                //  Se obtiene la pregunta seleccionada por el usuario.
                Preguntas tmp = (Preguntas) VentanaPrincipal.Interfaz.lstPreguntas.SelectedItem;
                Boolean eliminarTodas = false;
                //  Se obtiene si el personaje de la máquina esta en el SI de la pregunta escogida.
                if (tmp.Aprobados.Contains ( VentanaPrincipal.maquina.personajeMaquina )) eliminarTodas = true;
                //  Se tachan todos los paneles que sean necesarios dependiendo de si se encontro o no al personaje en la pregunta realizada.
                foreach (PanelPersonajes pnl in VentanaPrincipal.Interfaz.Paneles) {
                    if (eliminarTodas) {
                        if (!tmp.Aprobados.Contains ( pnl.Persona ))
                            pnl.Display.tacharPersonaje ();
                    } else {
                        if (tmp.Aprobados.Contains ( pnl.Persona ))
                            pnl.Display.tacharPersonaje ();
                    }
                }
                //  Se finaliza el hilo del movimiento de la máquina y se manda obtener cuantos personajes le quedan a la máquina y al usuario.
                movimientoMaquina.Join ();
                obtenerNumeroTachados ();
                //  Se muestra el mensaje de respuesta a la pregunta seleccionada.
                if (eliminarTodas) MessageBox.Show ( "Sí" );
                else MessageBox.Show ( "No" );
                //  Se limpia la lista y se manda comprobar que preguntas deben ser eliminadas del árbol del usuario para posteriormente desplegarlas.
                VentanaPrincipal.Interfaz.lstPreguntas.Items.Clear ();
                Program.copia.encontrarPregunta ( BinaryTreeCategoriasFacil.root, tmp, eliminarTodas );
                foreach (Preguntas p in BinaryTreeCategoriasFacil.obtenerPreguntasDelArbol ()) VentanaPrincipal.Interfaz.lstPreguntas.Items.Add ( p );
                //  Se despliegan los tachados.
                escribirRestantes ();
            }
            if (VentanaPrincipal.Interfaz.lstPreguntas.Items.Count > 0)
                VentanaPrincipal.Interfaz.lstPreguntas.SelectedIndex = 0;
        }

        private void obtenerNumeroTachados () {
            DisplayPersonaje.cantidadDeTachados = 0;
            foreach (PanelPersonajes pnl in VentanaPrincipal.Interfaz.Paneles) {
                if (pnl.Display.Tachado)
                    DisplayPersonaje.cantidadDeTachados++;
            }
        }

        public void cambiarTurno () {
            VentanaPrincipal.Interfaz.lblTurno.Text = "" + ++turno;
        }

        public void escribirRestantes () {
            int local = VentanaPrincipal.NUMPANELES - DisplayPersonaje.cantidadDeTachados, maquina = Maquina.seleccionados.Count;
            if (local == 0) ganar ();
            else if (maquina == 0) perder ();
            VentanaPrincipal.Interfaz.lblLocal.Text = "" + local;
            VentanaPrincipal.Interfaz.lblMaquina.Text = "" + maquina;
        }

        public void ganar () {
            VentanaPrincipal.Interfaz.pnlMaquina.Controls.Add ( new DisplayPersonaje ( VentanaPrincipal.maquina.personajeMaquina, VentanaPrincipal.Interfaz.pnlMaquina.Size ) );
            MessageBox.Show ( "Has ganado!" );
            jugarDeNuevo ();
        }

        public void perder () {
            VentanaPrincipal.Interfaz.pnlMaquina.Controls.Add ( new DisplayPersonaje ( VentanaPrincipal.maquina.personajeMaquina, VentanaPrincipal.Interfaz.pnlMaquina.Size ) );
            MessageBox.Show ( "Tu personajes es: " + Program.personajeElegido +
                              "\nHas perdido.... Sigue participando!" );
            jugarDeNuevo ();
        }

        private void jugarDeNuevo () {
            if (MessageBox.Show ( "¿Quieres Jugar de nuevo?", "Nuevo Juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) ==
                DialogResult.Yes) Application.Restart ();
            else Application.Exit ();
        }
    }
}
