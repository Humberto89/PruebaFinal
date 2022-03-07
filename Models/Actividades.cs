using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaFinal.Models
{
    public partial class Actividades
    {
        [Key]
        public long Id { get; set; }
        public string DurecionLlamada { get; set; }
        public string Descricion { get; set; }
        public long Resolvio { get; set; }
        public long IdTipo { get; set; }

        public virtual Tipos IdTipoNavigation { get; set; }
    }
}
