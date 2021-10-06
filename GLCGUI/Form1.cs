using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLCGUI.Analizador;
using Irony.Ast;
using Irony.Parsing;
using GLCGUI.ControlGrafico;
using System.Threading;

namespace GLCGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            ParseTreeNode resultado = Sintaxis.analizar(textBox1.Text);
            if (resultado != null)
            {
                label5.Text = "La GLC ha sido aceptada";
                ControlDOT.Proc += new DelegadoT(t_EGTabla);
                pictureBox1.Image = Sintaxis.getImage(resultado);
            }
            else
            {
                label5.Text = "La GLC es Incorrecta";
            }
        }

        public void t_EGTabla(EventArgst args)
        {
              listBox1.Items.Add(args.Resultados);  
        }
    }
}
