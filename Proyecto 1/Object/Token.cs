using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Object
{
    class Token
    {
        private string lexema;
        private int token;
        private string desc;
        private int fila;
        private int columna;

        public Token()
        {

        }

        public Token(string lexema, int tok, string des, int fila, int col)
        {
            this.lexema = lexema;
            this.token = tok;
            this.desc = des;
            this.fila = fila;
            this.columna = col;
        }

        public Token(string lexema, int tok, string des)
        {
            this.lexema = lexema;
            this.token = tok;
            this.desc = des;
        }

        public string getLexema()
        {
            return this.lexema;
        }

        public int getToken()
        {
            return this.token;
        }

        public int getFila()
        {
            return this.fila;
        }

        public int getColumna()
        {
            return this.columna;
        }

        public Boolean Equals(Token t)
        {
            if(t.getToken()== token && t.getLexema().Equals(lexema))
            {
                return true;
            }
            return false;
        }
    }
        

}

