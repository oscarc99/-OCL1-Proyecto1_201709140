using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Object
{
    class Lexema
    {
        string identificador;//nombres
        string cadena; //valor
        Boolean estado;


        public Lexema()
        {

        }
        public Lexema(string id, string caden, Boolean estad)
        {
            identificador = id;
            cadena = caden;
            estado = estad;

        }

        public Lexema(string cadena, string id)
        {
            this.identificador = id;
            this.cadena = cadena;
        }

        public string getID()
        {
            return identificador;
        }
        public string getCadena()
        {
            return cadena;
        }
        public Boolean getEstado()
        {
            return estado;
        }

    }
}
