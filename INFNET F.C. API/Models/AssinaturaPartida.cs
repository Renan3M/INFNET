using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models
{
    public class AssinaturaPartida
    {
        public int AssinaturaId { get; set; }
        public Assinatura Assinatura { get; set; }
        public int PartidaId { get; set; }
        public Partida Partida { get; set; }
    }
}
