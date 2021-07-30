using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class CategoriaProd
    {
        public int CategoriaId { get; set; }
        public string CategoriaName { get; set; }
        public int ProdId { get; set; }
        public int ProvId { get; set; }

        public virtual Producto Prod { get; set; }
        public virtual Proveedor Prov { get; set; }
    }
}
