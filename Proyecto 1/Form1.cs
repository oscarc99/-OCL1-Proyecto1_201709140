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
        ArrayList EXP = new ArrayList();
        ArrayList Lexemas = new ArrayList();
        Lexico analizador = new Lexico();

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
                        //Genera el html de los errores
                        tempT = analizador.getErrores();
                        StreamWriter FilaEThtml = new StreamWriter(nombres + "RE.html");
                        FilaEThtml.Write(htmlRE(tempT));
                        FilaEThtml.Close();
                        //XML tokens
                        StreamWriter FileXMLT = new StreamWriter(nombres + "RT.xml");
                        FileXMLT.Write(xmlRT(tempT));
                        FileXMLT.Close();
                        //XML errores
                        StreamWriter FileXMLE = new StreamWriter(nombres + "RE.xml");
                        FileXMLE.Write(xmlRE(tempT));
                        FileXMLE.Close();
                        





                    }
                }
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
                xml += "      <Nombre>"+at.getToken()+"</Nombre>\n";
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
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> " + at.getID()+ "</td>  \n";
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
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> "+at.getToken()+"</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> "+at.getLexema()+"</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> "+at.getFila()+"</td>  \n";
                html += "<td border=\"1px\" solid #0000 border-collapse: collapse> "+at.getColumna()+"</td>  \n";

                html += "</tr> \n";
            }


            html += "</table> \n";
            html += "</body>  \n";
            html += "</html>  \n";
            return html;
        }
    }
}