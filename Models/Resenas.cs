using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VNpage.Models
{
    public class Resena
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        public string Imagen { get; set; } = "/images/default_review.png";

        [Range(0, 10)]
        public int Puntaje { get; set; }

        public string Tags { get; set; } = string.Empty;

        // Relaciones
    public string UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }

        public int? NovelaVisualId { get; set; }
        public NovelaVisual? NovelaVisual { get; set; }
    }
}
