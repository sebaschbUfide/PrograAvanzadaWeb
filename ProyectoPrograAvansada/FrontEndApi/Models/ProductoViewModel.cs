using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndApi.Models
{
    public class ProductoViewModel
    {
        [Key]
        public int ProdId { get; set; }

        [Display(Name= "Nombre")]
        public string ProdName { get; set; }

        [Display(Description = "Descripcion")]

        public string ProdDescrip { get; set; }

       
        public decimal? ProdPrecio { get; set; }
    }
}
