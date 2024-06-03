namespace CadastroDeClientes.Models
{
    public class ClienteModel
    {

        public int Id { get; set; }
        public int Codigo { get; set; }

        /*public String Tipo { get; set; }
        public String CpfCnpj { get; set; }
        public String RgIe { get; set; }
        public String NomeRazaoSocial { get; set; }
        public String NomeAbreviadoFantasia { get; set; }

        public String Endereco { get; set; }
        public String Cep { get; set; }
        public String Logradouro { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Municipio { get; set; }
        public String UnidadeFederativa { get; set; }



        */
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String Inclusao { get; set; }
        public String Alteracao { get; set; }


    }
}
