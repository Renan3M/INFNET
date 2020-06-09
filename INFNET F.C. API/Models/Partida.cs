using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models
{
    public class Partida
    {
        public int ID { get; set; }
        public DateTime DT_CADASTRO { get; set; }
        public string DESCR_PARTIDA { get; set; }
        public DateTime DT_PARTIDA { get; set; }

        public  TimeFutebol MANDANTE_FK { get; set; }
        public int IDMANDANTE_FK { get; set; }

        public  TimeFutebol VISITANTE_FK { get; set; }

        public int IDVISITANTE_FK { get; set; }

        public int IDCAMPEONATO_FK { get; set; }
        public Campeonato CAMPEONATO_FK { get; set; }
        public int IDESTADIO_FK { get; set; }
        public Estadio ESTADIO_FK { get; set; }

        public ICollection<AssinaturaPartida> AssinaturaPartida { get; set; }

    }
}
