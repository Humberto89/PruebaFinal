using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaFinal.Models
{
    public partial class Tipos
    {
        public Tipos()
        {
            Actividades = new HashSet<Actividades>();
        }

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long Id { get; set; }
        [Required(ErrorMessage ="el campo {0} es obligatorio")]
        [Display(Name = "Tipo")]

        public string Tipo { get; set; }

        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}
