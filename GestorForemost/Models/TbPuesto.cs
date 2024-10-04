using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GestorForemost.Models
{
    public partial class TbPuesto
    {
        public TbPuesto()
        {
            TbColaboradors = new HashSet<TbColaborador>();
        }

        [DisplayName("Código")]
        public int IdPuesto { get; set; }

        [DisplayName("Nombre Puesto")]
        public string NombrePuesto { get; set; } = null!;

        public virtual ICollection<TbColaborador> TbColaboradors { get; set; }
    }
}
