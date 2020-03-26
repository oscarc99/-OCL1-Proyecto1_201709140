using Proyecto_1.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.Analizador
{


    class Lexico
    {
        ArrayList errores = new ArrayList();
        ArrayList simbolos = new ArrayList();
        ArrayList conjuntos = new ArrayList();
        ArrayList expresiones = new ArrayList();
        ArrayList lexemas = new ArrayList();
        private string archivo;
        private int fila = 0;
        private int columna = 0;

        public Lexico()
        {
            errores = new ArrayList();
            simbolos = new ArrayList();
        }
        public Lexico(string origen)
        {
            this.archivo = origen;
            errores = new ArrayList();
            simbolos = new ArrayList();
        }

        public void limpiar()
        {
            errores = new ArrayList();
            simbolos = new ArrayList();
            conjuntos = new ArrayList();
            expresiones = new ArrayList();
        }
        
        public ArrayList getLexemas()
        {
            return this.lexemas;
        }

        public ArrayList getSimbolos()
        {
            return simbolos;
        }

        public void setErrores(ArrayList value)
        {
            this.errores = value;
        }

        public ArrayList getErrores()
        {
            return errores;
        }

        public void setSimbolos(ArrayList value)
        {
            this.simbolos = value;
        }

        public ArrayList getConjuntos()
        {
            return conjuntos;
        }

        public void setConjuntos(ArrayList value)
        {
            conjuntos = value;
        }

        public ArrayList getExpresiones()
        {
            return expresiones;
        }

        public void setExpresiones(ArrayList value)
        {
            expresiones = value;
        }


        public void escanear(string entrada, string origen)
        {
            fila = 0;
            columna = 0;
            string auxLex = "";
            char[] chars = entrada.ToCharArray();
            int estado = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                switch (estado)
                {
                    case 0:
                        if (chars[i].Equals('/'))
                        {
                            estado = 1;
                            auxLex += chars[i];
                            columna++;

                        }
                        else if (chars[i].Equals('<'))
                        {
                            if (chars[i + 1].Equals('!'))
                            {
                                estado = 4;
                                auxLex += chars[i];
                                columna++;
                            }
                            else
                            {
                                simbolos.Add(new Token(auxLex, 21, "Simbolo", fila, columna));
                                columna++;
                                auxLex = "";
                            }
                        }
                        else if (chars[i].Equals('\\'))
                        {
                            auxLex += chars[i];
                            columna++;
                            estado = 2;
                        }
                        else if (char.IsLetter(chars[i]))
                        {
                            auxLex += chars[i];
                            columna++;
                            estado = 8;
                        }
                        else if (chars[i].Equals('"'))
                        {
                            estado = 9;
                            columna++;
                        }
                        else if (chars[i].Equals('-'))
                        {
                            estado = 10;
                            auxLex += chars[i];
                            columna++;
                        }

                        else if (chars[i].Equals('['))
                        {
                            
                            if (chars[i + 1].Equals(':'))
                            {
                                estado = 7;
                                //auxLex += chars[i];
                                columna++;
                            }
                            else
                            {
                                if (chars[i + 1] == '~' || chars[i + 1] == ';' || chars[i + 1] == ',')
                                {


                                    simbolos.Add(new Token("[", 21, "Simbolo", fila, columna));
                                    auxLex = "";
                                    estado = 0;

                                }
                                else
                                {

                                    errores.Add(new Errores(auxLex, columna, fila));
                                    auxLex = "";
                                    estado = 0;


                                }
                            }
                        }
                        else if (chars[i].Equals(':'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 9, "Dos puntos", fila, columna));
                            auxLex = "";

                        }
                        else if (chars[i].Equals('{'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 3, "Llave que abre", fila, columna));
                            auxLex = "";

                        }
                        else if (chars[i].Equals('}'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 4, "Llave que cierra", fila, columna));
                            auxLex = "";

                        }
                        else if (chars[i].Equals(','))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 12, "Coma", fila, columna));
                            auxLex = "";

                        }
                        else if (chars[i].Equals('~'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 13, "Virgulilla", fila, columna));
                            auxLex = "";
                        }
                        else if (chars[i].Equals(';'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 10, "Punto y coma", fila, columna));
                            auxLex = "";
                        }
                        else if (char.IsDigit(chars[i]))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 14, "Digito", fila, columna));
                            auxLex = "";
                        }
                        else if (chars[i].Equals('*'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 15, "Asterisco", fila, columna));
                            auxLex = "";

                        }
                        else if (chars[i].Equals('|'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 17, "Pleca/OR", fila, columna));
                            auxLex = "";

                        }
                        else if (chars[i].Equals('.'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 16, "Punto/AND", fila, columna));
                            auxLex = "";

                        }
                        else if (chars[i].Equals('+'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 18, "Signo mas", fila, columna));
                            auxLex = "";

                        }
                        else if (chars[i].Equals('?'))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            simbolos.Add(new Token(auxLex, 19, "Interrogacion", fila, columna));
                            auxLex = "";

                        }
                        else if (isSymbol(chars[i]))
                        {
                            auxLex = chars[i].ToString();
                            columna++;
                            if (chars[i + 1] == '~' || chars[i + 1] == ';' || chars[i + 1] == ',')
                            {


                                simbolos.Add(new Token(auxLex, 21, "Simbolo", fila, columna));
                                auxLex = "";

                            }
                            else
                            {
                                if (chars[i] == ' ' || chars[i] == '"' || chars[i] == '“' || chars[i] == '”')
                                {
                                    //ignora
                                }
                                else
                                {
                                    errores.Add(new Errores(auxLex, columna, fila));
                                    auxLex = "";

                                }
                            }

                        }
                        else if (chars[i].Equals((char)10) || chars[i].Equals((char)13))
                        {
                            fila++;
                            columna = 0;
                        }
                        else
                        {

                            errores.Add(new Errores(chars[i].ToString(), columna, fila));
                            auxLex = "";
                        }

                        break;
                    case 1:
                        if (chars[i].Equals('/'))
                        {
                            estado = 3;
                            auxLex += chars[i];
                            columna++;
                        }
                        else
                        {
                            errores.Add(new Errores(auxLex, columna, fila));
                            i--;
                            estado = 0;
                            auxLex = "";
                        }
                        break;
                    case 2:
                        if (chars[i].Equals('n'))
                        {
                            auxLex += chars[i];
                            simbolos.Add(new Token(auxLex, 23, "Salto de linea", fila, columna));
                            estado = 0;
                            auxLex = "";
                            columna++;
                        }
                        else if (chars[i].Equals('\''))
                        {
                            auxLex += chars[i];
                            simbolos.Add(new Token(auxLex, 25, "Comillas Simples", fila, columna));
                            estado = 0;
                            auxLex = "";
                            columna++;
                        }
                        else if (chars[i].Equals('\"'))
                        {
                            auxLex += chars[i];
                            simbolos.Add(new Token(auxLex, 26, "Comillas Dobles", fila, columna));
                            estado = 0;
                            auxLex = "";
                            columna++;
                        }
                        else if (chars[i].Equals('t'))
                        {
                            auxLex += chars[i];
                            simbolos.Add(new Token(auxLex, 24, "Tabulacion", fila, columna));
                            estado = 0;
                            auxLex = "";
                            columna++;
                        }
                        else
                        {

                            errores.Add(new Errores(auxLex, columna, fila));
                            auxLex = "";
                            estado = 0;
                            i--;


                        }
                        break;
                    case 3:
                        if (chars[i].Equals((char)10) || chars[i].Equals((char)13))
                        {
                            simbolos.Add(new Token(auxLex, 1, "Comentario una linea", fila, columna));
                            auxLex = "";
                            fila++;
                            columna = 0;
                            estado = 0;

                        }
                        else
                        {
                            auxLex += chars[i];
                        }
                        break;
                    case 4:
                        if (chars[i].Equals('!'))
                        {
                            estado = 5;
                            columna++;
                            auxLex += chars[i];
                        }
                        else
                        {
                            errores.Add(new Errores(auxLex, columna, fila));
                            i--;
                            estado = 0;
                            auxLex = "";

                        }
                        break;
                    case 5:
                        if (chars[i].Equals('!'))
                        {
                            estado = 6;
                            columna++;
                            auxLex += chars[i];
                        }
                        else
                        {

                            if (chars[i].Equals((char)10) || chars[i].Equals((char)13))
                            {
                                fila++;
                                columna = 0;
                                auxLex += chars[i];

                            }
                            else
                            {
                                auxLex += chars[i];
                                columna++;
                            }

                        }
                        break;
                    case 6:
                        if (chars[i].Equals('>'))
                        {
                            //Ignora y resgresa a estado 0
                            auxLex += chars[i];

                            simbolos.Add(new Token(auxLex, 2, "Comentario multilinea", fila, columna));
                            estado = 0;
                            auxLex = "";

                        }
                        else
                        {
                            auxLex += chars[i];
                            columna++;
                            estado = 5;
                        }
                        break;
                    case 7:
                        if (chars[i].Equals(':'))
                        {
                            estado = 11;
                            //auxLex += chars[i];
                        }
                        else
                        {
                            
                            columna++;
                            errores.Add(new Errores(auxLex, columna, fila));
                            auxLex = "";
                            estado = 0;
                            i--;


                            
                        }


                        break;
                    case 8:
                        if (char.IsDigit(chars[i]) || char.IsLetter(chars[i]) || chars[i].Equals('_'))
                        {
                            auxLex += chars[i];
                            columna++;
                        }
                        else
                        {
                            if (auxLex.Equals("CONJ"))
                            {
                                simbolos.Add(new Token(auxLex, 20, "Palabra reservada", fila, columna));
                                auxLex = "";
                                estado = 0;
                            }
                            else
                            {

                                if (chars[i] == '~' || chars[i] == ';' || chars[i] == ',')
                                {
                                    simbolos.Add(new Token(auxLex, 7, "Letras", fila, columna));
                                    auxLex = "";
                                    estado = 0;
                                }
                                else
                                {
                                    simbolos.Add(new Token(auxLex, 5, "Identificadores", fila, columna));
                                    auxLex = "";
                                    estado = 0;
                                }

                            }

                            i--;
                        }
                        break;

                    case 9:
                        if (chars[i] == '"' && chars[i-1]!='\\')
                        {
                            simbolos.Add(new Token(auxLex, 11, "Lexema/Cadena", fila, columna));
                            auxLex = "";
                            estado = 0;
                        }
                        else
                        {
                            auxLex += chars[i];
                            columna++;
                        }

                        break;
                    case 10:
                        if (chars[i].Equals( '>'))
                        {
                            auxLex += chars[i];
                            simbolos.Add(new Token(auxLex, 6, "Asignacion", fila, columna));
                            auxLex = "";
                            estado = 0;

                        }
                        else
                        {
                            simbolos.Add(new Token(auxLex, 21, "Simbolo", fila, columna));
                            auxLex = "";

                            estado = 0;
                            i--;

                        }
                        break;
                    case 11:
                        if (chars[i].Equals(':'))
                        {
                            //auxLex += chars[i];
                            estado = 16;
                            columna++;
                        }
                        else
                        {
                            auxLex += chars[i];
                        }
                        break;
                        
                    
                    case 16:
                        if (chars[i].Equals(']'))
                        {
                            //auxLex += chars[i];
                            simbolos.Add(new Token(auxLex, 27, "Lo que sea", fila, columna));
                            columna++;
                            estado = 0;
                            auxLex = "";


                        }
                        else
                        {
                            auxLex += chars[i];
                            estado = 11;
                        }
                        break;
                }




            }

            guardarConjuntos();
            guardarER();
            guardarLex();
            generarThompson();
    }

        private void generarThompson()
        {
            try
            {
                for (int i = 0; i < expresiones.Count; i++)
                {
                    ExpReg temp = (ExpReg)expresiones[i];
                    temp.generarT();

                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("ERROR");
            }
            
        }

        private void guardarLex()
        {
            Token salida;
            Token temp;
            Token temp2;
            for (int i = 2; i < simbolos.Count; i++)
            {
                salida = (Token)simbolos[i];
                temp = (Token)simbolos[i-1];
                temp2 = (Token)simbolos[i - 2];
                if (salida.getToken() == 11 && temp.getToken() == 9)
                {

                    lexemas.Add(new Lexema(salida.getLexema(), temp2.getLexema()));
                }
            }

        }

        private void guardarConjuntos()
        {
            String nombre = "";
            //Bandeara para saber si esta dentro de un conjunto o no
            Boolean dentroC = false;
            //Bandera para saber si es conjunto o macro
            // macro = 0   CONJ: ID -> char ~ char ;
            //conjunto = 1  CONJ: ID -> char,char,char ;
            //conjunto = 
            int tipo = 3;
            Boolean ayuda = false;
            Conjunto temp = null;
            Token salida;
            Token t=null;
            Token temporal;
            for (int i = 0; i < simbolos.Count; i++)
            {
                salida = (Token)simbolos[i];
                if (salida.getToken() == 20)
                {
                    dentroC = true;
                    //Determino el tipo
                    temporal = (Token)simbolos[i+5];
                    t = (Token)simbolos[i +4];
                    if (temporal.getToken() == 13)
                    {
                        tipo = 0;
                        ayuda = false;
                    }
                    else if (temporal.getToken() == 12)
                    {
                        tipo = 1;
                    }else if (t.getToken() == 27)
                    {
                        tipo = 2;
                    }

                }
                else if (salida.getToken() == 5)
                {
                    nombre = salida.getLexema();

                }
                if (dentroC)
                {
                    //esta dentro tiene que evaluar entre los dos casos
                    if (tipo == 0)
                    {
                        if (salida.getToken() == 13)
                        {
                            //Si es virgulilla ignora
                            ayuda = true;
                        }
                        else if (salida.getToken() == 10)
                        { //Si es punto y coma termino de guardar conjuntos
                            dentroC = false;
                        }
                        else
                        {//Debe guardar
                            if (ayuda)
                            {
                                Conjunto n = new Conjunto(nombre);
                                temporal = (Token)simbolos[i -2];
                                n.llenar(temporal.getLexema()[0], salida.getLexema()[0]);
                                conjuntos.Add(n);
                                ayuda = false;
                            }
                        }
                    }
                    else if (tipo == 1)
                    {

                        if (salida.getToken() == 12)
                        {
                            //Si es coma ignora
                        }
                        else if (salida.getToken() == 10)
                        { //Si es punto y coma termino de guardar conjuntos
                            dentroC = false;
                            conjuntos.Add(temp);

                        }
                        else if (salida.getToken() == 6)
                        {
                            ayuda = true;
                            temp = new Conjunto(nombre);

                        }
                        else
                        {//Debe guardar
                            if (ayuda)
                            {
                                if (salida.getToken() == 23)//salto de linea
                                {
                                    temp.add(10);
                                }
                                else if (salida.getToken() == 24)//tabulacion
                                {
                                    temp.add(9);
                                }
                                else if (salida.getToken() == 25)//comilla simples
                                {
                                    temp.add(39);
                                }
                                else if (salida.getToken() == 26)//comillas dobles
                                {
                                    temp.add(34);
                                }
                                else
                                {
                                    temp.agregar(salida.getLexema()[0]);
                                }
                                
                            }
                        }
                    }else if(tipo == 2)
                    {
                        char[] arr = t.getLexema().ToArray();
                        //Guarde y sali
                        t = (Token)simbolos[i+2];
                        nombre = t.getLexema();
                        Conjunto n = new Conjunto(nombre);
                        
                        foreach (char item in arr)
                        {
                            n.agregar(item);
                        }
                        conjuntos.Add(n);
                        dentroC = false;
                    }
                }
            }
        }

        private void guardarER()
        {
            String name = "";
            //Bandera si encontro un id donde si esta la ER
            Boolean bandera = false;

            ExpReg temp = null;
            Token salida;
            Token temporal;
            Token temporal1;
            Token temporal2;
            for (int i = 0; i < simbolos.Count - 3; i++)
            {
                salida = (Token)simbolos[i];
                if (salida.getToken() == 5)
                {
                    temporal = (Token)simbolos[i - 2];
                    temporal1 = (Token)simbolos[i + 2];
                    temporal2 = (Token)simbolos[i + 3];
                    if (temporal.getToken() != 20 && temporal1.getToken() != 11 && temporal2.getToken() != 10 && !bandera)
                    {
                        name = salida.getLexema();
                        bandera = true;
                        i++;

                        temp = new ExpReg(name);
                    }
                }
                if (bandera)
                {
                    if (salida.getToken() == 10)
                    {
                        

                        
                        expresiones.Add(temp);

                        bandera = false;

                    }
                    else
                    {
                        if (salida.getToken() == 3 || salida.getToken() == 4)
                        {
                            //ignora
                        }
                        else
                        {
                            temp.addToken(salida);

                        }

                    }
                }
            }
        }

        private Boolean isSymbol(char c)
        {
            return (c >= ' ' && c <= '}') && !(c >= 'A' && c <= 'Z') && !(c >= 'a' && c <= 'z');
        }

    }
}
