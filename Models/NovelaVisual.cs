using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VNpage.Models
{
public class NovelaVisual
{
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Titulo { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Desarrollador { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string Descripcion { get; set; } = string.Empty;

    public string ImagenRuta { get; set; } = "/images/default_vn.png";

    public DateTime FechaLanzamiento { get; set; }

    [MaxLength(100)]
    public string Genero { get; set; } = string.Empty;

    public string Tags { get; set; } = string.Empty;

    public double Puntaje { get; set; } = 0;

    public ICollection<Resena>? Resenas { get; set; }
    public ICollection<Comentario>? Comentarios { get; set; }
}

}


