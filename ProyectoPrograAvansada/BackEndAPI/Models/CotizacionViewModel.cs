using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Models
{
    public class CotizacionViewModel
    {
        public int ContizacionId { get; set; }
        public string ClienteName { get; set; }
        public string ProducName { get; set; }
        public int ProdId { get; set; }
        public int ClienteId { get; set; }

    }
}
