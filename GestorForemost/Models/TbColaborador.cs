using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GestorForemost.Models
{
    public partial class TbColaborador
    {
        public TbColaborador()
        {
            TbFacturas = new HashSet<TbFactura>();
            TbGestionSaldos = new HashSet<TbGestionSaldo>();
        }

        [DisplayName("Identificación Colaborador")]
        public string IdentificacionColaborador { get; set; } = null!;

        [DisplayName("Nombre")]
        public string NombreColaborador { get; set; } = null!;

        [DisplayName("Primer Apellido")]
        public string Apellido1Colaborador { get; set; } = null!;

        [DisplayName("Segundo Apellido")]
        public string? Apellido2Colaborador { get; set; }

        [DisplayName("Teléfono")]
        public string? TelefonoColaborador { get; set; }

        [DisplayName("Correo")]
        public string? CorreoColaborador { get; set; }

        [DisplayName("Fecha Ingreso")]
        public DateTime FechaIngresoColab { get; set; }

        [DisplayName("Puesto")]
        public int PuestoColaborador { get; set; }

        [DisplayName("País")]
        public string PaisColaborador { get; set; } = null!;

        [DisplayName("Estado")]
        public int EstadoColaborador { get; set; }

        public virtual TbPuesto PuestoColaboradorNavigation { get; set; } = null!;
        public virtual ICollection<TbFactura> TbFacturas { get; set; }
        public virtual ICollection<TbGestionSaldo> TbGestionSaldos { get; set; }
    }
}
