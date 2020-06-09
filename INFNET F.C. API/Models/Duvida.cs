using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models
{
    public class Duvida
    {
        public int ID { get; set; }
        public Socio SOCIO_FK { get; set; }
        public int IDSOCIO_FK { get; set; }

        public string Assunto { get; set; }
        public string Mensagem { get; set; }

        public List<Resposta> Respostas { get; set; }

    }
}
