using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Cotizacion
    {
        public Cotizacion()
        {
            Envios = new HashSet<Envio>();
        }

        public int ContizacionId { get; set; }
        public string ClienteName { get; set; }
        public string ProducName { get; set; }
        public int ProdId { get; set; }
        public int ClienteId { get; set; }

        public virtual Registro Cliente { get; set; }
        public virtual Producto Prod { get; set; }
        public virtual ICollection<Envio> Envios { get; set; }
    }
}
