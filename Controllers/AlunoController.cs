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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cors;

namespace web_api.Controllers
{
    [Authorize]
    [EnableCors("MyPolicy")]
    public class AlunoController : Controller
    {
        private WebApiContext _context;

        public AlunoController(WebApiContext context)
        {
            this._context = context;
        }

        [Route("api/Aluno/ObtemDadosUsuario")]
        [HttpPost]
        [Authorize("Aluno")]
        [Produces("application/json")]
        public JsonResult ObtemDadosUsuario([FromBody] string cpf)
        {
            Aluno aluno = _context.Aluno.Where(x=>x.Cpf == cpf).FirstOrDefault();
            return Json(new { aluno = aluno }); 
        }
    }
}
