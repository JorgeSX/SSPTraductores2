using Compilador.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Compilador
{
    public partial class Principal : Form
    {
        public struct Resultado
        {
            public Resultado( string sim, string tip)
            {
                simbolo = sim;
                tipo = tip;
            }
            public string simbolo { get; set; }
            public string tipo { get; set; }
        }

        List<Resultado> resultado = new List<Resultado>();
        Lexico lexico = new Lexico();

        public Principal()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            resultado.Clear();
            lexico.Entrada(rtbEntrada.Text);
            while (lexico.simbolo.CompareTo("$") != 0)
            {
                lexico.SigSimbolo();
                Resultado res = new Resultado(lexico.simbolo, lexico.TipoEncontrado(lexico.tipo));
                resultado.Add(res);
            }

            dgvSimbolos.DataSource = resultado.ToList();
            dgvSimbolos.Refresh();
        }
    }
}
