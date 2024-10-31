using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SampleWebApi.Model
{
    public class Veiculo
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo nome não pode ser vazio")]
        [StringLength(150, ErrorMessage = "Campo nome não pode ser maior que 150 caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo descricao não pode ser vazio")]
        [StringLength(1024, ErrorMessage = "Campo descrição não pode ser maior que 1024 caracteres")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "Campo url não pode ser vazio")]
        [StringLength(500, ErrorMessage = "Campo url não pode ser maior que 500 caracteres")]
        public String UrlFoto { get; set; }

        [Required(ErrorMessage = "Informe o tipo de veiculo")]
        //[RegularExpression(@"^[1-3]$", ErrorMessage = "Tipo de Veiculo deve ser 1, 2 ou 3")]
        public TipoVeiculoEnum TipoVeiculo { get; set; }

        [JsonIgnore()]
        [AllowNull]
        public Fabricante Fabricante { get; set; }

    }
}
