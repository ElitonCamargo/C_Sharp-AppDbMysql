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
    public partial class Categoria_Cadastrar : Form
    {
        public Categoria_Cadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            if (nome.Length < 3) 
            {
                MessageBox.Show(
                    "Nome inválido!!!",
                    "Stop", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtNome.Focus();
                return;
            }

            Categoria categoria = new Categoria();
            categoria.setNome(nome);
            if (categoria.salvar()) 
            {
                txtId.Text = categoria.getId().ToString();
                MessageBox.Show(
                    "Categoria cadastrada com sucesso!!!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else 
            {
                MessageBox.Show(
                    $"Erro ao cadastrar categoria\nErro: {categoria.getErro()}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }


        }
    }
}
