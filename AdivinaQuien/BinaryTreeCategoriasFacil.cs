using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class BinaryTreeCategoriasFacil
    {
        public static Node root;
        public static List<Categorias> copia;

        public static Node arbolCategoriasAleatorias(List<Categorias> clon)
        {
            copia = clon;
            root = new Node(null,clon.ElementAt<Categorias>(0).Preguntas);
            Node tmp;
            for (int i = 1; i < copia.Count; i++)
            {
                tmp = root;
                while (true)
                {
                    if (tmp.preguntas.Count <= (clon.ElementAt<Categorias>(i).Preguntas.Count))
                    {
                        if (tmp.Izq == null)
                        {
                            tmp.Izq = new Node(tmp,clon.ElementAt<Categorias>(i).Preguntas);
                            break;
                        }
                        tmp = tmp.Izq;
                    }
                    else if (tmp.preguntas.Count > (clon.ElementAt<Categorias>(i).Preguntas.Count))
                    {
                        if (tmp.Der == null)
                        {
                            tmp.Der = new Node(tmp,clon.ElementAt<Categorias>(i).Preguntas);
                            break;
                        }
                        tmp = tmp.Der;
                    }
                }
            }
            return root;
        }

        public static List<Preguntas> obtenerPreguntasDelArbol ( ) {
            List<Preguntas> tmp = new List<Preguntas> ();
            if (root != null) agregarALaLista ( root, tmp );
            return tmp;
        }

        public static void agregarALaLista(Node node, List<Preguntas> tmp){
            if (!node.Visitado) {
                foreach (Preguntas p in node.Questions) {
                    if (!p.Visitado)
                        tmp.Add ( p );
                }
            }
            if (node.Izq != null) agregarALaLista ( node.Izq, tmp );
            if (node.Der != null) agregarALaLista ( node.Der, tmp );
        }

        public class Node
        {
            private Node padre = null;
            private Node izq = null, der = null;
            private Boolean visitado = false;
            public List<Preguntas> preguntas; 

            public Node(Node padre, List <Preguntas> questions)
            {
                this.padre = padre;
                this.preguntas = questions; 
            }

            public void encontrarPregunta ( Node node, Preguntas p, Boolean eliminarTodas ) {
                if (!node.visitado) {
                    if (node.preguntas.Contains ( p )) {
                        if (eliminarTodas || node.preguntas.Count<=2) node.visitado = true;
                        else {
                            node.preguntas[node.preguntas.IndexOf ( p )].Visitado = true;
                            int i = 0;
                            foreach (Preguntas question in node.preguntas) {
                                if (question.Visitado) i++;
                            }
                            if (i == node.preguntas.Count) node.visitado = true;
                        }
                        return;
                    }
                }
                if (node.Izq != null) encontrarPregunta ( node.Izq, p, eliminarTodas );
                if (node.Der != null) encontrarPregunta ( node.Der, p, eliminarTodas );
            }

            public void encontrarPreguntaAleatoria ( int aleatorio, ref int contador, Node node ) {
                if (contador > aleatorio) return;
                if (!node.visitado) {
                    int i = 0;
                    foreach (Preguntas question in node.preguntas) {
                        if (contador == aleatorio) {
                            question.Visitado = true;
                            VentanaPrincipal.maquina.preguntaActual = question;
                            contador++;
                            return;
                        }
                        if (question.Visitado) i++;
                        contador++;
                    }
                    if (node.preguntas.Count == i) node.visitado = true;
                }
                if (node.Izq != null) encontrarPreguntaAleatoria ( aleatorio, ref contador, node.Izq );
                if (node.Der != null) encontrarPreguntaAleatoria ( aleatorio, ref contador, node.Der );
            }

            public void Count (Node node, ref int i) {
                foreach (Preguntas p in node.preguntas) {
                    if (!p.Visitado) i++;
                }
                if (node.Izq != null) Count ( node.Izq, ref i );
                if (node.Der != null) Count ( node.der, ref i );
            }

            public Node Izq{
                set { this.izq = value; }
                get { return this.izq; }
            }

            public Node Der{
                set { this.der = value; }
                get { return this.der; }
            }

            public Boolean Visitado {
                set { this.visitado = value; }
                get { return this.visitado; }
            }

            public List<Preguntas> Questions {
                get { return this.preguntas; }
            }
        }

    }
}
