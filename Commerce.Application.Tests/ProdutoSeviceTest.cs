using Commerce.Application.Service;
using Commerce.Domain.Dto;
using Commerce.Domain.Entitie;
using Commerce.Infrastructure.Contract;
using Commerce.Mock;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Commerce.Application.Tests
{
    public class ProdutoServiceTest
    {
        [Fact]
        public async Task Get_ReturnsOkResult_WhenEntityExists()
        {
            // Arrange
            var produto = new CommerceMock().NovoProduto();

            var mockRepository = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(mockRepository.Object);

            mockRepository.Setup(repo => repo.Get(produto.Id)).Returns(produto);

            // Act
            var result = await produtoService.Get(produto.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEntity = Assert.IsType<Produto>(okResult.Value);
            Assert.Equal(produto, returnedEntity);
        }

        [Fact]
        public async Task GetByName_ReturnsOkResult_WhenEntityExists()
        {
            // Arrange
            var produto = new CommerceMock().NovoProduto();

            var mockRepository = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(mockRepository.Object);
            var lista = new List<Produto>() { produto };

            mockRepository.Setup(repo => repo.GetByName(produto.Nome)).Returns(lista);

            // Act
            var result = await produtoService.GetByName(produto.Nome);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEntities = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            var returnedEntity = Assert.Single(returnedEntities);
            Assert.Equal(produto.Nome, returnedEntity.Nome);
            Assert.Equal(produto.Valor, returnedEntity.Valor);
            Assert.Equal(produto.Estoque, returnedEntity.Estoque);
        }

        [Fact]
        public async Task GetBySort_ReturnsOkResult_WhenEntityExists()
        {
            // Arrange
            var mockRepository = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(mockRepository.Object);
            var sorts = new List<Sort> { new Sort { PropertyName = "Nome", Direction = "asc" } };
            var mockEntities = new List<Produto>
            {
                new Produto("Produto1", 10.00, 5),
                new Produto("Produto2", 20.00, 10)
            };

            mockRepository.Setup(repo => repo.GetBySort(sorts)).Returns(mockEntities);

            // Act
            var result = await produtoService.GetBySort(sorts);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEntities = Assert.IsAssignableFrom<List<Produto>>(okResult.Value);
            Assert.Equal(mockEntities, returnedEntities);
        }

        [Fact]
        public async Task Add_ReturnsNoContentResult_WhenDtoIsValid()
        {
            // Arrange
            var mockRepository = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(mockRepository.Object);
            var produtoDto = new ProdutoDto { Nome = "Produto Teste", Valor = 50.00, Estoque = 10 };

            // Act
            var result = await produtoService.Add(produtoDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContentResult_WhenEntityExists()
        {
            // Arrange
            var produto = new CommerceMock().NovoProduto();

            var mockRepository = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(mockRepository.Object);

            mockRepository.Setup(repo => repo.Get(produto.Id)).Returns(produto);

            // Act
            var result = await produtoService.Delete(produto.Id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WhenDtoIsValidAndEntityExists()
        {
            // Arrange
            var produto = new CommerceMock().NovoProduto();

            var mockRepository = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(mockRepository.Object);
            var produtoDto = new ProdutoDto { Nome = "Produto Atualizado", Valor = 100.00, Estoque = 20 };

            mockRepository.Setup(repo => repo.Get(produto.Id)).Returns(produto);

            // Act
            var result = await produtoService.Update(produto.Id, produtoDto);

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.Equal(produtoDto.Nome, produto.Nome);
            Assert.Equal(produtoDto.Valor, produto.Valor);
            Assert.Equal(produtoDto.Estoque, produto.Estoque);
        }
    }
}