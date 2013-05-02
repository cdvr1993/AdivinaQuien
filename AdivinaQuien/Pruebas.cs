using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdivinaQuien
{
     class Pruebas
    {
        public List<Categorias> copia = null;
        public BinaryTreeCategoriaMedia.NodePregunta root = null;

        public Pruebas()
        {
            copia = Program.categorias;
        }

        public void formar () {
        root = BinaryTreeCategoriaMedia.arbolMedia(copia);
        MessageBox.Show(root.question);
        MessageBox.Show(root.izq.question);
        MessageBox.Show(root.izq.izq.question);
        MessageBox.Show(root.der.question);
        MessageBox.Show(root.der.der.question);
      
    }

    }

}
