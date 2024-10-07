using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMySql
{
    internal class Categoria
    {
        private int id;
        private string nome;
        private Conexao cx = new Conexao("localhost", "app_mysql");
        private string erro;

        public int getId(){return id;}

        public void setId(int id) { this.id = id; }

        public string getNome() { return nome; }

        public void setNome(string nome) { this.nome = nome; }

        public string getErro() { return erro; }

        public Categoria() { }

        public Categoria(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public bool salvar() 
        {
            try
            {
                string cmdSql = $"INSERT INTO categoria (nome) values('{nome}')";
                if (cx.INSERT(cmdSql) > 0)
                {
                    id = cx.getLastId();
                    return true;
                }
                return false;
            }
            catch (Exception e) 
            {
                this.erro = e.Message;
                return false;
            }
        }
        
        public List<Categoria> listar(string filtro="") 
        {
            try
            {
                string cmdSql = $"SELECT * FROM categoria WHERE nome LIKE '%{filtro}%' ORDER BY nome";
                DataTable dados = cx.SELECT(cmdSql) ;
                if (dados == null) return null;
              
                if (dados.Rows.Count < 1) return null;

                List<Categoria> categorias = new List<Categoria>();
                foreach (DataRow linha in dados.Rows) 
                    categorias.Add(new Categoria(Convert.ToInt32(linha["id"]), linha["nome"].ToString()));

                return categorias;
            }
            catch (Exception e) 
            {
                this.erro = e.Message;
                return null;
            }
        }

        public Categoria consultarPorId(int id) 
        {
            try
            {
                string cmdSql = $"SELECT * FROM categoria WHERE id = '{id}'";
                DataTable dados = cx.SELECT(cmdSql);
                if (dados == null) return null;

                if (dados.Rows.Count < 1) return null;

                DataRow dr = dados.Rows[0];
                //id = Convert.ToInt32(dr["id"]);
                //nome = dr["nome"].ToString();
                //Categoria categoria = new Categoria(id,nome);
                //return categoria;
                return new Categoria(Convert.ToInt32(dr["id"]), dr["nome"].ToString());

            }
            catch (Exception e)
            {
                this.erro = e.Message;
                return null;
            }
        }
        
        public bool editar() 
        {
            try 
            {
                string cmdSql = $"UPDATE categoria set nome = '{nome}' WHERE id = '{id}'";
                return cx.UPDATE(cmdSql) > 0? true: false;
            }
            catch (Exception e) 
            {
                this.erro = e.Message;
                return false;
            }
        }
        
        public bool excluir(int id) 
        {
            try
            {
                string cmdSql = $"Delete from categoria where id = '{id}'";
                return (cx.DELETE(cmdSql) > 0)? true: false;  
            }
            catch (Exception e) 
            {
                this.erro = e.Message;
                return false;
            }
        }

    }
}
