using System;
using System.ComponentModel.DataAnnotations;

namespace OL_TEST.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "El tipo de identificación es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El tipo de identificación no puede exceder los 20 caracteres.")]
        public string IdentificationType { get; set; } = string.Empty;

        [Required(ErrorMessage = "La identificación es obligatoria.")]
        [MaxLength(50, ErrorMessage = "La identificación no puede exceder los 50 caracteres.")]
        public string Identification { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255, ErrorMessage = "La dirección no puede exceder los 255 caracteres.")]
        public string? Address { get; set; }

        [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
        public string? Phone { get; set; }

        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no tiene un formato válido.")]
        public DateTime? BirthDay { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
