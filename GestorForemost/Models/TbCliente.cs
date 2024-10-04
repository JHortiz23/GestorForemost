using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GestorForemost.Models
{
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbFacturas = new HashSet<TbFactura>();
        }

        [DisplayName("Identificación")]
        public string IdentificacionCliente { get; set; } = null!;

        [DisplayName("Nombre")]
        public string NombreCliente { get; set; } = null!;

        [DisplayName("Primer Apellido")]
        public string Apellido1Cliente { get; set; } = null!;

        [DisplayName("Segundo Apellido")]
        public string? Apellido2Cliente { get; set; }

        [DisplayName("Teléfono")]
        public string? TelefonoCliente { get; set; }

        [DisplayName("Correo")]
        public string? CorreoCliente { get; set; }

        [DisplayName("Domicilio")]
        public string? DireccionCliente { get; set; }

        public virtual ICollection<TbFactura> TbFacturas { get; set; }
    }
}
