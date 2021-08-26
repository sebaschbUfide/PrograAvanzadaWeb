using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Envio
    {
        public int EnvioId { get; set; }
        public int ClienteId { get; set; }
        public int CotizacionId { get; set; }
        public string Direccion { get; set; }

        public virtual Registro Cliente { get; set; }
        public virtual Cotizacion Cotizacion { get; set; }
    }
}
