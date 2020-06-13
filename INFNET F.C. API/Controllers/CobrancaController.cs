using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using INFNET_F.C._API.Data;
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
    public class CobrancaController : ControllerBase
    {
        private readonly InfnetDBContext _context;

        public CobrancaController(InfnetDBContext context)
        {
            _context = context;
        }

        [HttpPost("{x}")]
        [Route("GerarCobrancasSocio")]
        public ActionResult<CobrancaMenu> GerarCobrancasSocio(SocioPagamento socio)
        {
            if (socio.ID == 0)
                return StatusCode(StatusCodes.Status203NonAuthoritative);

            var assinatura = _context.Assinaturas.First(x => x.IDSOCIO_FK == socio.ID);
            

            double valorTotal = _context.Planos.First(x=>x.ID==assinatura.IDPLANO_FK).Valor;
            double valorParcelado = (assinatura.PLANO_FK.Valor/12);
            var result = new List<Cobranca>();
            for (var i = 1; i <= 12; i++) {

                // Aplica desconto
                if (socio.TipoPagamento == 1) 
                {
                    var cobranca = _context.Cobrancas.Add(new Cobranca
                    {
                        ValorParcela = Math.Round(valorParcelado * 1.1, 2),
                        IDASSINATURA_FK = assinatura.ID,
                        DataValidade = DateTime.Now.AddMonths(i),
                        isRecorrente = true,
                        ValorTotalCobranca = valorTotal,
                        FLG_PAGA = false
                    }).Entity;
                    result.Add(cobranca);
                }
                else
                {
                    var cobranca = _context.Cobrancas.Add(new Cobranca
                    {
                        ValorParcela = Math.Round(valorParcelado, 2),
                        IDASSINATURA_FK = assinatura.ID,
                        DataValidade = DateTime.Now.AddMonths(i),
                        isRecorrente = true,
                        ValorTotalCobranca = valorTotal,
                        FLG_PAGA = false
                    }).Entity;
                    result.Add(cobranca);
                }   
            }
            _context.SaveChanges();

            //Ativar assinatura
            assinatura.FLG_ATIVA = true;
            _context.Assinaturas.Update(assinatura);

            _context.SaveChanges();

            //Ativar sócio
            var socioAtualizar = _context.Socios.First(x => x.ID == socio.ID);
            socioAtualizar.FLG_Ativo = true;
            _context.Socios.Update(socioAtualizar);

            _context.SaveChanges();

            result.ForEach(x => x.ASSINATURA_FK = null);

            var menus = _context.Menus.ToList();
            return new CobrancaMenu {Cobrancas= result, Menus = menus};
        }

        [HttpPost("{x}")]
        [Route("BuscarCobrancasSocio")]
        public ActionResult<IEnumerable<Cobranca>> BuscarCobrancasSocio(Socio socio)
        {
            var assId = _context.Assinaturas.First(x => x.IDSOCIO_FK == socio.ID).ID;
            var result = _context.Cobrancas.Where(y => y.IDASSINATURA_FK == assId).ToList();
            result.ForEach(c => c.ASSINATURA_FK = null);
            return result;
        }

        
        [HttpPost("{x}")]
        [Route("PagarCobranca")]
        public ActionResult<Cobranca> PagarCobranca(Cobranca cob)
        {
            var cobranca = _context.Cobrancas.First(x => x.ID == cob.ID);
            cobranca.FLG_PAGA = true;

            _context.Cobrancas.Update(cobranca);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}


