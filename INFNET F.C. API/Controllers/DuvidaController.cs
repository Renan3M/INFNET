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
using System.Net.Mail;
using System.Net;

namespace INFNET_F.C._API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DuvidaController : ControllerBase
    {
        private readonly InfnetDBContext _context;

        public DuvidaController(InfnetDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duvida>>> Get()
        {
            return await _context.Duvidas.ToListAsync();
        }



        [HttpPost("{a}")]
        [Route("EnviarDuvida")]
        public async Task<ActionResult<IEnumerable<Duvida>>> EnviarDuvida(Duvida duvida)
        {
            try
            {
                var idDuvida = _context.Duvidas.Add(duvida).Entity.ID;

                await _context.SaveChangesAsync();

                _context.Respostas.Add(new Resposta { IDDUVIDA_FK = idDuvida, Mensagem = "Esse e-mail é uma simulação de resposta para a pergunta feita pelo sócio" });

                await _context.SaveChangesAsync();

                var emailSocio = _context.Socios.First(x=> x.ID == duvida.IDSOCIO_FK).Email;

                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
              
                mail.From = new MailAddress("suporteinfnetfc@gmail.com");
                mail.To.Add(emailSocio);
                mail.Subject = "Respondendo sua pergunta";
                mail.Body = "Esse e-mail é uma simulação de resposta para a pergunta feita pelo sócio.";

                smtpClient.Port = 587;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("suporteinfnetfc@gmail.com", "Infnet@dmin1");
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
