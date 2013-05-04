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
            if (dificultad == 1 || dificultad == 2) copiaDeCategorias = new List<Categorias> ( Program.categorias );
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
            else if (dificultad == 2) respuestaDificil ();
        }

        public void respuestaFacil () {
            Random r = new Random ( DateTime.Now.Millisecond );
            int count = 0, i = 0;
            Program.copia.Count ( Program.copia, ref count );
            Program.copia.encontrarPreguntaAleatoria ( r.Next ( count ), ref i, Program.copia );
            eliminarPersonajesMaquina ();
        }

        public void respuestaNormal () {
            BinaryTreeCategoriaMedia.root = BinaryTreeCategoriaMedia.arbolMedia ( copiaDeCategorias );
            Random r = new Random ( DateTime.Now.Millisecond );
            int count = 0, i = 0, aleatorio = 0;
            count = BinaryTreeCategoriaMedia.root.Recursiones;
            aleatorio = r.Next ( count );
            BinaryTreeCategoriaMedia.root.encontrarPreguntaAleatoria ( BinaryTreeCategoriaMedia.root, ref aleatorio, ref i );
            quitarCategoriaEnCopia ();
        }

        private void respuestaDificil () {
            BinaryTreeCategoriaMedia.root = BinaryTreeCategoriaMedia.arbolMedia ( copiaDeCategorias );
            int i = 0, aleatorio = 0;
            BinaryTreeCategoriaMedia.root.encontrarPreguntaAleatoria ( BinaryTreeCategoriaMedia.root, ref aleatorio, ref i );
            quitarCategoriaEnCopia ();
        }

        private void quitarCategoriaEnCopia () {
            Boolean eliminarTodas = eliminarPersonajesMaquina ();
            //  Se elimina la pregunta de la lista, si la respuesta es que se deben eliminar todas entonces se borra la categoría.
            foreach (Categorias c in copiaDeCategorias) {
                if (eliminarTodas) {
                    copiaDeCategorias.Remove ( c );
                    return;
                } else {
                    foreach (Preguntas p in c.Preguntas) {

                        if (p == preguntaActual) {
                            if (c.Preguntas.Count <= 2)
                                copiaDeCategorias.Remove ( c );
                            else
                                c.Preguntas.Remove ( p );
                            return;
                        }
                    }
                }
            }
        }

        public Boolean eliminarPersonajesMaquina () {
            Boolean eliminarTodas = false;
            int eliminados = 0;
            if (preguntaActual.Aprobados.Contains ( Program.personajeElegido )) eliminarTodas = true;
            List<Personaje> tmp = new List<Personaje> ( seleccionados );
            foreach (Personaje p in tmp) {
                if (eliminarTodas) {
                    if (!preguntaActual.Aprobados.Contains ( p )) {
                        seleccionados.Remove ( p );
                        eliminados++;
                    }
                } else {
                    if (preguntaActual.Aprobados.Contains ( p )) {
                        seleccionados.Remove ( p );
                        eliminados++;
                    }
                }
            }
            if (eliminados == 0 && (dificultad==1 || dificultad==2) ) {
                Random r = new Random ( DateTime.Now.Millisecond );
                int aleatorio = r.Next ( seleccionados.Count );
                if (seleccionados[aleatorio] == Program.personajeElegido) VentanaPrincipal.game.perder ();
                seleccionados.RemoveAt ( aleatorio );
            }
            return eliminarTodas;
        }
    }
}
