using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VNpage.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Contenido { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Now;

        // Usuario que realizó el comentario
        [ForeignKey("Usuario")]
        public string? UserId { get; set; }
        public ApplicationUser? Usuario { get; set; }
        

        // Relación con la novela visual
        [ForeignKey("NovelaVisual")]
        public int NovelaVisualId { get; set; }
        public NovelaVisual? NovelaVisual { get; set; }
    }
}
