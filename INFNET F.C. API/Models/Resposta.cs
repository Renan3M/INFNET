using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models
{
    public class Resposta
    {
        public int ID { get; set; }
        public Duvida DUVIDA_FK { get; set; }

        public int IDDUVIDA_FK { get; set; }

        public string Mensagem { get; set; }
    }
}
