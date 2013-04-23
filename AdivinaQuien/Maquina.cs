using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    public class Maquina
    {
        public int dificultad = 0;
        public BinaryTree.Node clon = null;
        public Personaje personajeMaquina = null;
        public Preguntas preguntaActual = null;
        public static List<Personaje> seleccionados;
        public Maquina ( int dificultad, BinaryTree.Node copia) {
            this.dificultad = dificultad;
            this.clon = copia;
        }

        public void generarPersonajeDeLaMaquina () {
            Random r = new Random ( DateTime.Now.Millisecond );
            do {
                personajeMaquina = VentanaPrincipal.seleccionados[r.Next ( VentanaPrincipal.seleccionados.Count )];
            } while (personajeMaquina == Program.personajeElegido);
        }

        public void escogerRespuesta () {
            if (seleccionados.Count == 1) {
                seleccionados.RemoveAt ( 0 );
                return;
            }
            Random r = new Random(DateTime.Now.Millisecond);
            int count = 0, i = 0;
            Program.copia.Count(Program.copia, ref count);
            Program.copia.encontrarPreguntaAleatoria ( r.Next ( count ), ref i, Program.copia );
            Boolean eliminarTodas = false;
            if (preguntaActual.Aprobados.Contains ( personajeMaquina )) eliminarTodas = true;
            List<Personaje> tmp = new List<Personaje> ( seleccionados );
            foreach (Personaje p in tmp) {
                if (eliminarTodas) {
                    if (!preguntaActual.Aprobados.Contains ( p )) seleccionados.Remove ( p );
                } else {
                    if (preguntaActual.Aprobados.Contains ( p )) seleccionados.Remove ( p );
                }
            }
        }
    }
}
