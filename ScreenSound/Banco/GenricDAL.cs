using ScreenSound.Modelos;

namespace ScreenSound.Banco;
internal abstract class GenricDAL <T> where T : class
{
    protected readonly ScreenSoundContext context;
    protected GenricDAL(ScreenSoundContext context)
    {
        this.context = context;
    }
    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }
    public void Adicionar(T item)
    {
        context.Set<T>().Add(item);
        context.SaveChanges();
    }
    public void Excluir(T item)
    {
        context.Set<T>().Remove(item);
        context.SaveChanges();
    }
    public void Atualizar(T item)
    {
        context.Set<T>().Add(item);
        context.SaveChanges();
    }
    public T RecuperarPor(Func<T,bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao) ?? throw new InvalidOperationException("Item não encontrado");
    }

}
