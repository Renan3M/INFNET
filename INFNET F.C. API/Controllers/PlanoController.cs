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
    public class PlanoController : ControllerBase
    {
        private readonly InfnetDBContext _context;

        public PlanoController(InfnetDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plano>>> Get()
        {
            return await _context.Planos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plano>> GetPlano(int id)
        {
            var plano = await _context.Planos.FindAsync(id);

            if (plano == null)
            {
                return NotFound();
            }

            return plano;
        }

        [HttpPost("{a}")]
        public async Task<ActionResult<IEnumerable<Plano>>> InicializarPlanosBasicos()
        {
            if (!_context.Planos.Any())
            {
                // Esse aplicativo não é voltado para o Administrador, a função de criar planos pertenceria a 
                // uma outra aplicação que ainda não existe

                var PlanosSocioTorcedor =
                    new List<Plano>(){
                        new Plano { Nome = "Sou Infnet", Descricao = "Plano básico sócio torcedor do clube infnet f.c.", Valor = 170.90, QtdDisponivel = 20000 },
                        new Plano { Nome = "Sou Infnet Vip", Descricao = "Plano vip sócio torcedor do clube infnet f.c, dá direito a camarote e outros beneficios.", Valor = 400.00, QtdDisponivel = 400 },
                        new Plano { Nome = "Sou Infnet Premium", Descricao = "Plano premium sócio torcedor do clube infnet f.c, dá direito ao hall principal e outros beneficios.", Valor = 600.00, QtdDisponivel = 200 }
                    };

                _context.Planos.Add(PlanosSocioTorcedor[0]);
                _context.Planos.Add(PlanosSocioTorcedor[1]);
                _context.Planos.Add(PlanosSocioTorcedor[2]);

                await _context.SaveChangesAsync();
            }

            return await Get();
        }
    }
}