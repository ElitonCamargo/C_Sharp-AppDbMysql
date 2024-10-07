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
    public partial class Categoria_Listar : Form
    {
        public Categoria_Listar()
        {
            InitializeComponent();
        }

        private void Categoria_Listar_Load(object sender, EventArgs e)
        {
            ListarCategorias();
        }

        private void ListarCategorias(string filtro = "")
        {
            Categoria categoria = new Categoria();
            List<Categoria> categorias = categoria.listar(filtro);
            if (categorias != null)
            {
                dtgCategorias.Rows.Clear();
                foreach (Categoria c in categorias) 
                {
                    dtgCategorias.Rows.Add(c.getId(),c.getNome(),"Editar","Excluir");
                }
                lblInfo.Visible = false;
            }
            else 
            {
                lblInfo.Visible = true;
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {                      
            ListarCategorias();
        }


        private void txtConsultar_TextChanged(object sender, EventArgs e)
        {
            ListarCategorias(txtConsultar.Text);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(38, 38);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(36, 36);
        }
    }
}
