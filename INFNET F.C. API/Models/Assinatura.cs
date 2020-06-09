using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models
{
    public class Assinatura
    {
        public int ID { get; set; }
        public Socio SOCIO_FK { get; set; }
        public int IDSOCIO_FK { get; set; }
        public Plano PLANO_FK { get; set; }
        public int IDPLANO_FK { get; set; }
        public bool FLG_ATIVA { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        //public List<Partida> PARTIDA_FK { get; set; }
        //public List<int> IDPARTIDA_FK { get; set; }
        public List<Cobranca> Cobrancas { get; set; }

        public ICollection<AssinaturaPartida> AssinaturaPartida { get; set; }

        public int TIPO_PAGAMENTO { get; set; }

    }
}
