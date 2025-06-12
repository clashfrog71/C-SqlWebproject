using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(GenricDAL<Artista> a)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
