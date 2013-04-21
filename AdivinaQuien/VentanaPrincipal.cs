﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdivinaQuien
{
    public partial class VentanaPrincipal : Form
    {
        private List<PanelPersonajes> paneles = new List<PanelPersonajes>();
        private const int NUMPANELES = 24;
        public static List<Personaje> seleccionados = null;
        public static Maquina maquina = null;
        public static Juego game = null;
        public static BinaryTree.Node copia = null;

        public VentanaPrincipal () {
            InitializeComponent ();
            generarPaneles ();
            foreach (Personaje p in Program.personajes)
                lstPersonajes.Items.Add ( p.Nombre );
        }

        private void generarPaneles () {
            Point pos = new Point ( 20, 400 );
            for (int i = 0, x = 100, y = 140 ; i < NUMPANELES ; i++) {
                paneles.Add ( new PanelPersonajes () );
                paneles[i].Location = pos;
                paneles[i].Name = "pnl" + i;
                paneles[i].Size = new Size ( x, y );
                paneles[i].TabIndex = i;
                this.Controls.Add ( paneles[i] );
                //  Cambiamos unicamente la posición para que no se sobreescriban.
                pos = new Point ( paneles[i].Bounds.X + paneles[i].Width + 10, paneles[i].Bounds.Y );
                if ((pos.X + x) > 1366)
                    pos = new Point ( paneles[0].Bounds.X, 400 + y + 10 );
            }
        }

        private void iniciarJuego (int id) {
            game = new Juego ( this );
            game.start ( id );
        }

        public void agregarPersonajesAleatoriamente () {
            Random r = new Random ( System.DateTime.Now.Millisecond );
            List<Personaje> agregados = new List<Personaje> ();
            for (int i = 0, index = 0 ; i < NUMPANELES ; i++) {
                do {
                    index = r.Next ( Program.personajes.Count );
                } while (Program.personajeElegido.Equals ( Program.personajes[index] ) || agregados.Contains ( Program.personajes[index] ));
                paneles[i].Display = new DisplayPersonaje ( Program.personajes[index], paneles[i].Size );
                agregados.Add ( Program.personajes[index] );
            }
            seleccionados = agregados;
            copia = BinaryTree.arbolPersonajesAleatorios(seleccionados);
          // // BinaryTree.printArbol(nuevo);
          //  Personaje p = new Personaje("Ale Galindo", 0); 
          //  bool contiene = BinaryTree.Contains(nuevo, p);
          //  MessageBox.Show(contiene.ToString());
          ////  MessageBox.Show(nuevo.Izq.Persona.Nombre);
          // // BinaryTree nuevo = BinaryTree.arbolPersonajesAleatorios(List < Personaje > generados);
            
        }

        private void btnAceptar_Click ( object sender, EventArgs e ) {
            if (lstPersonajes.SelectedIndex < 0)
                MessageBox.Show ( "Seleccione algún personaje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            else if (cbDificultad.SelectedIndex < 0)
                MessageBox.Show ( "Seleccione la dificultad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            else {
                pnlSelection.Dispose ();
                maquina = new Maquina ( cbDificultad.SelectedIndex, copia);
                iniciarJuego ( lstPersonajes.SelectedIndex );
            }
        }

        private void lstPersonajes_SelectedIndexChanged ( object sender, EventArgs e ) {
            pnlSelection.Controls.Clear ();
            pnlSelection.Controls.Add ( new DisplayPersonaje ( Program.personajes[lstPersonajes.SelectedIndex], pnlSelection.Size, false ) );
        }

        public ListBox ListaDePersonajes {
            get { return lstPersonajes; }
        }

        private void btnPreguntar_Click ( object sender, EventArgs e ) {
            game.preguntar ();
        }
    }
}