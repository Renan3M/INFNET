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
    public class AssinaturaController : ControllerBase
    {
        private readonly InfnetDBContext _context;

        public AssinaturaController(InfnetDBContext context)
        {
            _context = context;
        }

        [HttpPost("{x}")]
        [Route("GetAssinaturaSocio")]
        public ActionResult<Assinatura> GetAssinaturaSocio(Socio socio)
        {
            return _context.Assinaturas.Where(x => x.IDSOCIO_FK == socio.ID).Select(assinatura => new Assinatura
            {
                PLANO_FK = new Plano { Nome = assinatura.PLANO_FK.Nome, ID = assinatura.PLANO_FK.ID },
                FLG_ATIVA = assinatura.FLG_ATIVA,
                ID = assinatura.ID,
                TIPO_PAGAMENTO = assinatura.TIPO_PAGAMENTO
            }).First();
        }
    }
}
