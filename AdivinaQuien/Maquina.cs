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
        public Personaje personajeMaquina = null;
        public Preguntas preguntaActual = null;
        public List<Categorias> copiaDeCategorias = null;
        public static List<Personaje> seleccionados;
        public Maquina ( int dificultad, BinaryTree.Node copia) {
            this.dificultad = dificultad;
            if (dificultad == 1) {
                copiaDeCategorias = new List<Categorias> ( Program.categorias );
                BinaryTreeCategoriaMedia.root = BinaryTreeCategoriaMedia.arbolMedia ( copiaDeCategorias );
            }
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
            if (dificultad == 0) respuestaFacil ();
            else if (dificultad == 1) respuestaNormal ();
        }

        public void respuestaFacil () {
            Random r = new Random ( DateTime.Now.Millisecond );
            int count = 0, i = 0;
            Program.copia.Count ( Program.copia, ref count );
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

        public void respuestaNormal () {
            Random r = new Random ( DateTime.Now.Millisecond );
            int count = 0, i = 0;
            count = BinaryTreeCategoriaMedia.Recursiones;

        }
    }
}
