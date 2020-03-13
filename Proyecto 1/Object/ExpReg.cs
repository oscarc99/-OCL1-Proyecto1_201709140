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
        ArrayList thompson = new ArrayList();//Ayuda para graficar lista de thompson
        ArrayList thomp = new ArrayList();//ayuda para crear AFD lista de Thomp
        int conteo = 0;
        int iterador = 1;
        int iteraE=0;
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

        public void generarT()
        {
            thompson.Clear();
            conteo = 0;
            iterador = 1;
            llenar();
            tablaT();
            graficarThompson();
            for (int i = 0; i < thomp.Count; i++)
            {
                Thomp te = (Thomp)thomp[i];
                Console.WriteLine(te.getName()+" que apunta  a "+ te.getApuntadores()+" con "+ te.getTransicion());
            }
        }

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
                    if(i == temp.getInicio())
                    {
                        nuevo.setTrans(temp.getTransicion());
                        nuevo.add(temp.getFinal());

                    }
                }
                thomp.Add(nuevo);
            }
            
        }

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
                else if (temp.getToken() == 18)//Cerradura positiva a.a*
                {


                    ++iterador;
                    if (!llenar().Equals(" "))
                    {
                        thompson.Add(new Thompson(conteo, llenar(), ++conteo));
                    }
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
                else if (temp.getToken() == 5 || temp.getToken() == 7 || temp.getToken() == 18 || temp.getToken() == 14 || temp.getToken() == 11 || temp.getToken() == 23 || temp.getToken() == 24 || temp.getToken() == 25 || temp.getToken() == 26 || temp.getToken() == 27)
                {
                    return temp.getLexema();
                }
            }
            return " ";
        }
        public void generarDFA()
        {
            ArrayList a = new ArrayList();
            cerradura(a);
        }

        private void cerradura(ArrayList a)
        {

            int cuenta;//Para ver si ya se le recorrio 2 veces pasa al siguiente
            int contador = 0;//Variable que ya recorrio todos los 
            
            
            Estado estado = new Estado(iteraE);
            while (true)
            {
                if(contador == thompson.Count)
                {
                    break;
                }
                
                
            }
        }

        public void graficarThompson()
        {

            StreamWriter FilaRThtml = new StreamWriter(Nombre + "_AFN.dot");
            string afn="";
            afn += "digraph G { \n";
            afn += "nodesep=0.8; \n";
            afn += "ranksep=0.5; \n";
            afn += "rankdir = LR; \n";
            afn += "node[shape = circle ]; \n";
            for(int i = 0; i < thompson.Count; i++)
            {
                Thompson temp = (Thompson) thompson[i];
                afn += temp.getInicio() + "->" + temp.getFinal()+ " [ label = \" "+temp.getTransicion()+"\"]; \n";
                if(i == thompson.Count - 1)
                {
                    if(temp.getInicio() > temp.getFinal())
                    {
                        afn += temp.getInicio()+"[ shape = doublecircle];";
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
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c dot -Tpng -o "+Nombre+"_AFN.png "+Nombre+"_AFN.dot");
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
