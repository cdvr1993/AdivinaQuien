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
        public BinaryTree.Node clon = null;
        public Maquina ( int dificultad, BinaryTree.Node copia) {
            this.dificultad = dificultad;
            this.clon = copia;
        }



    }
}
