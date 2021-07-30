using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            CategoriaProds = new HashSet<CategoriaProd>();
        }

        public int ProvId { get; set; }
        public string ProvName { get; set; }
        public string ProvTel { get; set; }

        public virtual ICollection<CategoriaProd> CategoriaProds { get; set; }
    }
}
