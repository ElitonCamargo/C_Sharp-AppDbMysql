using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMySql
{
    public partial class Container : Form
    {
        public Container()
        {
            InitializeComponent();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categoria_Cadastrar fcc = new Categoria_Cadastrar();
            fcc.MdiParent = this; // Definir que ele irá abrir dentro do container
            fcc.Show();
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categoria_Listar categoria_Listar = new Categoria_Listar();
            categoria_Listar.MdiParent = this;
            categoria_Listar.Show();
        }
    }
}
