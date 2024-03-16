using Commerce.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Application.Contract
{
    public interface IProdutoService
    {
        Task<ActionResult> Get(int id);
        Task<ActionResult> GetByName(string name);
        Task<ActionResult> GetBySort(IEnumerable<Sort> sorts);
        Task<ActionResult> Add(ProdutoDto dto);
        Task<ActionResult> Delete(int id);
        Task<ActionResult> Update(int id, ProdutoDto dto);
    }
}
