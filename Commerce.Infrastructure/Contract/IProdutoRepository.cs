using Commerce.Domain.Dto;
using Commerce.Domain.Entitie;

namespace Commerce.Infrastructure.Contract
{
    public interface IProdutoRepository
    {
        Produto Get(int id);
        List<Produto> GetByName(string name);
        List<Produto> GetBySort(List<Sort> sorts);
        void Add(Produto entity);
        void Update(Produto entity);
        void Delete(Produto entity);
        void Savechanges();
    }
}
