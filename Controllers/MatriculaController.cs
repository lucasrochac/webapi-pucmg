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
    public class MatriculaController : Controller
    {
        private WebApiContext _context;

        public MatriculaController(WebApiContext context)
        {
            this._context = context;
        }

        [Route("api/Matricula/ObtemMatriculaAluno")]
        [HttpPost]
        [Authorize("Aluno")]
        [Produces("application/json")]
        public JsonResult ObtemMatriculaAluno([FromBody] string cpf)
        {
            
            Matricula matricula = _context.Matricula.FirstOrDefault(a=>a.AlunoCpf == cpf);
            matricula.Curso = _context.Curso.FirstOrDefault(f=>f.CodigoCurso == matricula.CodigoCurso);
            matricula.Curso.Avaliacoes = _context.Avaliacao.Where(w=>w.CodigoCurso == matricula.Curso.CodigoCurso).ToList();
            matricula.Aluno = _context.Aluno.FirstOrDefault(a=>a.Cpf == matricula.AlunoCpf);
            for(int i = 0; i < matricula.Curso.Avaliacoes.Count; i++)
            {
                Nota nota = new Nota();
                nota =  _context.Nota.FirstOrDefault(n=>n.CodigoCpf == matricula.Aluno.Cpf 
                    && n.CodigoAvaliacao == matricula.Curso.Avaliacoes[i].CodigoAvaliacao);
                   
                matricula.Curso.Avaliacoes[i].NotaAvaliacao = nota;
            }


            return Json( new { matricula = matricula } ); 
        }
    }
}