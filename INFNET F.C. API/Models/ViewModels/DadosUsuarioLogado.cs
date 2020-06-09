using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Models.ViewModels
{
    public class DadosUsuarioLogado
    {
        public Socio Socio { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
        public string Token { get; set; }


        public DadosUsuarioLogado(Socio s, IEnumerable<Menu> m, string t)
        {
            Socio = s;
            Menus = m;
            Token = t;
        }
    }
}