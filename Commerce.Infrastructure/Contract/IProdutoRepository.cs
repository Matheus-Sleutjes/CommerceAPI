using Commerce.Domain.Dto;
using Commerce.Domain.Entitie;

namespace Commerce.Infrastructure.Contract
{
    public interface IProdutoRepository
    {
        Produto Get(int id);
        IEnumerable<Produto> GetByName(string name);
        IEnumerable<Produto> GetBySort(IEnumerable<Sort> sorts);
        void Add(Produto entity);
        void Update(Produto entity);
        void Delete(Produto entity);
        void Savechanges();
    }
}
