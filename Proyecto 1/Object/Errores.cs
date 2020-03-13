using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Object
{
    class Errores
    {
        private string lexema;
        private string tipo;
        private int columna;
        private int fila;
        
        public Errores()
        {

        }
        public Errores(string lexema, int columna, int fila)
        {
            this.tipo = "Error lexico";
            this.lexema = lexema;
            this.columna = columna;
            this.fila = fila;
            
        }

        public string getLexema()
        {
            return this.lexema;
        }

        public int getFila()
        {
            return this.fila;
        }

        public int getColumna()
        {
            return  this.columna;
        }

    }
}
