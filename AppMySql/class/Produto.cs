using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMySql
{
    internal class Produto
    {
        private int id;
        private string nome;
        private int quantidade;
        private double valor;
        private Categoria categoria;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double Valor { get => valor; set => valor = value; }
        internal Categoria Categoria { get => categoria; set => categoria = value; }

        public Produto(){}

        public Produto(int id,string nome,int quantidade,double valor,Categoria categoria) 
        {
            this.id = id;
            this.nome = nome;
            this.quantidade = quantidade;
            this.valor = valor;
            this.categoria = categoria;
        }

        public void salvar() { }
        public void listar(string filtro = "") { }
        public void consultarPorId(int id) { }
        public void editar() { }
        public void excluir(int id) { }
    }
}
