using System.ComponentModel.DataAnnotations;

namespace SampleWebApi.Model
{
    public class Fabricante
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Campo Nome não pode ser vazio")]
        [StringLength(150, ErrorMessage = "Campo nome não pode ser maior que 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo data de fundação não pode ser vazio")]
        public DateTime DataFundacao { get; set; }

        [Required(ErrorMessage = "Campo descrição não pode ser vazio")]
        [StringLength(1024, ErrorMessage = "Campo descrição não pode ser maior que 1024 caracteres")]
        public String Descricao {  get; set; }
        
        public List<Veiculo> Veiculos { get; set; } 


	}
}
