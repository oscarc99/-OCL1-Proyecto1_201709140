using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Object
{
    class Conjunto
    {
        String Nombre;
        ArrayList conjunto = new ArrayList();

        public Conjunto()
        {
        }

        public Conjunto(String Nombre)
        {
            this.Nombre = Nombre;
        }

        public String getNombre()
        {
            return Nombre;
        }

        public ArrayList getConjunt()
        {
            return conjunto;
        }

        public void setNombre(String Nombre)
        {
            this.Nombre = Nombre;
        }

        public void setConjunt(ArrayList conjunt)
        {
            this.conjunto = conjunt;
        }

        public void llenar(char inicio, char fin)
        {
            for (int i = inicio; i < fin + 1; i++)
            {
                conjunto.Add(i);
            }
        }


        public void agregar(char c)
        {
            int ca = c;
            conjunto.Add(ca);
        }

        public void add(int c)
        {
            conjunto.Add(c);
        }

        public bool pertenece(char c)
        {
            int caraceter = c;
            for (int i = 0; i < conjunto.Count; i++)
            {
                if ((int)conjunto[i] == caraceter) return true;
            }
            return false;
        }
    }
}
