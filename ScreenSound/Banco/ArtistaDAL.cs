using ScreenSound.Modelos;
namespace ScreenSound.Banco;
internal class ArtistaDAL : GenricDAL<Artista> 
{
    public ArtistaDAL(ScreenSoundContext context) : base(context)
    {
    }
    public Artista? recuperarPeloNome(string nome)
    {
        using var context = new ScreenSoundContext();
        return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
    }
}
