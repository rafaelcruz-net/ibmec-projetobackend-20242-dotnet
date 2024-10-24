namespace SampleWebApi.Model
{
    public class Fabricante
    {
		public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }
        public List<Veiculo> Veiculos { get; set; } 


	}
}
