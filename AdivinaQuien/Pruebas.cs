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
    }

}
