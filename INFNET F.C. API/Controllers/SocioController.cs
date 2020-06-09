using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using INFNET_F.C._API.Data;
using INFNET_F.C._API.Migrations;
using INFNET_F.C._API.Models;
using INFNET_F.C._API.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INFNET_F.C._API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly InfnetDBContext _context;

        public SocioController(InfnetDBContext context) {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Socio>>> Get() {
            return await _context.Socios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Socio>> Get(int id) {
            var socio = await _context.Socios.FindAsync(id);

            if (socio == null) {
                return NotFound();
            }

            return socio;
        }

        [HttpPost("{a}")]
        [Route("AutenticarUsuario")]
        public async Task<ActionResult<DadosUsuarioLogado>> AutenticarUsuario(Socio socioSolicitado)
        {
            var socio = await _context.Socios.FirstOrDefaultAsync(x => x.Email == socioSolicitado.Email && x.CPF == socioSolicitado.CPF);

            if (socio == null)
            {
                return NotFound();
            }

            else
            {
 
                var lstMenusRaiz = _context.Menus.Where(x => x.ATIVO).AsNoTracking().ToList();
                var textBytes = Encoding.UTF8.GetBytes(socio.ID.ToString());
                string token = Convert.ToBase64String(textBytes);

                return new DadosUsuarioLogado(socio, socio.FiltrarMenuPorPermissao(lstMenusRaiz), token);

            }
        }

        [HttpPost("{s}")]
        [Route("CadastrarSocioPlano")]
        public async Task<ActionResult> CadastrarSocioPlano(SocioWizard socioWizard)
        {
                var Socio = new Socio
                {
                    Cidade = socioWizard.Cidade,
                    CPF = socioWizard.CPF,
                    Email = socioWizard.Email,
                    Nome = socioWizard.Nome,
                    Pais = socioWizard.Pais,
                    Rua = socioWizard.Rua
                };

            var socioId = _context.Socios.Add(Socio);

            await _context.SaveChangesAsync();

            var Assinatura = new Assinatura { IDSOCIO_FK = socioId.Entity.ID, IDPLANO_FK = Int32.Parse(socioWizard.PlanoId), 
                DataInicio = DateTime.Now, DataFim = DateTime.Now.AddYears(1), FLG_ATIVA = false};

            _context.Assinaturas.Add(Assinatura);

            await _context.SaveChangesAsync();

            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Socio socio) {

            _context.Socios.Add(socio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = socio.ID }, socio );
        }
    }
}