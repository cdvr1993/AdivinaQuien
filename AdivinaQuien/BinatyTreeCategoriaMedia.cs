using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class BinaryTreeCategoriaMedia
    {
        public static BinaryTreeCategoriasFacil.Node root;
        public static List<Categorias> copia;

        public static List<NodoCoincidencias> obtenerCoincidencias(List<Categorias> clon)
        {
            copia = clon;
            List<NodoCoincidencias> coincidencias = new List<NodoCoincidencias>(copia.Count());
            int contador = 0; 
            int i = 0; 

            foreach (Categorias c in copia){ // Total de categorias: pelo, ojos, nariz, sonrisa 
                i = c.idCategoria;
                foreach (Preguntas q in c.Preguntas) // Total de preguntas por categoria: pelo corto, pelo largo, pelón 
                {
                    foreach (Personaje p in VentanaPrincipal.seleccionados) // Total de personajes en paneles: alex, romi, yo, etc.
                    {
                        if (q.aprobados.Contains(p)) // Sí el personaje está contenido en la pregunta... 
                        {
                            contador++;
                        }
                    }
                    coincidencias.Add (new NodoCoincidencias(contador, i));
                    contador = 0;
                }
            }
            return coincidencias; 
        }

        public static BinaryTreeCategoriasFacil.Node arbolMedia(List<Categorias> clon)
        {
            List<NodoCoincidencias> coincidences = obtenerCoincidencias(clon); // Se hace una lista de las coincidencias
            coincidences.Sort((x, y) => x.veces.CompareTo(y.veces)); // Para que los ordene en base a las veces
            coincidences.Reverse(); // Los ponga de Mayor A Menor
            int indexInicial = coincidences.ElementAt<NodoCoincidencias>(0).getIndex();
            root = new BinaryTreeCategoriasFacil.Node(null, clon.ElementAt<Categorias>(indexInicial).Preguntas);
            BinaryTreeCategoriasFacil.Node tmp;

            for (int i = 1; i < 5; i++)
            {
                tmp = root;
                while (true)
                {
                    if (tmp.preguntas.Count <= (clon.ElementAt<Categorias>(coincidences.ElementAt<NodoCoincidencias>(i).getIndex()).Preguntas.Count))
                    {
                        if (tmp.Izq == null)
                        {
                            tmp.Izq = new BinaryTreeCategoriasFacil.Node(tmp, clon.ElementAt<Categorias>(coincidences.ElementAt<NodoCoincidencias>(i).getIndex()).Preguntas);
                            break;
                        }
                        tmp = tmp.Izq;
                    }
                    else if (tmp.preguntas.Count > (clon.ElementAt<Categorias>(coincidences.ElementAt<NodoCoincidencias>(i).getIndex()).Preguntas.Count))
                    {
                        if (tmp.Der == null)
                        {
                            tmp.Der = new BinaryTreeCategoriasFacil.Node(tmp, clon.ElementAt<Categorias>(coincidences.ElementAt<NodoCoincidencias>(i).getIndex()).Preguntas);
                            break;
                        }
                        tmp = tmp.Der;
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
                Count ( root, ref count );
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
            public int index;

            public NodoCoincidencias (int repeticiones, int indexCategoria)
            {
                this.veces = repeticiones;
                this.index = indexCategoria;
            }

            public int getIndex()
            {
                return this.index;
            }
        }
    }
}
