using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using Proyecto_1.Analizador;
using Proyecto_1.Object;

namespace Proyecto_1
{

    public partial class Form1 : Form
    {
        ArrayList ListaPesta = new ArrayList();
        int contarpesta = 0;
        ArrayList Expresiones = new ArrayList();
        ArrayList Lexemas = new ArrayList();
        ArrayList Conjuntos = new ArrayList();
        Lexico analizador = new Lexico();
        int imageAFN = 0;
        int imageAFD = 0;


        public Form1()
        {
            InitializeComponent();
        }


        private void CrearPesta()
        {
            RichTextBox a = new RichTextBox();
            TabPage nuevaPest = new TabPage("Nueva Pestaña " + contarpesta);
            a.Dock = DockStyle.Fill;
            nuevaPest.Controls.Add(a);
            ListaPesta.Add(nuevaPest);
            tabControl1.TabPages.Add(nuevaPest);

            contarpesta++;
            tabControl1.SelectedTab = nuevaPest;
        }

        private void CrearPesta(string name, string contenido)
        {
            RichTextBox a = new RichTextBox();
            TabPage nuevaPest = new TabPage(name);
            a.Dock = DockStyle.Fill;
            a.AppendText(contenido);
            nuevaPest.Controls.Add(a);
            ListaPesta.Add(nuevaPest);
            tabControl1.TabPages.Add(nuevaPest);

            contarpesta++;
            tabControl1.SelectedTab = nuevaPest;
        }

        private void EliminarPesta()
        {
            TabPage current_tab = tabControl1.SelectedTab;
            ListaPesta.Remove(current_tab);
            tabControl1.TabPages.Remove(current_tab);
            contarpesta--;
        }

        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearPesta();
        }

        private void eliminarPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarPesta();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TabPage current_tab = tabControl1.SelectedTab;
            Console.WriteLine(current_tab.Text);

            txtConsola.AppendText("a");


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string contenido = "";
            string name = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog1.FileName);
                List<string> lines = File.ReadAllLines(openFileDialog1.FileName).ToList();
                foreach (string line in lines)
                {
                    contenido += line + "\n";
                }
                string[] path = openFileDialog1.FileName.Split('\\');
                name = path[path.Length - 1];
                CrearPesta(name, contenido);

            }
        }

        private void analizarDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList tempT = new ArrayList();
            Control controlBox;

            if (tabControl1.SelectedTab.HasChildren)
            {
                string nombres = tabControl1.SelectedTab.Text;
                string[] a = nombres.Split('.');
                nombres = a[0];
                foreach (Control item in tabControl1.SelectedTab.Controls)
                {
                    controlBox = item;
                    if (controlBox is RichTextBox)
                    {
                        analizador.escanear(controlBox.Text, tabControl1.SelectedTab.Text);
                        tempT = analizador.getSimbolos();
                        //Genera el html de los reportes
                        StreamWriter FilaRThtml = new StreamWriter(nombres + "RT.html");
                        FilaRThtml.Write(htmlRT(tempT));
                        FilaRThtml.Close();
                        //XML tokens
                        StreamWriter FileXMLT = new StreamWriter(nombres + "RT.xml");
                        FileXMLT.Write(xmlRT(tempT));
                        FileXMLT.Close();

                        //Genera el html de los errores

                        tempT = analizador.getErrores();
                        StreamWriter FilaEThtml = new StreamWriter(nombres + "RE.html");
                        FilaEThtml.Write(htmlRE(tempT));
                        FilaEThtml.Close();

                        //XML errores
                        StreamWriter FileXMLE = new StreamWriter(nombres + "RE.xml");
                        FileXMLE.Write(xmlRE(tempT));
                        FileXMLE.Close();
                        //Agrega expresiones regulares y lexemas a memoria
                        Lexemas.AddRange(analizador.getLexemas());
                        Expresiones.AddRange(analizador.getExpresiones());
                        Conjuntos.AddRange(analizador.getConjuntos());

                    }
                }

                generarThompson();
            }
            //Colocar imagen inicial en el afn
            ExpReg ex = (ExpReg)Expresiones[0];
            picAFN.Image = Image.FromFile(ex.getNombre()+"_AFN.png");



            //Colocar imagen inicial en el afd
            //picAFD.Image = Image.FromFile(ex.getNombre() + "_AFD.png");



        }

        private void generarThompson()
        {
            //recorro la lista de ER para generar sus AFN
            for (int i = 0; i < Expresiones.Count; i++)
            {
                ExpReg temp = (ExpReg)Expresiones[i];
                temp.generarT();
            }
        }

        private string xmlRT(ArrayList t)
        {
            string xml = "";
            xml += "<ListaTokens>\n";
            for (int i = 0; i < t.Count; i++)
            {
                Token at = (Token)t[i];
                xml += "  <Token>\n";
                xml += "      <Nombre>" + at.getToken() + "</Nombre>\n";
                xml += "      <Valor>" + at.getLexema() + "</Valor>\n";
                xml += "      <Fila>" + at.getFila() + "</Fila>\n";
                xml += "      <Columna>" + at.getColumna() + "</Columna>\n";
                xml += "  </Token>\n";

            }
            xml += "</ListaTokens>\n";
            return xml;
        }
        private string xmlRE(ArrayList t)
        {
            string xml = "";
            xml += "<ListaErrores>\n";
            for (int i = 0; i < t.Count; i++)
            {
                Errores at = (Errores)t[i];
                xml += "  <Error>\n";
                xml += "      <Valor>" + at.getLexema() + "</Valor>\n";
                xml += "      <Fila>" + at.getFila() + "</Fila>\n";
                xml += "      <Columna>" + at.getColumna() + "</Columna>\n";

                xml += "  </Error>\n";

            }
            xml += "</ListaErrores>\n";
            return xml;
        }

        private string htmlRE(ArrayList t)
        {
            string html = "";
            html += "<!DOCTYPE html>  \n";
            html += "<html>  \n";
            html += "<head><title>Reporte de errores</title></head>  \n";
            html += "<body> \n";
            html += "<h1>Listado de errores</h1>  \n";
            html += "<table border=\"1px\" solid #0000 border-collapse: collapse>   \n";
            html += "<tr>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Error</th>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Tipo</th>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Fila</th>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Columna</th>  \n";
            html += "</tr>  \n";
            for (int i = 0; i < t.Count; i++)
            {
                Errores at = (Errores)t[i];
                html += "<tr> \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getLexema() + "</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> Error Lexico</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getFila() + "</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getColumna() + "</td>  \n";

                html += "</tr> \n";
            }


            html += "</table> \n";
            html += "</body>  \n";
            html += "</html>  \n";
            return html;
        }

        private void reporteLexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombres = tabControl1.SelectedTab.Text;
            string[] a = nombres.Split('.');
            nombres = a[0];
            System.Diagnostics.Process.Start(nombres + "RT.html");
            System.Diagnostics.Process.Start(nombres + "RE.html");
            System.Diagnostics.Process.Start(nombres + "RT.xml");
            System.Diagnostics.Process.Start(nombres + "RE.xml");
        }

        private void htmlLex()
        {
            string html = "";
            html += "<!DOCTYPE html>  \n";
            html += "<html>  \n";
            html += "<head><title>Reporte de tokens</title></head>  \n";
            html += "<body> \n";
            html += "<h1>Listado de cursos</h1>  \n";
            html += "<table border=\"1px\" solid #0000 border-collapse: collapse>   \n";
            html += "<tr>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Identificador</th>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Lexema</th>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Aceptacion</th>  \n";

            html += "</tr>  \n";
            for (int i = 0; i < Lexemas.Count; i++)
            {
                Lexema at = (Lexema)Lexemas[i];
                html += "<tr> \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getID() + "</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getCadena() + "</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getEstado() + "</td>  \n";


                html += "</tr> \n";
            }


            html += "</table> \n";
            html += "</body>  \n";
            html += "</html>  \n";
            StreamWriter FilaEThtml = new StreamWriter("RLexemas.html");
            FilaEThtml.Write(html);
            FilaEThtml.Close();
        }

        private void xmlLex()
        {
            string xml = "";
            xml += "<ListaLexemas>\n";
            for (int i = 0; i < Lexemas.Count; i++)
            {
                Lexema at = (Lexema)Lexemas[i];
                xml += "  <Error>\n";
                xml += "      <Identificador>" + at.getID() + "</Identificador>\n";
                xml += "      <Lexema>" + at.getCadena() + "</Lexema>\n";
                xml += "      <Evaluacion>" + at.getEstado() + "</Evaluacion>\n";

                xml += "  </Error>\n";


                xml += "</ListaLexemas>\n";
            }
            StreamWriter File = new StreamWriter("RLexemas.xml");
            File.Write(xml);
            File.Close();

        }

        private string htmlRT(ArrayList t)
        {
            string html = "";
            html += "<!DOCTYPE html>  \n";
            html += "<html>  \n";
            html += "<head><title>Reporte de tokens</title></head>  \n";
            html += "<body> \n";
            html += "<h1>Listado de cursos</h1>  \n";
            html += "<table border=\"1px\" solid #0000 border-collapse: collapse>   \n";
            html += "<tr>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Token</th>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Lexema</th>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Fila</th>  \n";
            html += "<th border=\"1px\" solid #0000 border-collapse: collapse> Columna</th>  \n";
            html += "</tr>  \n";
            for (int i = 0; i < t.Count; i++)
            {
                Token at = (Token)t[i];
                html += "<tr> \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getToken() + "</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getLexema() + "</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getFila() + "</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getColumna() + "</td>  \n";

                html += "</tr> \n";
            }


            html += "</table> \n";
            html += "</body>  \n";
            html += "</html>  \n";
            return html;
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prueba();
        }

        public void prueba()
        {
            txtConsola.Clear();
            txtConsola.AppendText("--------------------------- \n");
            txtConsola.AppendText("-------- CONJUNTOS -------- \n");
            txtConsola.AppendText("--------------------------- \n");
            for (int i = 0; i < Conjuntos.Count; i++)
            {
                Conjuntos temp = (Conjuntos)Conjuntos[i];
                txtConsola.AppendText("Nombre: " + temp.getNombre() + " ");
                for (int j = 0; j < temp.getConjunt().Count; j++)
                {
                    txtConsola.AppendText("" + temp.getConjunt()[j] + " ");
                }
                txtConsola.AppendText(" \n");
            }
            txtConsola.AppendText(" \n");
            txtConsola.AppendText("--------------------------------- \n");
            txtConsola.AppendText("----- Expresiones Regulares -------- \n");
            txtConsola.AppendText("---------------------------------- \n");
            for (int i = 0; i < Expresiones.Count; i++)
            {
                ExpReg temporal = (ExpReg)Expresiones[i];
                txtConsola.AppendText("Nombre: " + temporal.getNombre() + " ");
                for (int j = 0; j < temporal.getThompson().Count; j++)
                {
                    Thompson t = (Thompson)temporal.getThompson()[j];
                    txtConsola.AppendText("De " + t.getInicio() + " a " + t.getFinal() + " se traslada con " + t.getTransicion());

                }
                txtConsola.AppendText(" \n");
                for (int j = 1; j < temporal.getTokens().Count; j++)
                {
                    Token tok = (Token)temporal.getTokens()[j];
                    txtConsola.AppendText(tok.getLexema());

                }
                txtConsola.AppendText(" \n");


            }
        }

        private void limpiarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expresiones.Clear();
            Lexemas.Clear();
            Conjuntos.Clear();

        }

        private void analizarLexemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpReg expresion = new ExpReg("Examen");
            Token tok = new Token("Prueba", 5, "ID");
            Token tok1 = new Token(".", 16, "conca");
            Token tok2 = new Token("|", 17, "CADENA");
            Token tok3 = new Token("a", 5, "ciclo");
            Token tok4 = new Token("b", 5, "OR");
            Token tok5 = new Token("*", 15, "ID");
            Token tok6 = new Token("c", 11, "CADENA");

            
            
            expresion.addToken(tok);

            expresion.addToken(tok1);
            expresion.addToken(tok2);
            expresion.addToken(tok3);
            expresion.addToken(tok4);
            expresion.addToken(tok5);
            expresion.addToken(tok6);
            
            //expresion.addToken(tok3);
            for (int i =0; i < expresion.getTokens().Count; i++)
            {
                Token tokA = (Token)expresion.getTokens()[i];
                txtConsola.AppendText(tokA.getLexema());
                Console.WriteLine(tokA.getLexema());
            }
            expresion.generarT();
            Console.WriteLine("");
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Siguiente AFD
            if (imageAFD + 1 == Expresiones.Count)
            {
                imageAFD = 0;
                ExpReg ex = (ExpReg)Expresiones[imageAFD];
                picAFD.Image = Image.FromFile(ex.getNombre() + "_AFD.png");
            }
            else
            {
                imageAFD++;
                ExpReg ex = (ExpReg)Expresiones[imageAFD];
                picAFD.Image = Image.FromFile(ex.getNombre() + "_AFD.png");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Siguiente AFN
            if(imageAFN+1 == Expresiones.Count)
            {
                imageAFN = 0;
                ExpReg ex = (ExpReg)Expresiones[imageAFN];
                picAFN.Image = Image.FromFile(ex.getNombre() + "_AFN.png");
            }
            else
            {
                imageAFN++;
                ExpReg ex = (ExpReg)Expresiones[imageAFN];
                picAFN.Image = Image.FromFile(ex.getNombre() + "_AFN.png");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Atras AFN
            if (imageAFN ==0)
            {
                imageAFN = Expresiones.Count-1;
                ExpReg ex = (ExpReg)Expresiones[imageAFN];
                picAFN.Image = Image.FromFile(ex.getNombre() + "_AFN.png");
            }
            else
            {
                imageAFN--;
                ExpReg ex = (ExpReg)Expresiones[imageAFN];
                picAFN.Image = Image.FromFile(ex.getNombre() + "_AFN.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Atras AFD
            if (imageAFD == 0)
            {
                imageAFD = Expresiones.Count - 1;
                ExpReg ex = (ExpReg)Expresiones[imageAFD];
                picAFD.Image = Image.FromFile(ex.getNombre() + "_AFD.png");
            }
            else
            {
                imageAFD--;
                ExpReg ex = (ExpReg)Expresiones[imageAFD];
                picAFD.Image = Image.FromFile(ex.getNombre() + "_AFD.png");
            }
        }
    }
}