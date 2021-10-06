using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Irony.Ast;
using Irony.Parsing;
using System.Windows.Forms;
using System.Drawing;

namespace GLCGUI.Analizador
{
    class Sintaxis:Grammar
    {
        public static ParseTreeNode analizar(String cadena){
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            //ParseTreeNode raiz = arbol.Root;

            //if (raiz == null) {
            //    return false;
            //}
            //generarImagen(raiz);
            //MessageBox.Show("Arbol");
            //return true;
            return arbol.Root;
        }

        public static Image getImage(ParseTreeNode raiz) {  
            string grafoDOT = ControlGrafico.ControlDOT.getDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDOT);
            byte[] imageBytes = Convert.FromBase64String(img.ToBase64String());
            MemoryStream ms = new MemoryStream(imageBytes,0,imageBytes.Length);
            Image Imagen = Image.FromStream(ms,true);
            return Imagen;
        }

        private static void generarImagen(ParseTreeNode raiz) {
            String grafoDOT = ControlGrafico.ControlDOT.getDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDOT);
            img.Save("Arbol.png");
        }
    }
}
