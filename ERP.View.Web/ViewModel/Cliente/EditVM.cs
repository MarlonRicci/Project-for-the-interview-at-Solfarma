using ERP.Entidades.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ERP.View.Web.ViewModel.Cliente
{
    public class EditVM
    {
        [Display(Name = "Código")]
        [DefaultValue(0)]
        public int Codigo { get; set; }

        [MaxLength(100, ErrorMessage ="O nome pode ter somente 100 caracteres")]
        [Required(ErrorMessage ="Informe o nome do cliente")]
        public string Nome { get; set; }

        [Description("Data Nasc.")]
        [Required(ErrorMessage = "Informe a data de nascimento do cliente")]
        [Display(Name = "Data Nasc.")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o sexo do cliente")]
        public ESexo Sexo { get; set; }

        [Description("Limite de Compra")]
        [Required(ErrorMessage = "Informe o limite de compra do cliente")]
        [Display(Name = "Limite de Compra")]
        public decimal LimiteCompra { get; set; }
    }
}