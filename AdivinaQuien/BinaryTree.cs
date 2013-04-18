using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class BinaryTree<T>
    {
        private Node root;
        public BinaryTree () {
            root = null;
        }

        public void Add (T Personaje) {
            if(root != null){
                root = new Node (Personaje);
            }else{
            }
        }

        public Boolean Contains ( T Personaje ) {
            return false;
        }

        public int Count {
            get {
                return 0;
            }
        }

        private class Node
        {
            private Node actual, izq, der;
            private T personaje;

            public Node (T personaje) {
                this.personaje = personaje;
            }

            public Node Actual {
                set {
                    this.actual = value;
                }
                get {
                    return actual;
                }
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
        }
    }
}
