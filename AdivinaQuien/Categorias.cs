using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class Categorias
    {
        private int idCategoria;
        private String nombre;
        private List<String> opcion = new List<String>();
        public Categorias ( String nombre, int id ) {
            this.nombre = null;
            this.idCategoria = id;
        }

        public void agregarOpciones(String opcion){
            if(this.opcion.IndexOf(opcion)>=0) return;
            this.opcion.Add(opcion);
        }
    }
}
