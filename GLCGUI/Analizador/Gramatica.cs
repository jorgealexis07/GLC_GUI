using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Ast;
using Irony.Parsing;

namespace GLCGUI.Analizador
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: false) 
        {
            #region ER
            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "[0-9]+");
            //IdentifierTerminal id = new IdentifierTerminal("id");
            #endregion 

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var div = ToTerm("/");
            #endregion 

            #region NoTerminales
            NonTerminal S = new NonTerminal("S"),
            E = new NonTerminal("E"),
            T = new NonTerminal("T"),
            F = new NonTerminal("F"),
            C = new NonTerminal("C");
            #endregion 

            #region Gramatica
            //Ambigua
            E.Rule = E + mas + T
                | E + menos + T
                | T;
            T.Rule = T + por + F
                | F;
            F.Rule = F + div + F
                | C;
            C.Rule = numero;

            //No ambigua
            //S.Rule = E;
            //E.Rule = E + mas + F
            //    | E + menos + F
            //    | F;
            //F.Rule= F+ por +numero
            //    | F + div+numero
            //    | numero;
        
            #endregion 

            #region Preferencias
            this.Root = E;
            #endregion 
        }
    } 
}
