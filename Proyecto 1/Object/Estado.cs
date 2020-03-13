using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Object
{
    class Estado
    {
        string nombre;
        int name;
        string conjunto = "";
        public Estado(int nam)
        {
            nombre = "S" + nam;
            name = nam;
            conjunto = "";
        }
        public Estado(string nam)
        {
            name = Int16.Parse(nam);
            nombre = nam;
            conjunto = "";
        }

        public string getName()
        {
            return nombre;
        }

        public void agregar(int conj)
        {
            if (conjunto.Equals(""))
            {
                conjunto = conj.ToString();
            }
            else
            {
                conjunto += "," + conj.ToString();
            }
        }
    }
}
