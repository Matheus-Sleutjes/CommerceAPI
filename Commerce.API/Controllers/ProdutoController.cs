using Commerce.Application.Contract;
using Commerce.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController(IProdutoService _produtoService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await _produtoService.Get(id);
        }

        [HttpPost("GetBySort")]
        public async Task<IActionResult> GetBySort([FromBody]List<Sort> sorts )
        {
            return await _produtoService.GetBySort(sorts);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            return await _produtoService.GetByName(name);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProdutoDto dto) 
        {
            return await _produtoService.Add(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]ProdutoDto dto ,int id)
        {
            return await _produtoService.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _produtoService.Delete(id);
        }
    }
}
