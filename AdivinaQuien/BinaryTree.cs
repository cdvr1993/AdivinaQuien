using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class BinaryTree
    {
        private Node root;
        public BinaryTree () {
            root = null;
        }

        public void Add (Personaje p) {
            if(root == null){
                root = new Node (p);
            }else{
                Node tmp = root;
                while (true) {
                    if (tmp.menor ( p ) == -1) {
                        if (tmp.Izq == null) {
                            tmp.Izq = new Node ( p );
                            return;
                        }
                        tmp = tmp.Izq;
                    } else if (tmp.menor ( p ) == 1) {
                        if (tmp.Der == null) {
                            tmp.Der = new Node ( p );
                            return;
                        }
                        tmp = tmp.Der;
                    } else return;
                }
            }
        }

        public Boolean Contains ( Personaje p ) {
            return false;
        }

        public int Count {
            get {
                return 0;
            }
        }

        private class Node
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
                else if (i == persona.Nombre.Length) return -1;
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
