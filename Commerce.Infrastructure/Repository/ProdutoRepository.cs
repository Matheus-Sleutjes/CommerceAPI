using Commerce.Domain.Dto;
using Commerce.Domain.Entitie;
using Commerce.Infrastructure.Context;
using Commerce.Infrastructure.Contract;
using Commerce.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Repository
{
    public class ProdutoRepository(CommerceContext _context) : IProdutoRepository
    {
        public Produto Get(int id)
        {
            return _context.Produtos.AsNoTracking().Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Produto> GetByName(string name)
        {
            return _context.Produtos.AsNoTracking().Autocomplete(t => t.Nome.Contains(name), o => o.Nome).Take(100).ToList();
        }

        public List<Produto> GetBySort(List<Sort> sorts)
        {
            return _context.Produtos.AsNoTracking().ToSort(sorts);
        }

        public void Add(Produto entity)
        {
            _context.Produtos.Add(entity);
        }

        public void Update(Produto entity)
        {
            _context.Produtos.Update(entity);
        }

        public void Delete(Produto entity)
        {
            _context.Produtos.Remove(entity);
        }

        public void Savechanges()
        {
            _context.SaveChanges();
        }
    }
}
