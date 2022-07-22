using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RegistroEmpresas.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud máxima es 50 caracteres")]
        [Display(Name = "Nombre del contacto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud máxima es 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "La longitud máxima es 15 caracteres")]
        [MinLength(8, ErrorMessage = "La longitud mínima es 8 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Celular es requerido")]
        [MaxLength(15, ErrorMessage = "La longitud máxima es 15 caracteres")]
        [MinLength(8, ErrorMessage = "La longitud mínima es 8 caracteres")]
        public string Celular { get; set; }

        [ValidateNever]        
        public List<Empresa> Empresas { get; set; }
    }
}
