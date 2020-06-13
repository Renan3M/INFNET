using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models.ViewModels
{
    public class SocioPagamento
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public List<Assinatura> Assinaturas { get; set; }
        public bool FLG_Ativo { get; set; }

        public List<Duvida> Duvidas { get; set; }
        public int TipoPagamento { get; set; }
    }
}
