using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class Preguntas
    {
        public String question;
        public List<Personaje> aprobados = new List<Personaje> ();
        public Preguntas ( String pregunta ) {
            this.question = pregunta;
        }

        public void agregarAprobado ( Personaje p ) {
            if (aprobados.Contains ( p )) return;
            aprobados.Add ( p );
        }

        public List<Personaje> Aprobados {
            get {
                return aprobados;
            }
        }
    }
}
