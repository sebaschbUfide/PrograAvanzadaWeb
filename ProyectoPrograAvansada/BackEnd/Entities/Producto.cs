using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            CategoriaProds = new HashSet<CategoriaProd>();
        }

        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescrip { get; set; }
        public decimal? ProdPrecio { get; set; }
        public byte[] ProdImg { get; set; }

        public virtual ICollection<CategoriaProd> CategoriaProds { get; set; }
    }
}
