using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Registro
    {
        public Registro()
        {
            Cotizacions = new HashSet<Cotizacion>();
            Envios = new HashSet<Envio>();
        }

        public int ClienteId { get; set; }
        public string ClienteEmail { get; set; }
        public string ClientePassword { get; set; }
        public string ClienteName { get; set; }
        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
        public virtual ICollection<Envio> Envios { get; set; }
    }
}
