using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppMySql
{
    internal class Conexao
    {
        private MySqlConnection objConexao = new MySqlConnection();
        private MySqlCommand objComandos = new MySqlCommand();
        private MySqlDataAdapter objDadosEmMemoria;
        private string str_connection;
        private int lastId;

        public Conexao(string server, string dataBase, string user = "root", string password = "")
        {
            str_connection = "Persist Security Info=False;";
            str_connection += $"Server={server};";
            str_connection += $"Database={dataBase};";
            str_connection += $"User={user};";
            str_connection += $"Pwd={password};";
            str_connection += $"SslMode=none";
        }

        public int getLastId()
        {
            return this.lastId;
        }

        private bool conectar()
        {
            try
            {
                desconectar();
                objConexao.ConnectionString = str_connection;

                objComandos.Connection = objConexao;

                objConexao.Open();
                return true;
            }
            catch 
            {
                throw;
            }
        }

        private bool desconectar()
        {
            try
            {
                if (objConexao.State == ConnectionState.Open)
                {
                    objConexao.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool testarConexao()
        {
            bool result = conectar();
            desconectar();
            return result;
        }

        public int INSERT(string comandoSql)
        {
            try
            {
                if (conectar())
                {
                    objComandos.CommandText = comandoSql;
                    int result = objComandos.ExecuteNonQuery();
                    if (result > 0)
                    {
                        DataTable retorno = SELECT("SELECT LAST_INSERT_ID() as lastId");
                        this.lastId = Convert.ToInt32(retorno.Rows[0]["lastId"]);
                        return result;
                    }                    
                    desconectar();
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public DataTable SELECT(string comandoSql)
        {
            try
            {
                if (conectar())
                {
                    this.objDadosEmMemoria = new MySqlDataAdapter(comandoSql, objConexao);



                    DataTable tabelaDeDados = new DataTable();



                    objDadosEmMemoria.Fill(tabelaDeDados);



                    if (tabelaDeDados.Rows.Count > 0)
                    {
                        return tabelaDeDados;
                    }
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public int DELETE(string comandoSql)
        {
            try
            {
                if (conectar())
                {
                    objComandos.CommandText = comandoSql;
                    int result = objComandos.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return result;
                    }                   
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public int UPDATE(string comandoSql)
        {
            try
            {
                if (conectar())
                {
                    objComandos.CommandText = comandoSql;
                    int result = objComandos.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return result;
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }
    }
}
