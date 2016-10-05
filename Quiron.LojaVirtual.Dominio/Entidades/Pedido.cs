using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    [MetadataType(typeof(PedidoMetadato))]
    public class Pedido
    {
        public string   NomeCliente         { get; set; }
        public string   Cep                 { get; set; }
        public string   Endereco            { get; set; }
        public string   Complemento         { get; set; }
        public string   Cidade              { get; set; }
        public string   Bairro              { get; set; }
        public string   Estado              { get; set; }
        public string   Email               { get; set; }
        public bool     EmbrulharPresente   { get; set; }
    }

    public class PedidoMetadato
    {
        [Required(ErrorMessage = "Informe o seu Nome")]
        [Display(Name = "Nome do Cliente:")]
        public string NomeCliente { get; set; }

        [Display(Name = "CEP:")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe o seu Endereço")]
        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe a sua Cidade")]
        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o seu Bairro")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o seu Estado")]
        [Display(Name = "Estado:")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe o seu E-mail")]
        [Display(Name = "E-mail:")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Display(Name = "Embrulhar para Presente?")]
        public bool EmbrulharPresente { get; set; }
    }
}
