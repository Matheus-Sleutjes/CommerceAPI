namespace Commerce.Domain.Entitie
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Estoque { get; set; }

        public void Validation()
        {
            if (Valor < 0) throw new Exception("O valor não pode ser negativo");
        }
    }
}
