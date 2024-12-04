using System;
using System.ComponentModel.DataAnnotations;

namespace OL_TEST.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El código no puede exceder los 50 caracteres.")]
        public string Code{ get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255, ErrorMessage = "La descripción no puede exceder los 255 caracteres.")]
        public string? Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser mayor o igual a 0.")]
        public int Stock { get; set; }

        [DataType(DataType.Date, ErrorMessage = "La fecha de vencimiento no tiene un formato válido.")]
        public DateTime? ExpirationDate { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
