using Microsoft.AspNetCore.Identity;

namespace PruebaFinal.Models
{
    public partial class Users: IdentityUser
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }

    }
}