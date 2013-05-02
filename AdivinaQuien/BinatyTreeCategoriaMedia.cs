using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class BinaryTreeCategoriaMedia
    {
        public static NodePregunta root;
        public static List<Categorias> copia;

        public static List<NodoCoincidencias> obtenerCoincidencias(List<Categorias> clon)
        { 
            copia = clon;
            int num_preguntas = 0;
            foreach (Categorias c in copia)
                foreach (Preguntas q in c.Preguntas)
                    num_preguntas += 1;

            List<NodoCoincidencias> coincidencias = new List<NodoCoincidencias>(num_preguntas);
            int contador = 0; 

            foreach (Categorias c in copia){ // Total de categorias: pelo, ojos, nariz, sonrisa 
            
                foreach (Preguntas q in c.Preguntas) // Total de preguntas por categoria: pelo corto, pelo largo, pelón 
                {
                    foreach (Personaje p in VentanaPrincipal.seleccionados) // Total de personajes en paneles: alex, romi, yo, etc.
                    {
                        if (q.aprobados.Contains(p)) // Sí el personaje está contenido en la pregunta... 
                        {
                            contador++;
                        }

                    }
                    coincidencias.Add(new NodoCoincidencias(contador, q.question));
                    contador = 0;
                }
            }
            return coincidencias; 
        }

        public static NodePregunta arbolMedia(List<Categorias> clon)
        {
            List<NodoCoincidencias> coincidences = obtenerCoincidencias(clon); // Se hace una lista de las coincidencias
            coincidences.Sort((x, y) => x.veces.CompareTo(y.veces)); // Para que los ordene en base a las veces
            coincidences.Reverse(); // Los ponga de Mayor A Menor
            root = new NodePregunta (null, coincidences.ElementAt<NodoCoincidencias>(0).question);
            NodePregunta tmp;

            for (int i = 1; i < 5; i++)
            {
                tmp = root;
                while (true)
                {
                    if (i<3)
                    {
                        if (tmp.izq == null)
                        {
                            tmp.izq = new NodePregunta(tmp, coincidences.ElementAt<NodoCoincidencias>(i).question);
                            break;
                        }
                        tmp = tmp.izq;
                    }
                    else 
                    {
                        if (tmp.der == null)
                        {
                            tmp.der = new NodePregunta(tmp, coincidences.ElementAt<NodoCoincidencias>(i).question);
                            break;
                        }
                        tmp = tmp.der;
                    }
                }
            }
            return root;
        }

        public static void encontrarPreguntaAleatoria ( BinaryTreeCategoriasFacil.Node tmp, ref int aleatorio, ref int contador ) {
            if (aleatorio == contador)
                return;
            if (tmp.Izq != null) encontrarPreguntaAleatoria ( tmp.Izq, ref aleatorio, ref contador );
            if (tmp.Der != null) encontrarPreguntaAleatoria ( tmp.Der, ref aleatorio, ref contador );
        }

        public static int Recursiones {
            get {
                int count = 0;
               // Count ( root, ref count );
                return count;
            }
        }

        private static void Count ( BinaryTreeCategoriasFacil.Node tmp, ref int i ) {
            i++;
            if (tmp.Izq != null) Count ( tmp.Izq, ref i );
            if (tmp.Der != null) Count ( tmp.Der, ref i );
        }

        public class NodoCoincidencias 
        {
            public int veces;
            public String question;

            public NodoCoincidencias (int repeticiones,  String question)
            {
                this.veces = repeticiones;
                this.question = question;
            }
        }

        public class NodePregunta
        {
            public NodePregunta padre = null;
            public NodePregunta izq = null, der = null;
            private Boolean visitado = false;
            public String question = "";

            public NodePregunta (NodePregunta padre, String question)
            {
                this.padre = padre;
                this.question = question; 
            }
        }

    }
}
