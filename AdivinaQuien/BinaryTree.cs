using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdivinaQuien
{
    public class BinaryTree
    {
        public static Node root;
        public static List<Personaje> copia;

        public static Node arbolPersonajesAleatorios(List<Personaje> generados)
        {
            copia = generados;
            root = new Node(generados.ElementAt<Personaje>(0));
	    	Node tmp;
            for (int i = 1; i < copia.Count; i++)
            {
                tmp = root;
                while (true)
                {
                    if (tmp.menor(copia.ElementAt<Personaje>(i)) == -1)
                    {
                        if (tmp.Izq == null)
                        {
                            tmp.Izq = new Node(copia.ElementAt<Personaje>(i));
                            break;
                        }
                        tmp = tmp.Izq;
                    }
                    else if (tmp.menor(copia.ElementAt<Personaje>(i)) == 1)
                    {
                        if (tmp.Der == null)
                        {
                            tmp.Der = new Node(copia.ElementAt<Personaje>(i));
                            break;
                        }
                        tmp = tmp.Der;
                    }
                }
            }
            return root;
        }

        public static void printArbol(Node node)
        {
		    if(node.Izq != null) printArbol(node.Izq);
            MessageBox.Show ("valor = " + node.Persona.Nombre + "; id = " + node.Persona.ID);
            if (node.Der != null) printArbol(node.Der);
        }

        public static Boolean Contains(Node node, Personaje p)
        {
            Node root = node;
            Node tmp;
            for (int i = 1; i < copia.Count; i++)
            {
                tmp = root;
                while (true)
                {
                    if (tmp.menor(p) == 0)
                        return true;

                    if (tmp.menor(p) == -1)
                    {
                        if (tmp.Izq == null)
                        {
                            return false;
                        }
                        tmp = tmp.Izq;
                    }
                    else if (tmp.menor(p) == 1)
                    {
                        if (tmp.Der == null)
                        {
                            return false;
                        }
                        tmp = tmp.Der;
                    }
                }
            }
            return false;
        }


        public int Count {
            get {
                return 0;
            }
        }

        public class Node
        {
            private Node izq = null, der = null;
            private Personaje persona;

            public Node (Personaje p) {
                this.persona = p;
            }

            public int menor ( Personaje p ) {
                int i;
                for (i = 0 ; i < p.Nombre.Length && i < persona.Nombre.Length ; i++) {
                    if (persona.Nombre[i] < p.Nombre[i]) return -1;
                    else if (persona.Nombre[i] > p.Nombre[i]) return 1;
                }
               if (i == persona.Nombre.Length && i == p.Nombre.Length) return 0;
               if (i == persona.Nombre.Length) return -1;
               else return 1;
            }

            public Node Izq {
                set {
                    this.izq = value;
                }
                get {
                    return this.izq;
                }
            }

            public Node Der {
                set {
                    this.der = value;
                }
                get {
                    return this.der;
                }
            }

            public Personaje Persona { 
                get { return this.persona; } 
            }
        }
    }
}
