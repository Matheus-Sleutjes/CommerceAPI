using Commerce.Application.Contract;
using Commerce.Domain.Dto;
using Commerce.Domain.Entitie;
using Commerce.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Application.Service
{
    public class ProdutoService(IProdutoRepository _produtoRepository) : IProdutoService
    {
        public async Task<ActionResult> Get(int id)
        {
            var entity = _produtoRepository.Get(id);
            if (entity == null) return new NotFoundResult();
            
            return new OkObjectResult(entity);
        }

        public async Task<ActionResult> GetByName(string name)
        {
            var entity = _produtoRepository.GetByName(name);
            if (entity == null) return new NotFoundResult();

            return new OkObjectResult(entity);
        }

        public async Task<ActionResult> GetBySort(List<Sort> sorts)
        {
            var entity = _produtoRepository.GetBySort(sorts);
            if (entity == null) return new NotFoundResult();

            return new OkObjectResult(entity);
        }

        public async Task<ActionResult> Add(ProdutoDto dto)
        {
            if (dto.Valor < 0 || dto.Estoque < 0 || dto.Nome.Length < 3) return new BadRequestResult();

            var entity = new Produto(dto.Nome, dto.Valor, dto.Estoque);

            _produtoRepository.Add(entity);
            _produtoRepository.Savechanges();

            return new NoContentResult();
        }

        public async Task<ActionResult> Delete(int id)
        {
            var entity = _produtoRepository.Get(id);
            if (entity == null) return new NotFoundResult();

            _produtoRepository.Delete(entity);
            _produtoRepository.Savechanges();

            return new NoContentResult();
        }

        public async Task<ActionResult> Update(int id, ProdutoDto dto)
        {
            if (dto.Valor < 0 || dto.Estoque < 0 || dto.Nome.Length < 3) return new BadRequestResult();

            var entity = _produtoRepository.Get(id);
            if (entity == null) return new NotFoundResult();

            entity.SetNome(dto.Nome);
            entity.SetValor(dto.Valor);
            entity.SetEstoque(dto.Estoque);

            _produtoRepository.Update(entity);
            _produtoRepository.Savechanges();

            return new OkResult();
        }
    }
}
