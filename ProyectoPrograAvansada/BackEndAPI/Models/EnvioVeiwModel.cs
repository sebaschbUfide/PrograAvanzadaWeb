using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndApi.Models
{
    public class EnvioVeiwModel
    {   
        [Key]
        public int EnvioId { get; set; }
        [Key]
        public int ClienteId { get; set; }
        [Key]
        public int ContizacionId { get; set; }
        [Required]
        public string Direccion { get; set; }

        public virtual Registro Cliente { get; set; }
        public virtual Cotizacion Contizacion { get; set; }
    }

}
