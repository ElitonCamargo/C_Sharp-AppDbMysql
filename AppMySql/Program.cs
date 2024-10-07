using Mysqlx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMySql
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Conexao cx = new Conexao("127.0.0.1", "app_mysql");
            try 
            {
                if (cx.testarConexao())
                {
                    Application.Run(new Container());
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    $"Erro: {erro.Message}",
                    "Erro ao conectar-se ao banco!!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
