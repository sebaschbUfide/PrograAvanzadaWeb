using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndApi.Models
{
    public class EnvioVeiwModel
    {   
        public int EnvioId { get; set; }
        public int ClienteId { get; set; }
        public int ContizacionId { get; set; }
        public string Direccion { get; set; }

        public virtual Registro Cliente { get; set; }
        public virtual Cotizacion Contizacion { get; set; }
    }

}
