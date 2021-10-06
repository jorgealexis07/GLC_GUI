using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Parsing;

namespace GLCGUI.ControlGrafico
{
    public delegate void DelegadoT(EventArgst evento);
    public class ControlDOT
    {
        public static event DelegadoT Proc;
        private static int contador;
        private static String grafo;
        
        public static String getDOT(ParseTreeNode raiz) {
            grafo = "digraph G{";
            grafo += "nodo0[color=blue,label=\"" + escapar(raiz.ToString())  +"\"];\n";
            contador = 1;
            recorrerAST("nodo0", raiz);
            grafo += "}";  
            return grafo;
        }

        
        public static void recorrerAST(String padre, ParseTreeNode hijos) {
            foreach (ParseTreeNode hijo in hijos.ChildNodes) {
                String nombreHijo = "nodo" + contador.ToString();
                grafo += nombreHijo + "[label=\"" + escapar(hijo.ToString()) + "\"];\n";
                grafo += padre + "->" + nombreHijo + ";\n";
                contador++;
                string proc = padre + "->" + nombreHijo + "\n";
                EventArgst e = new EventArgst();
                e.Resultados = proc;
                OnEGTabla(e);  
                recorrerAST(nombreHijo, hijo);
                }
        }

        public static void OnEGTabla(EventArgst args)
        {
            if (Proc != null)
                Proc(args);
        }

        private static String escapar(String cadena) {
            cadena = cadena.Replace("\\","\\\\");
            cadena = cadena.Replace("\"","\\\"");
            return cadena;
        }

    }
}
