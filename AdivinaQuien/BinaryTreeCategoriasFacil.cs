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
            root = new Node(clon.ElementAt<Categorias>(0).Preguntas);
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
                            tmp.Izq = new Node(clon.ElementAt<Categorias>(i).Preguntas);
                            break;
                        }
                        tmp = tmp.Izq;
                    }
                    else if (tmp.preguntas.Count > (clon.ElementAt<Categorias>(i).Preguntas.Count))
                    {
                        if (tmp.Der == null)
                        {
                            tmp.Der = new Node(clon.ElementAt<Categorias>(i).Preguntas);
                            break;
                        }
                        tmp = tmp.Der;
                    }
                }
            }
            return root;
        }


        public class Node
        {
            private Node izq = null, der = null;
            public List<Preguntas> preguntas; 

            public Node(List <Preguntas> questions)
            {
                this.preguntas = questions; 
            }

            public Node Izq
            {
                set
                {
                    this.izq = value;
                }
                get
                {
                    return this.izq;
                }
            }

            public Node Der
            {
                set
                {
                    this.der = value;
                }
                get
                {
                    return this.der;
                }
            }
        }

    }
}
