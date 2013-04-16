using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinaQuien
{
    class Personaje
    {
        private int idPersonaje = 0;
        private String nombre = null;
        public Personaje ( String nombre, int id ) {
            this.nombre = nombre;
            this.idPersonaje = id;
        }

        public int ID {
            set {
            }
            get {
                return this.idPersonaje;
            }
        }

        public String Nombre {
            set {
            }
            get {
                return this.nombre;
            }
        }
    }
}
