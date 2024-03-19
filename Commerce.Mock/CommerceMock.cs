using Commerce.Domain.Entitie;
using Gestor_Saude.Tests.Mock;

namespace Commerce.Mock
{
    public class CommerceMock
    {
        private readonly ISequencial _sequencial;

        public CommerceMock()
        {
            _sequencial = new Sequencial();
        }

        public Produto NovoProduto()
        {
            var id = _sequencial.Next("Id");

            return new Produto("Nome Produto", 20.3, 30, id);
        }

        public Produto NovoProdutoInvalido()
        {
            var id = _sequencial.Next("Id");

            return new Produto("Nome Produto", -2, -4, id);
        }
    }
}
