using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            Registros = new HashSet<Registro>();
        }

        public int RolId { get; set; }
        public string RolName { get; set; }

        public virtual ICollection<Registro> Registros { get; set; }
    }
}
