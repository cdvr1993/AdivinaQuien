using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    public class Preguntas
    {
        public String question;
        public List<Personaje> aprobados = new List<Personaje> ();
        private Boolean visitado = false;
        public Preguntas ( String pregunta ) {
            this.question = pregunta;
        }

        public void agregarAprobado ( Personaje p ) {
            if (aprobados.Contains ( p )) return;
            aprobados.Add ( p );
        }

        public override string ToString () {
            return this.question;
        }

        public List<Personaje> Aprobados {
            get {
                return aprobados;
            }
        }

        public Boolean Visitado {
            set { this.visitado = value; }
            get { return this.visitado; }
        }
     
    }
}
