using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models
{
    public class Socio
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


        public List<Menu> FiltrarMenuPorPermissao(List<Menu> menus) {
            if (this.FLG_Ativo)
            {
                return menus;
            }
            else {
                menus.RemoveAt(0);
                return menus;
            }
        }
    }
}
