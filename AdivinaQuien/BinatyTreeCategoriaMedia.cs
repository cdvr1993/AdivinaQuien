using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class BinaryTreeCategoriaMedia
    {
        public static NodePregunta root = null;
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
                    coincidencias.Add(new NodoCoincidencias(contador, q));
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

        public class NodoCoincidencias 
        {
            public int veces;
            public Preguntas question;

            public NodoCoincidencias (int repeticiones,  Preguntas question)
            {
                this.veces = repeticiones;
                this.question = question;
            }
        }

        public class NodePregunta
        {
            public NodePregunta padre = null;
            public NodePregunta izq = null, der = null;
            public Preguntas question = null;

            public NodePregunta (NodePregunta padre, Preguntas question)
            {
                this.padre = padre;
                this.question = question; 
            }

            public void encontrarPreguntaAleatoria ( NodePregunta tmp, ref int aleatorio, ref int contador ) {
                if (aleatorio < contador) return;
                if (aleatorio == contador) {
                    VentanaPrincipal.maquina.preguntaActual = tmp.question;
                    contador++;
                }
                contador++;
                if (tmp.izq != null) encontrarPreguntaAleatoria ( tmp.izq, ref aleatorio, ref contador );
                if (tmp.der != null) encontrarPreguntaAleatoria ( tmp.der, ref aleatorio, ref contador );
            }

            public int Recursiones {
                get {
                    int count = 0;
                    Count ( this, ref count );
                    return count;
                }
            }

            private void Count ( NodePregunta tmp, ref int i ) {
                i++;
                if (tmp.izq != null) Count ( tmp.izq, ref i );
                if (tmp.der != null) Count ( tmp.der, ref i );
            }
        }

    }
}
