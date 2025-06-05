using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class ArtistaDAL
{
    private readonly ScreenSoundContext context;
    public ArtistaDAL(ScreenSoundContext context)
    {
     this.context = context;
    }
    public IEnumerable<Artista> Listar()
    {
       return context.Artistas.ToList();

    }
    public void Adicionar(Artista artista)
    {
        context.Artistas.Add(artista);
        context.SaveChanges();
    }
    public void Exluir(Artista artista)
    {
        context.Artistas.Remove(artista);
        context.SaveChanges();
    }
    public void Atualizar(Artista artista) 
    {
        context.Artistas.Update(artista);
        context.SaveChanges();
    }
    public IEnumerable<Artista> listar()
    {
        using var context = new ScreenSoundContext();
        return context.Artistas.ToList();
    }
    public Artista? recuperarPeloNome(string nome)
    {
        using var context = new ScreenSoundContext();
        return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
    }
}
