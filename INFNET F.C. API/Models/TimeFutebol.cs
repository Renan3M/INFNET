using System.Collections.Generic;

namespace INFNET_F.C._API.Models
{
    public class TimeFutebol
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string ESCUDO { get; set; }

        public List<Partida> PartidasVisitante { get; set; }
        public List<Partida> PartidasMandante { get; set; }

    }
}