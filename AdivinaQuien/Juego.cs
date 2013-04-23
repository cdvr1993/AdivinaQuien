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
            interfaz.pnlSeleccionado.Controls.Add ( new DisplayPersonaje ( Program.personajeElegido, interfaz.pnlSeleccionado.Size, false ) );
            interfaz.pnlMaquina.BackColor = System.Drawing.Color.Gray;
            interfaz.label2.Visible = true;
            interfaz.label3.Visible = true;
            interfaz.gbTurno.Visible = true;
            interfaz.gbRestantes.Visible = true;
            interfaz.agregarPersonajesAleatoriamente ();
            //  Mostramos también la lista de preguntas y su respectivo botón.
            interfaz.lstPreguntas.Show ();
            interfaz.btnPreguntar.Show ();
            agregarPreguntasALaLista ();
            interfaz.AcceptButton = interfaz.btnPreguntar;
            interfaz.lstPreguntas.SelectedIndex = 0;
            VentanaPrincipal.maquina.generarPersonajeDeLaMaquina ();
            escribirRestantes ();
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
                cambiarTurno ();
                Thread movimientoMaquina = new Thread ( VentanaPrincipal.maquina.escogerRespuesta );
                movimientoMaquina.Start ();
                Preguntas tmp = (Preguntas) interfaz.lstPreguntas.SelectedItem;
                Boolean eliminarTodas = false;
                if (tmp.Aprobados.Contains ( VentanaPrincipal.maquina.personajeMaquina )) eliminarTodas = true;
                foreach (PanelPersonajes pnl in interfaz.Paneles) {
                    if (eliminarTodas) {
                        if (!tmp.Aprobados.Contains ( pnl.Persona ))
                            pnl.Display.tacharPersonaje ();
                    } else {
                        if (tmp.Aprobados.Contains ( pnl.Persona ))
                            pnl.Display.tacharPersonaje ();
                    }
                }
                movimientoMaquina.Join ();
                obtenerNumeroTachados ();
                if (eliminarTodas) MessageBox.Show ( "Sí" );
                else MessageBox.Show ( "No" );
                interfaz.lstPreguntas.Items.Clear ();
                Program.copia.encontrarPregunta ( BinaryTreeCategoriasFacil.root , tmp, eliminarTodas );
                foreach (Preguntas p in BinaryTreeCategoriasFacil.obtenerPreguntasDelArbol ()) interfaz.lstPreguntas.Items.Add ( p );
                escribirRestantes ();
            }
            if (interfaz.lstPreguntas.Items.Count > 0)
                interfaz.lstPreguntas.SelectedIndex = 0;
        }

        private void obtenerNumeroTachados () {
            DisplayPersonaje.cantidadDeTachados = 0;
            foreach (PanelPersonajes pnl in interfaz.Paneles) {
                if (pnl.Display.Tachado)
                    DisplayPersonaje.cantidadDeTachados++;
            }
        }

        public void cambiarTurno () {
            interfaz.lblTurno.Text = "" + ++turno;
        }

        public void escribirRestantes () {
            int local = VentanaPrincipal.NUMPANELES - DisplayPersonaje.cantidadDeTachados, maquina = Maquina.seleccionados.Count;
            if (local == 0) ganar ();
            else if (maquina == 0) perder ();
            interfaz.lblLocal.Text = "" + local;
            interfaz.lblMaquina.Text = "" + maquina;
        }

        public void ganar () {
            interfaz.pnlMaquina.Controls.Add ( new DisplayPersonaje ( VentanaPrincipal.maquina.personajeMaquina, interfaz.pnlMaquina.Size ) );
            MessageBox.Show ( "Has ganado!" );
        }

        public void perder () {
            interfaz.pnlMaquina.Controls.Add ( new DisplayPersonaje ( VentanaPrincipal.maquina.personajeMaquina, interfaz.pnlMaquina.Size ) );
            MessageBox.Show ( "Has perdido.... Sigue participando!" );
        }
    }
}
