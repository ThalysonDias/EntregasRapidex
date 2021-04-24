using System.Data;
using MySql.Data.MySqlClient;

namespace AppWeb.Config
{
    public interface IConexao
    {
         IDbConnection OpenConnection();
    }
}