using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class ArtistaDAL : GenricDAL<Artista>
{
    private readonly ScreenSoundContext context;
    public ArtistaDAL(ScreenSoundContext context)
    {
     this.context = context;
    }
    public override IEnumerable<Artista> Listar()
    {
       return context.Artistas.ToList();

    }
    public override void Adicionar(Artista artista)
    {
        context.Artistas.Add(artista);
        context.SaveChanges();
    }
    public override void Excluir(Artista artista)
    {
        context.Artistas.Remove(artista);
        context.SaveChanges();
    }
    public override void Atualizar(Artista artista)
    {
        context.Artistas.Update(artista);
        context.SaveChanges();
    }
    public Artista? recuperarPeloNome(string nome)
    {
        using var context = new ScreenSoundContext();
        return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
    }
}
