using System;
using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public partial class Administrador
    {
        public int      Id           { get; set; }
        public string   Login        { get; set; }
        public string   Senha        { get; set; }
        public DateTime UltimoAcesso { get; set; }
    }

    [MetadataType(typeof(AdministradorMetadado))]
    public partial class Administrador
    {
        public override bool Equals(object obj)
        {
            Administrador adm = obj as Administrador;

            if (adm == null)
                return false;

            return (this.Login.Equals(adm.Login));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class AdministradorMetadado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o login")]
        [Display(Name = "Login:")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public DateTime UltimoAcesso { get; set; }
    }
}