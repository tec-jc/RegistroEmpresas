using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroEmpresas.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Contacto")]
        [Required(ErrorMessage = "El Contacto es requerido")]
        [Display(Name = "Nombre del Contacto")]
        public int ContactoId { get; set; }

        [Required(ErrorMessage = "El Nombre de la empresa es requerido")]
        [Display(Name = "Nombre de la Empresa")]
        [MaxLength(100, ErrorMessage = "La longitud máxima es 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Rubro de la empresa es requerido")]
        [MaxLength(30, ErrorMessage = "La longitud máxima es 30 caracteres")]
        public string Rubro { get; set; }

        [Required(ErrorMessage = "La Categoria de la empresa es requerida")]
        [MaxLength(30, ErrorMessage = "La longitud máxima es 30 caracteres")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El Departamento es requerido")]
        [MaxLength(30, ErrorMessage = "La longitud máxima es 30 caracteres")]
        public string Departamento { get; set; }

        public Contacto Contacto { get; set; } 
    }
}
