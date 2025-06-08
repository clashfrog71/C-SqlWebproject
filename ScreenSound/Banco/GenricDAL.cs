using ScreenSound.Modelos;

namespace ScreenSound.Banco;
internal abstract class GenricDAL <T>
{
    public abstract IEnumerable<T> Listar();
    public abstract void Adicionar(T item);
    public abstract void Excluir(T item);
    public abstract void Atualizar(T item);

}
