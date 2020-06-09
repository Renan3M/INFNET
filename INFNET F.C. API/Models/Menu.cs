using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string NOME_MENU { get; set; }
        public string? ICONEMENU { get; set; }
        public string ROTA_MENU { get; set; }
        public int ORDEM { get; set; }
        public bool ATIVO { get; set; }
        public DateTime DT_CADASTRO { get; set; }
    }
}
