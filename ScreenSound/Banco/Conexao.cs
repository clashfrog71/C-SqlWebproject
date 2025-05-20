using ScreenSound.Modelos;
using System.Data.SqlClient;

using System.Diagnostics.CodeAnalysis;

namespace ScreenSound.Banco;

internal class Conexao
{
    string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ScreenSound;Integrated Security=True;";

    public SqlConnection ObterConexao()
    {
        return new SqlConnection(connectionString);
    }
    
}
