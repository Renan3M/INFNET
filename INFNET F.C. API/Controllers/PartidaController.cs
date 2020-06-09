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
    public class PartidaController : ControllerBase
    {
        private readonly InfnetDBContext _context;

        public PartidaController(InfnetDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partida>>> Get()
        {
            return await _context.Partidas.ToListAsync();
        }

        [HttpGet]
        [Route("ObterProximasPartidas")]
        public ActionResult<IEnumerable<Partida>> ObterProximasPartidas()
        {
            var partidas = _context.Partidas.Where(x => x.DT_PARTIDA > DateTime.Now).Include(x => x.VISITANTE_FK)
                .Include(x => x.MANDANTE_FK).Include(x => x.CAMPEONATO_FK).ToList();

            return partidas.Select(partida => new Partida { 
                CAMPEONATO_FK = new Campeonato { NOME = partida.CAMPEONATO_FK.NOME}, 
                MANDANTE_FK = new TimeFutebol { ESCUDO = partida.MANDANTE_FK.ESCUDO, NOME = partida.MANDANTE_FK.NOME},
                VISITANTE_FK = new TimeFutebol { ESCUDO = partida.VISITANTE_FK.ESCUDO, NOME = partida.VISITANTE_FK.NOME},
                DT_PARTIDA = partida.DT_PARTIDA,
                DESCR_PARTIDA = partida.DESCR_PARTIDA,
                ID = partida.ID
            }).ToList();
        }

        [HttpPost("{a}")]
        [Route("AderirPartida")]
        public async Task<ActionResult<IEnumerable<Partida>>> AderirPartida(int socioId, int partidaId)
        {
            var assinaturaSocio = _context.Assinaturas.FirstOrDefault(x=>x.IDSOCIO_FK == socioId);

            if (assinaturaSocio.FLG_ATIVA == false)
            {
                return StatusCode(StatusCodes.Status203NonAuthoritative);
            }
            else {
                _context.AssinaturaPartida.Add(new AssinaturaPartida { AssinaturaId = assinaturaSocio.ID, PartidaId = partidaId });
                await _context.SaveChangesAsync();
            }

            return StatusCode(StatusCodes.Status200OK);
        }


        [HttpPost("{a}")]
        [Route("InicializarPartidas")]
        public async Task<ActionResult<IEnumerable<Partida>>> InicializarPartidas()
        {
            if (!_context.Partidas.Any())
            {
                _context.Campeonatos.Add(new Campeonato { NOME = "Brasileirão" });
                _context.Estadios.Add(new Estadio { NOME = "Maracanã"});
                _context.TimesFutebol.Add(new TimeFutebol { NOME = "INFNET", ESCUDO= "infnet-escudo.png" });
                _context.TimesFutebol.Add(new TimeFutebol { NOME = "FLAMENGO", ESCUDO= "flamengo-escudo.png" });
                _context.TimesFutebol.Add(new TimeFutebol { NOME = "BOTAFOGO", ESCUDO= "botafogo-escudo.png" });
                _context.TimesFutebol.Add(new TimeFutebol { NOME = "FLUMINENSE", ESCUDO= "fluminense-escudo.png" });

                await _context.SaveChangesAsync();

                var Partidas =
                    new List<Partida>(){
                    new Partida{ IDCAMPEONATO_FK = 1, IDESTADIO_FK = 1, IDMANDANTE_FK = 1, IDVISITANTE_FK = 2, DESCR_PARTIDA = "Partida da primeira rodada do brasileirão", DT_CADASTRO = DateTime.Now, DT_PARTIDA = DateTime.Now.AddDays(12)},
                    new Partida{ IDCAMPEONATO_FK = 1, IDESTADIO_FK = 1, IDMANDANTE_FK = 1, IDVISITANTE_FK = 3, DESCR_PARTIDA = "Partida da segunda rodada do brasileirão", DT_CADASTRO = DateTime.Now, DT_PARTIDA = DateTime.Now.AddDays(19)},
                    new Partida{ IDCAMPEONATO_FK = 1, IDESTADIO_FK = 1, IDMANDANTE_FK = 1, IDVISITANTE_FK = 4, DESCR_PARTIDA = "Partida da terceira rodada do brasileirão", DT_CADASTRO = DateTime.Now, DT_PARTIDA = DateTime.Now.AddDays(26)},
                    };

                _context.Partidas.Add(Partidas[0]);
                _context.Partidas.Add(Partidas[1]);
                _context.Partidas.Add(Partidas[2]);

                await _context.SaveChangesAsync();
            }

            return await Get();
        }
    }
}
