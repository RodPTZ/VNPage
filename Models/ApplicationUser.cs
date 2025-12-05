using Microsoft.AspNetCore.Identity;

namespace VNpage.Models
{
    // Clase extendida de IdentityUser para agregar campos personalizados en el futuro
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }  // Ejemplo: nombre visible del usuario
    }
}
