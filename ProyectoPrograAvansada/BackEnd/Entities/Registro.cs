using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Registro
    {
        public Registro()
        {
            Envios = new HashSet<Envio>();
        }

        public int ClienteId { get; set; }
        public string ClienteEmail { get; set; }
        public string ClientePassword { get; set; }
        public string ClienteName { get; set; }
        public int RolId { get; set; }
        public int ClienteId1 { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
