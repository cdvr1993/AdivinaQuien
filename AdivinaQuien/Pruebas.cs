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
        public List<PanelPersonajes> paneles;
        public List<Categorias> copia = null;
        public BinaryTreeCategoriasFacil.Node root = null;

        public Pruebas(List<Categorias> copy)
        {
            copia = copy;
        }

        public void formar () {
        paneles = VentanaPrincipal.Interfaz.paneles;
        root = BinaryTreeCategoriaMedia.arbolMedia(copia);
        MessageBox.Show(root.preguntas.ElementAt<Preguntas>(0).ToString());
        MessageBox.Show(root.preguntas.ElementAt<Preguntas>(1).ToString());
    }

    }

}
