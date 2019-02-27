using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    [Serializable]
    [Table("T_MATRICULA")]
    public class Matricula
    {
        [Column("ID_MATRIC")]
        public int CodigoMatricula { get; set; }

        [Column("CD_CPF")]
        public string AlunoCpf { get; set; }

        [Column("CD_CURSO")]
        public int CodigoCurso { get; set; }

        [Column("DT_MATRIC")]
        public DateTime DataMatricula { get; set; }
        
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
        
    }
}