namespace SampleWebApi.Model
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public String UrlFoto { get; set; }
        public TipoVeiculoEnum TipoVeiculo { get; set; }
        public Fabricante Fabricante { get; set; }

    }
}
