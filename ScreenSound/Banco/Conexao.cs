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
    public IEnumerable<Artista> Listar()
    {
        var lista = new List<Artista>();
        using var connection = ObterConexao();
        connection.Open();

        string ComandoSql = "SELECT * FROM Artistas";
        SqlCommand sql = new SqlCommand(ComandoSql, connection);
        using SqlDataReader sqlDataReader = sql.ExecuteReader();

        while (sqlDataReader.Read())
        {
            string nomeArtista = Convert.ToString(sqlDataReader["Nome"]);
            string bioArtista = Convert.ToString(sqlDataReader["Bio"]);
            int idArtista = Convert.ToInt32(sqlDataReader["Id"]);
            Artista artista = new(nomeArtista,bioArtista) { Id = idArtista };
            lista.Add(artista);
        }
        return lista;

    }
}
