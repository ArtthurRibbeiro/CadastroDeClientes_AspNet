using System.ComponentModel.DataAnnotations;

namespace CadastroDeClientes.Models
{
    public class ClienteModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Código do Cliente")]
        public String Codigo { get; set; }
        [Required(ErrorMessage = "Informe o tipo de documento do Cliente")]
        public String Tipo { get; set; }
        [Required(ErrorMessage = "Digite o documento do Cliente do tipo informado ao lado")]
        public String CpfCnpj { get; set; }
        public String? RgIe { get; set; }
        [Required(ErrorMessage = "Digite o nome/razão social do Cliente")]
        public String NomeRazaoSocial { get; set; }
        public String? NomeAbreviadoFantasia { get; set; }

        [Required(ErrorMessage = "Digite o CEP do Cliente")]
        public String Cep { get; set; }
        [Required]
        public String Logradouro { get; set; }
        [Required]
        public String Numero { get; set; }
        public String? Complemento { get; set; }
        [Required]
        public String Bairro { get; set; }
        [Required]
        public String Municipio { get; set; }
        [Required]
        public String UnidadeFederativa { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do Cliente")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é válido")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Digite o Telefone do Cliente")]
        [Phone(ErrorMessage = "Número inválido informado")]
        public String Telefone { get; set; }
        public String? Inclusao { get; set; }
        public String? Alteracao { get; set; }


    }
}
