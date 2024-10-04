using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GestorForemost.Models
{
    public partial class TbFactura
    {
        public TbFactura()
        {
            TbGestionSaldos = new HashSet<TbGestionSaldo>();
        }

        [DisplayName("# Factura")]
        public int IdFactura { get; set; }

        [DisplayName("Identificación Cliente")]
        public string ClienteFactura { get; set; } = null!;

        [DisplayName("Fecha")]
        public DateTime FechaFactura { get; set; }

        [DisplayName("Identificación Agente")]
        public string ColaboradorFactura { get; set; } = null!;

        [DisplayName("Tipo Factura")]
        public string TipoFactura { get; set; } = null!;

        [DisplayName("Saldo")]
        public decimal MontoFactura { get; set; }

        [DisplayName("Estado Factura")]
        public int EstadoFactura { get; set; }

        //DTO
        [DisplayName("Agente")]
        public string NombreColaborador { get; set; } = null!;

        [DisplayName("Cliente")]
        public string NombreCliente { get; set; } = null!;



        public virtual TbCliente ClienteFacturaNavigation { get; set; } = null!;
        public virtual TbColaborador ColaboradorFacturaNavigation { get; set; } = null!;
        public virtual ICollection<TbGestionSaldo> TbGestionSaldos { get; set; }
    }
}
