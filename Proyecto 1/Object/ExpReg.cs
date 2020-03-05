using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Object
{
    class ExpReg
    {
        ArrayList tokens = new ArrayList();
        string Nombre;
        ArrayList lexemas = new ArrayList();
        public ExpReg()
        {
        }

        public ExpReg(string name, ArrayList token)
        {
            this.Nombre = name;
            this.tokens = token;
        }

        public void agregarLexema(string lex)
        {
            this.lexemas.Add(lex);
        }

    }
}
