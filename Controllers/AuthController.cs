using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Providers;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Cors;

namespace web_api.Controllers
{   
    [EnableCors("MyPolicy")]
    public class AuthController : Controller
    {
        private WebApiContext _context;
        
        
        public AuthController(WebApiContext context)
        {
            this._context = context;
        }

        [Route("api/Auth")]
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        public ActionResult Auth([FromBody] Aluno aluno)
        {
            Aluno _aluno = _context.Aluno.Where(x=>x.Cpf == aluno.Cpf && x.Senha == aluno.Senha).FirstOrDefault();
            
            if(_aluno==null)
            {
                return Unauthorized();
            }
            else
            {
                var token = new TokenJWTBuilder()
                    .AddSecurityKey(Providers.JwtSecurityKey.Create("SecurityKey-12345678"))
                    .AddSubject("Lucas Rocha")
                    .AddIssuer("br.com.PucApp")
                    .AddAudience("br.com.PucApp")
                    .AddClaim("MatriculaAluno", "1")
                    .AddExpiry(60000)
                    .Builder();
                return Ok(token.value);
            }
        }

        [Route("api/AloMundo")]
        [AllowAnonymous]
        [HttpGet]
        [Produces("application/json")]
        public ActionResult AloMundo()
        {
            return Json(new { data = "Alo Mundo!" }); 
        }

    }
}
