using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Models
{
    public class ProductoModel
    {
        [Key]
        public int ProdId { get; set; }

        [Required]
        public string ProdName { get; set; }

     

        public string ProdDescrip { get; set; }


        public decimal? ProdPrecio { get; set; }
    }
}
