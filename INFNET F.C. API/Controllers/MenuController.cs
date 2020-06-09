using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using INFNET_F.C._API.Data;
using INFNET_F.C._API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INFNET_F.C._API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly InfnetDBContext _context;

        public MenuController(InfnetDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> Get()
        {
            return await _context.Menus.ToListAsync();
        }

       

        [HttpPost("{a}")]
        [Route("InicializarMenus")]
        public async Task<ActionResult<IEnumerable<Menu>>> InicializarMenus()
        {
            if (!_context.Menus.Any())
            {
                var Menus =
                    new List<Menu>(){
                        new Menu { NOME_MENU = "Loja de vantagens", ICONEMENU = "fa fa-futbol-o",ROTA_MENU="/loja-vantagens", DT_CADASTRO = DateTime.Now, ORDEM=10,ATIVO=true},
                        new Menu { NOME_MENU = "Financeiro", ICONEMENU = "fa fa-credit-card",ROTA_MENU="/financeiro", DT_CADASTRO = DateTime.Now, ORDEM=20,ATIVO=true},
                        new Menu { NOME_MENU = "Suporte", ICONEMENU = "fa fa-user",ROTA_MENU="/suporte", DT_CADASTRO = DateTime.Now, ORDEM=30,ATIVO=true},
                    };

                _context.Menus.Add(Menus[0]);
                _context.Menus.Add(Menus[1]);
                _context.Menus.Add(Menus[2]);

                await _context.SaveChangesAsync();
            }

            return await Get();
        }
    }
}
