using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace AdivinaQuien
{
    static class Program
    {
        public static List<Personaje> personajes = new List<Personaje> ();
        public static Personaje personajeElegido = null;
        public static List<Categorias> categorias = new List<Categorias> ();
        public static BinaryTreeCategoriasFacil.Node copia = null;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main () {
            cargando ();
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault ( false );
            Application.Run ( new VentanaPrincipal () );
        }

        static void cargando () {
            try {
                Thread hilo = new Thread ( generarPersonajes ), hilo2 = new Thread ( generarCategorias ),
                    splash = new Thread ( cargarSplash );
                splash.Start ();
                hilo.Start ();
                hilo2.Start ();
                hilo.Join ();
                hilo2.Join ();
                Thread hilo3 = new Thread ( generarRelaciones );
                hilo3.Start ();
                hilo3.Join ();
                splash.Join ();
            } catch (Exception e) {
                Console.WriteLine ( e.Message );
            }
        }

        static void generarPersonajes () {
            try {
                FileStream fs = new FileStream ( "Personajes2.csv", FileMode.Open, FileAccess.Read );
                StreamReader sr = new StreamReader ( fs );
                String nombre = sr.ReadLine ();
                while ((nombre = sr.ReadLine ()) != null)
                    personajes.Add(new Personaje(nombre,personajes.Count));
                sr.Close ();
                fs.Close ();
            } catch (FileNotFoundException) {}
        }

        static void generarCategorias () {
            try {
                FileStream fs = new FileStream ( "Personajes1.csv", FileMode.Open, FileAccess.Read );
                StreamReader sr = new StreamReader ( fs );
                String nombre = "";
                String aux = "";
                int row = 0, columna = 0;
                while ((nombre = sr.ReadLine ()) != null) {
                    foreach (char c in nombre) {
                        if (c == ',') {
                            if (columna == 0)
                                categorias.Add ( new Categorias ( aux, categorias.Count ) );
                            else if (columna > 0)
                                categorias[row].agregarOpciones ( new Preguntas ( aux ) );
                            aux = "";
                            columna++;
                            continue;
                        }
                        aux += c;
                    }
                    //Por la última palabra que no tiene coma.
                    categorias[row].agregarOpciones ( new Preguntas ( aux ) );
                    aux = "";
                    columna = 0;
                    row++;
                }
                sr.Close ();
                fs.Close ();
                copia = BinaryTreeCategoriasFacil.arbolCategoriasAleatorias(categorias);
               // int[] coincidencias = BinaryTreeCategoriaMedia.obtenerCoincidencias(categorias);
               


            } catch (FileNotFoundException) { }
        }

        static void generarRelaciones () {
            try {
                FileStream fs = new FileStream ( "Personajes.csv", FileMode.Open, FileAccess.Read );
                StreamReader sr = new StreamReader ( fs );
                String nombre = sr.ReadLine ();
                String aux = "";
                int row = 0, column = -1, indexCat=0;
                while ((nombre = sr.ReadLine ()) != null) {
                    foreach (char c in nombre) {
                        if (c == ',') {
                            if (column == categorias[indexCat].Count) {
                                indexCat++;
                                column = 0;
                            }
                            if (aux.Length > 0 && column != -1)
                                categorias[indexCat].Preguntas[column].agregarAprobado ( personajes[row] );
                            column++;
                            aux = "";
                            continue;
                        }
                        aux += c;
                    }
                    if (column == categorias[indexCat].Count) {
                        indexCat++;
                        column = 0;
                    }
                    if (aux.Length > 0 && column != -1)
                        categorias[indexCat].Preguntas[column].agregarAprobado ( personajes[row] );
                    row++;
                    aux = "";
                    indexCat = 0;
                    column = -1;
                }
                sr.Close ();
                fs.Close ();
            } catch (FileNotFoundException) { }
        }

        static void cargarSplash () {
<<<<<<< HEAD
            Splash splash = new Splash ();
            splash.Show ();
            Thread.Sleep ( 3000 );
            splash.Dispose ();
=======
            if (Splash.mostrar) {
                Splash splash = new Splash ();
                splash.Show ();
                Thread.Sleep ( 3000 );
                splash.Dispose ();
                Splash.mostrar = false;
                splash.Dispose ();
            }
>>>>>>> Reinicio Mejorado del Juego
        }
    }
}
