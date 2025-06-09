using ScreenSound.Banco;
using ScreenSound.Modelos;

internal class MusicaDAL : GenricDAL<Musica>
{
    public MusicaDAL(ScreenSoundContext context) :base(context)
    {
    }
    public Musica? RecuperarPeloNome(string nome)
    {
        return context.Musicas.FirstOrDefault(a => a.Nome.Equals(nome));
    }
}
