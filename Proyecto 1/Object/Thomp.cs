using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Object
{
    class Thomp
    {
        int name;
        string apuntadores="";
        string transicion;//valor
        public Thomp()
        {
        }
        public Thomp(int nomb, string trans)
        {
            name = nomb;
            apuntadores = "";
            transicion = trans;
        }
        public Thomp(int nomb)
        {
            name = nomb;
            apuntadores = "";
            
        }
        public void setTrans(string tra)
        {
            transicion = tra;
        }
        public void add(int a)
        {
            if (apuntadores.Equals(""))
            {
                apuntadores = a.ToString();
            }
            else
            {
                apuntadores += "," +a;
            }
        }
        public int getName()
        {
            return name;
        }

        public string getTransicion()
        {
            return transicion;
        }
        public string getApuntadores()
        {
            return apuntadores;
        }

    }
}
