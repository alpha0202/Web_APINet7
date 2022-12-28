using System.ComponentModel.DataAnnotations;

namespace WebAPI_Udemy.DTO
{
    public class EmpleadoDTO
    {
        [Required(ErrorMessage ="obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "obligatorio")]
        [MaxLength(4,ErrorMessage ="Máximo 4 dígitos")]
        public string CodEmpleado { get; set; }
        [Required(ErrorMessage = "obligatorio")]
        [EmailAddress(ErrorMessage ="Formato Incorrecto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "obligatorio")]
        [Range(16,60, ErrorMessage ="la edad de estar entre los 16 y 60 años.")]
        public int Edad { get; set; }

    }
}
