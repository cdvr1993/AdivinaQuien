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
        private List<Preguntas> questions = new List<Preguntas> ();
        public Categorias ( String nombre, int id ) {
            this.nombre = nombre;
            this.idCategoria = id;
        }

        public void agregarOpciones(Preguntas p){
            if (questions.Contains ( p )) return;
            questions.Add ( p );
        }

        public String Nombre {
            get {
                return this.nombre;
            }
        }

        public Preguntas this [int index]{
            get {
                return questions[index];
            }
        }

        public int Count {
            get {
                return questions.Count;
            }
        }

    }
}
