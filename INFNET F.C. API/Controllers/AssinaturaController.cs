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

        [HttpGet]
        public ActionResult<Assinatura> Get(int idSocio)
        {
            return _context.Assinaturas.First(x=>x.IDSOCIO_FK == idSocio);
        }
    }
}
