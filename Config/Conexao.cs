using MySql.Data.MySqlClient;
using System.Data;

namespace AppWeb.Config
{
    public class Conexao : IConexao
    {
        public Conexao()
        {           
        }
        public IDbConnection OpenConnection()
        {
            using(MySqlConnection conexao = new MySqlConnection("Server=127.0.0.1; Port=3306; Database=rapidexdb; Uid=root; Pwd=; SslMode=Preferred;"))
            {
                conexao.Open();
                return conexao;
            }
        }
    }
}




