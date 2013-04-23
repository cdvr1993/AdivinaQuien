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
        public List<Preguntas> questions = new List<Preguntas> ();
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

        public List<Preguntas> Preguntas{
            get { return questions; }
        }

        public int Count {
            get {
                return questions.Count;
            }
        }

        public int AprobadosCount {
            get {
                int count = 0;
                foreach (Preguntas p in questions) count += p.aprobados.Count;
                return count;
            }
        }

    }
}
