using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models
{
    public class Cobranca
    {
        public int ID { get; set; }
        public Assinatura ASSINATURA_FK { get; set; }
        public int IDASSINATURA_FK { get; set; }
        public int NumeroParcelas { get; set; }
        public double ValorParcelas { get; set; }
        public bool isRecorrente { get; set; }
    }
}
