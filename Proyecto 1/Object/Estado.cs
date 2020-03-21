﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Object
{
    class Estado
    {
        int[] transicion;
        string nombre;
        int name;
        int fin = -1;
        Boolean aceptacion = false;
        string conjunto = "";
        string inicial="";
        ArrayList conjunt = new ArrayList();
        ArrayList transiciones = new ArrayList();//Para crear la tabla de transiciones, todos los terminales y a que estado se va
        public Estado(int nam, ArrayList tras, int final)
        {
            transicion = new int[tras.Count];
            for (int i = 0; i < transicion.Length; i++)
            {
                transicion[i] = -1;
            }
            fin = final;
            nombre = "S" + nam;
            name = nam;
            conjunto = "";
            conjunt = new ArrayList();
            transiciones = tras;
            aceptacion = false;
        }
        public void setInicial(string x)
        {
            inicial = x;
        }

        public bool getAceptacion()
        {
            return aceptacion;
        }

        public int[] getTransicion()
        {
            return transicion;
        }
        public string getInicial()
        {
            return inicial;
        }

        public string getConjunto()
        {
            return conjunto;
        }
        public ArrayList getConjunt()
        {
            return conjunt;
        }
        public ArrayList getTrans()
        {
            return transiciones;
        }
        public void setTraslado(int posicion, int estado)
        {
            transicion[posicion] = estado;

        }

        public Estado(string nam, ArrayList tras)
        {
            transiciones = tras;
            transicion = new int[tras.Count];
            for (int i = 0; i < transicion.Length; i++)
            {
                transicion[i] = -1;
            }
            name = Int16.Parse(nam);
            nombre = nam;
            conjunto = "";
            conjunt = new ArrayList();
        }
        public Estado(string nam, ArrayList conj, ArrayList tras)
        {
            transiciones = tras;
            conjunt = conj;
            name = Int16.Parse(nam);
            nombre = nam;
            conjunto = "";
            conjunt = new ArrayList();
        }

        public string getName()
        {
            return nombre;
        }
        public int getNombre()
        {
            return name;
        }

        public void agregar(int conj)
        {
            if (conjunto.Equals(""))
            {
                conjunto = conj.ToString();
                conjunt.Add(conj);
                conjunt.Sort();
            }
            else
            {
                conjunto += "," + conj.ToString();
                conjunt.Add(conj);
                conjunt.Sort();
            }
            if(conj == fin)
            {
                aceptacion = true;
            }
        }
    }
}
