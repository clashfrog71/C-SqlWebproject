﻿using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class ArtistaDAL
{
    public IEnumerable<Artista> Listar()
    {
        var lista = new List<Artista>();
        Conexao conexao = new Conexao();
        using var connection = conexao.ObterConexao();
        connection.Open();

        string ComandoSql = "SELECT * FROM Artistas";
        SqlCommand sql = new SqlCommand(ComandoSql, connection);
        using SqlDataReader sqlDataReader = sql.ExecuteReader();

        while (sqlDataReader.Read())
        {
            string nomeArtista = Convert.ToString(sqlDataReader["Nome"]);
            string bioArtista = Convert.ToString(sqlDataReader["Bio"]);
            int idArtista = Convert.ToInt32(sqlDataReader["Id"]);
            Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };
            lista.Add(artista);
        }
        return lista;

    }
    public void Adicionar(Artista artista)
    {
        using var connection = new Conexao().ObterConexao();
        connection.Open();
        string sqlcommand = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
        SqlCommand sql = new SqlCommand(sqlcommand, connection);
        sql.Parameters.AddWithValue("@nome", artista.Nome);
        sql.Parameters.AddWithValue("@perfilPadrao", artista.Nome);
        sql.Parameters.AddWithValue("@bio", artista.Nome);
        int linhasAfetadas = sql.ExecuteNonQuery();
        Console.WriteLine(linhasAfetadas);
    }
    public void Exluir(Artista artista)
    {
        using var connection = new Conexao().ObterConexao();
        connection.Open();
        string sqlcommand = "DELETE FROM Artistas WHERE Id = @id";
        SqlCommand sql = new SqlCommand(sqlcommand, connection);
        sql.Parameters.AddWithValue("@id", artista.Id);
        int linhasAfetadas = sql.ExecuteNonQuery();
        Console.WriteLine(linhasAfetadas);
    }
    public void Atualizar(Artista artista) 
    {
        using var connection = new Conexao().ObterConexao();
        connection.Open();
        string sqlcommand = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
        SqlCommand sql = new SqlCommand(sqlcommand, connection);
        sql.Parameters.AddWithValue("@nome", artista.Nome);
        sql.Parameters.AddWithValue("@perfilPadrao", artista.Nome);
        sql.Parameters.AddWithValue("@bio", artista.Nome);
        int linhasAfetadas = sql.ExecuteNonQuery();
        Console.WriteLine(linhasAfetadas);
    }
}
