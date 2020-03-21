using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        ArrayList terminales = new ArrayList();//Ayuda para hacer la tabla de transiciones
        ArrayList thompson = new ArrayList();//Ayuda para graficar lista de thompson por transiscion
        ArrayList thomp = new ArrayList();//ayuda para crear AFD lista de Thomp como tabla
        ArrayList estados = new ArrayList();//Tabla de transiciones para dfa
        int conteo = 0;
        int iterador = 1;
        String aux = "";//auxiliar para obtener lista de estados
        int fin = -2;

        public ExpReg()
        {
            conteo = 0;
        }

        public ArrayList getThompson()
        {
            return thompson;
        }
        public ExpReg(string name)
        {
            Nombre = name;
            conteo = 0;
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

        public ArrayList getTokens()
        {
            return tokens;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public void addToken(Token n)
        {
            tokens.Add(n);
        }
        //Genera todo del la ER
        public void generarT()
        {
            thompson.Clear();
            conteo = 0;
            iterador = 1;
            llenar();
            Thompson y = (Thompson)thompson[thompson.Count - 1];
            fin = y.getFinal();
            terminal();
            tablaT();
            graficarThompson();
            generarDFA();
            //imprimirTerminales();
            graficarDFA();
            graficarTabla();


        }



        private void imprimirTerminales()
        {
            Console.WriteLine(Nombre);
            for (int i = 0; i < terminales.Count; i++)
            {
                Token temp = (Token)terminales[i];
                Console.WriteLine(temp.getLexema());
            }
        }

        //Obtiene los terminales de la ER
        private void terminal()
        {
            Boolean bandera = true;
            for (int i = 1; i < tokens.Count; i++)
            {
                Token temp = (Token)tokens[i];
                if (temp.getToken() == 5 || temp.getToken() == 7 || temp.getToken() == 14 || temp.getToken() == 11 || temp.getToken() == 23 || temp.getToken() == 24 || temp.getToken() == 25 || temp.getToken() == 26 || temp.getToken() == 27)
                {
                    bandera = true;
                    for (int j = 0; j < terminales.Count; j++)
                    {
                        Token t = (Token)terminales[j];
                        if (t.Equals(temp))
                        {
                            bandera = false;
                        }
                    }
                    if (bandera)
                    {
                        terminales.Add(temp);
                    }


                }
            }

        }
        //Convierte los thompson en una tabla 
        private void tablaT()
        {
            Thompson final = (Thompson)thompson[thompson.Count - 1];
            Thompson temp;
            for (int i = 0; i < final.getFinal(); i++)
            {
                Thomp nuevo = new Thomp(i);
                //Recorro la lista de thompson buscando uno por uno
                for (int j = 0; j < thompson.Count; j++)
                {
                    temp = (Thompson)thompson[j];
                    if (i == temp.getInicio())
                    {
                        nuevo.setTrans(temp.getTransicion());
                        nuevo.add(temp.getFinal());

                    }
                }
                thomp.Add(nuevo);
            }

        }

        //Genera el AFN como thompsson
        private string llenar()
        {

            if (iterador < tokens.Count)
            {


                Token temp = (Token)tokens[iterador];
                if (temp.getToken() == 17)// OR |
                {
                    int inicio = conteo;
                    thompson.Add(new Thompson(conteo, "ε", ++conteo));
                    ++iterador;
                    if (!llenar().Equals(" "))
                    {
                        thompson.Add(new Thompson(conteo, llenar(), ++conteo));
                    }
                    int fina = conteo;
                    thompson.Add(new Thompson(inicio, "ε", ++conteo));
                    ++iterador;
                    if (!llenar().Equals(" "))
                    {
                        thompson.Add(new Thompson(conteo, llenar(), ++conteo));
                    }
                    thompson.Add(new Thompson(conteo, "ε", ++conteo));
                    thompson.Add(new Thompson(fina, "ε", conteo));

                }
                else if (temp.getToken() == 16)// AND .
                {
                    ++iterador;
                    if (!llenar().Equals(" "))
                    {
                        thompson.Add(new Thompson(conteo, llenar(), ++conteo));
                    }
                    ++iterador;
                    if (!llenar().Equals(" "))
                    {
                        thompson.Add(new Thompson(conteo, llenar(), ++conteo));
                    }


                }
                else if (temp.getToken() == 15)//Cerradura de klin *
                {
                    int inicio = conteo;
                    thompson.Add(new Thompson(conteo, "ε", ++conteo));
                    int t = conteo;
                    ++iterador;
                    if (!llenar().Equals(" "))
                    {
                        thompson.Add(new Thompson(conteo, llenar(), ++conteo));
                    }

                    thompson.Add(new Thompson(conteo, "ε", t));
                    thompson.Add(new Thompson(conteo, "ε", ++conteo));
                    thompson.Add(new Thompson(inicio, "ε", conteo));
                }
                else if (temp.getToken() == 19)// Signo interrogacion ε|a
                {
                    int inicio = conteo;
                    thompson.Add(new Thompson(conteo, "ε", ++conteo));
                    ++iterador;
                    if (!llenar().Equals(" "))
                    {
                        thompson.Add(new Thompson(conteo, llenar(), ++conteo));
                    }

                    thompson.Add(new Thompson(conteo, "ε", ++conteo));
                    int fina = conteo;
                    thompson.Add(new Thompson(inicio, "ε", ++conteo));
                    thompson.Add(new Thompson(conteo, "ε", ++conteo));
                    thompson.Add(new Thompson(conteo, "ε", fina));
                }
                else if (temp.getToken() == 18)//Cerradura positiva a+
                {


                    ++iterador;
                    thompson.Add(new Thompson(conteo, "ε", ++conteo));
                    int t = conteo;
                    if (!llenar().Equals(" "))
                    {
                        thompson.Add(new Thompson(t, llenar(), ++conteo));
                    }
                    thompson.Add(new Thompson(conteo, "ε", t));
                    thompson.Add(new Thompson(conteo, "ε", ++conteo));

                }
                else if (temp.getToken() == 5 || temp.getToken() == 7 || temp.getToken() == 14 || temp.getToken() == 11 || temp.getToken() == 23 || temp.getToken() == 24 || temp.getToken() == 25 || temp.getToken() == 26 || temp.getToken() == 27)
                {

                    return temp.getLexema();
                }
            }
            return " ";
        }
        //Genera el AFD con tabla de transiciones
        public void generarDFA()
        {
            aux = "0";
            cerradura(0, "ε");
            Estado es = new Estado(0, terminales,fin);
            string[] estado = aux.Split(',');
            for (int i = 0; i < estado.Length; i++)
            {
                es.agregar(Int16.Parse(estado[i]));
            }
            estados.Add(es);

            calcular();


            //imprimirEstados();
            //Console.WriteLine("Una mierda");


        }

        private void calcular()
        {
            //recorro los estados
            for (int k = 0; k < estados.Count; k++)
            {
                Estado est = (Estado)estados[k];
                //Recorre todos los terminales
                for (int i = 0; i< terminales.Count; i++)
                {
                    Token item = (Token)terminales[i];
                    string x = cerra(item.getLexema(), est.getConjunt());

                    if (x.Equals(""))
                    {
                        //no encontro con ese terminal
                        //Pasa al siguiente terminal
                    }
                    else
                    {//Encontro mira lo del conjunto
                        string[] arr = x.Split(',');
                        string ayuda = "";
                         
                        Console.WriteLine(Nombre);
                        Console.WriteLine(est.getConjunto());
                        Console.WriteLine(item.getLexema());
                        Console.WriteLine(x);
                        

                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (j == 0)
                            {
                                aux = arr[j];
                                
                                cerradura(Int16.Parse(arr[j]), "ε");
                                ayuda = aux;
                            }
                            else
                            {
                                aux = "," + arr[j];
                                cerradura(Int16.Parse(arr[j]), "ε");
                                ayuda += aux;
                            }

                        }
                        //Console.WriteLine("NUEVO ESTADO");
                        //Console.WriteLine(ayuda);
                        if (!existe(ayuda))
                        {
                            //No existe entonces creo el estado y guardo en cada estado su transicion
                            Estado es = new Estado(estados.Count, terminales,fin );
                            string[] estado = ayuda.Split(',');
                            for (int j = 0; j < estado.Length; j++)
                            {
                                es.agregar(Int16.Parse(estado[j]));
                            }
                            est.setTraslado(i, estados.Count);
                            estados.Add(es);


                        }
                        else
                        {
                            //Si ya existe solo creo la transicion
                            est.setTraslado(i, esta(ayuda));
                        }
                    }

                }



            }
        }

        private int esta(string ayuda)
        {
            foreach (Estado item in estados)
            {
                if (item.getConjunto().Equals(ayuda))
                {
                    return item.getNombre();
                }

            }
            return -1;
        }

        private bool existe(string ayuda)
        {
            foreach (Estado item in estados)
            {
                if (item.getConjunto().Equals(ayuda))
                {
                    return true;
                }

            }
            return false;
        }

        private string cerra(string traslado, ArrayList conj)
        {
            string f = "";
            foreach (Thompson item in thompson)
            {
                if (item.getTransicion().Equals(traslado))
                {
                    if (conj.Contains(item.getInicio()))
                    {
                        if (f.Equals(""))
                        {
                            f += item.getFinal();
                        }
                        else
                        {
                            f += "," + item.getFinal();
                        }
                    }



                }
            }
            return f;
        }

        private void imprimirEstados()
        {
            Console.WriteLine(Nombre);
            for (int i = 0; i < estados.Count; i++)
            {
                Estado est = (Estado)estados[i];
                Console.WriteLine(est.getName() + " - " + est.getNombre());
                for (int j = 0; j < est.getTrans().Count; j++)
                {
                    Token temp = (Token)est.getTrans()[j];
                    Console.WriteLine(temp.getLexema());
                }
            }
        }


        private void cerradura(int x, string traslado)
        {

            foreach (Thompson item in thompson)
            {
                if (item.getInicio() == x && item.getTransicion().Equals(traslado))
                {

                    aux += "," + item.getFinal();
                    cerradura(item.getFinal(), "ε");
                }
            }

        }


        public void graficarThompson()
        {

            StreamWriter FilaRThtml = new StreamWriter(Nombre + "_AFN.dot");
            string afn = "";
            afn += "digraph G { \n";
            afn += "nodesep=0.8; \n";
            afn += "ranksep=0.5; \n";
            afn += "rankdir = LR; \n";
            afn += "node[shape = circle ]; \n";
            for (int i = 0; i < thompson.Count; i++)
            {
                Thompson temp = (Thompson)thompson[i];
                afn += temp.getInicio() + "->" + temp.getFinal() + " [ label = \" " + temp.getTransicion() + "\"]; \n";
                if (i == thompson.Count - 1)
                {
                    if (temp.getInicio() > temp.getFinal())
                    {
                        afn += temp.getInicio() + "[ shape = doublecircle];";
                    }
                    else
                    {
                        afn += temp.getFinal() + "[ shape = doublecircle];";
                    }
                }
            }
            afn += "}";
            FilaRThtml.Write(afn);
            FilaRThtml.Close();
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c dot -Tpng -o " + Nombre + "_AFN.png " + Nombre + "_AFN.dot");
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = false;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();


        }

        private void graficarTabla()
        {
            StreamWriter FilaRThtml = new StreamWriter(Nombre + "_TABLE.dot");
            string table = "";
            table += "digraph G { \n";
            table += "nodesep=0.8; \n";
            table += "ranksep=0.5; \n";
            table += "node_A[shape = record  label = \" {Estado";
            foreach (Estado est in estados)
            {
                table += "|" +est.getName();
            }
            table += "}";
            for (int i = 0; i < terminales.Count; i++)
            {
                table += "|{";
                Token termina = (Token)terminales[i];
                table += termina.getLexema();
                foreach (Estado est in estados)
                {
                    if (est.getTransicion()[i] < 0)
                    {
                        table += "|--";
                    }
                    else
                    {
                        table += "|" + est.getTransicion()[i];
                    }
                }
                table += "}";
            }
            table += "\" ] \n";
            table += "}";
            FilaRThtml.Write(table);
            FilaRThtml.Close();
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c dot -Tpng -o " + Nombre + "_TABLE.png " + Nombre + "_TABLE.dot");
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = false;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }

        private void graficarDFA()
        {
            StreamWriter FilaRThtml = new StreamWriter(Nombre + "_AFN.dot");
            string afd = "";
            afd += "digraph G { \n";
            afd += "nodesep=0.8; \n";
            afd += "ranksep=0.5; \n";
            afd += "rankdir = LR; \n";
            afd += "node[shape = circle ]; \n";
            for (int i = 0; i < thompson.Count; i++)
            {
                Thompson temp = (Thompson)thompson[i];
                afd += temp.getInicio() + "->" + temp.getFinal() + " [ label = \" " + temp.getTransicion() + "\"]; \n";
                if (i == thompson.Count - 1)
                {
                    if (temp.getInicio() > temp.getFinal())
                    {
                        afd += temp.getInicio() + "[ shape = doublecircle];";
                    }
                    else
                    {
                        afd += temp.getFinal() + "[ shape = doublecircle];";
                    }
                }
            }
            afd += "}";
            FilaRThtml.Write(afd);
            FilaRThtml.Close();
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c dot -Tpng -o " + Nombre + "_AFN.png " + Nombre + "_AFN.dot");
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = false;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }

    }


}
