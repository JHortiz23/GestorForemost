using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GestorForemost.Models
{
    public partial class TbGestionSaldo
    {
        [DisplayName("Código")]
        public int IdSaldo { get; set; }

        [DisplayName("# Factura")]
        public int IdFacturaSaldo { get; set; }

        [DisplayName("Agente Asignado")]
        public string IdGestorSaldo { get; set; } = null!;

        [DisplayName("Fecha Cobro")]
        public DateTime FechaAsignSaldo { get; set; }

        [DisplayName("Estado Cobro")]
        public int EstadoSaldo { get; set; }

        //DTO
        [DisplayName("Cliente")]
        public string NombreClienteSaldo { get; set; }

        [DisplayName("Agente Asignado")]
        public string NombreColaboradorSaldo { get; set; }

        [DisplayName("Monto")]
        public decimal montoFactura { get; set; }

        [DisplayName("Identificación Cliente")]
        public string identificacionCliente { get; set; }


        public virtual TbFactura IdFacturaSaldoNavigation { get; set; } = null!;
        public virtual TbColaborador IdGestorSaldoNavigation { get; set; } = null!;
    }
}
