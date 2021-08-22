using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndAPI.Models
{
    public class TokenModel
    {
        public string token { get; set; }
        public string expiration { get; set; }
    }
}
