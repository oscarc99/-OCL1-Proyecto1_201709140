﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Object
{
    class DFA
    {
        int inicio;
        string traslado;
        int final;

        public DFA()
        {

        }
        public DFA(int inici, string tras, int fin)
        {
            inicio = inici;
            traslado = tras;
            final = fin;
        }

        public int getInicio()
        {
            return inicio;
        }
        public int getFinal()
        {
            return final;
        }
        public string getTransicion()
        {
            return traslado;
        }
    }
}
