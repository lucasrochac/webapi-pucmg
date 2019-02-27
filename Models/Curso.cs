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
    [Table("T_CURSO")]
    public class Curso
    {
        [Column("ID_CURSO")]
        public int CodigoCurso { get; set; }

        [Column("CD_NOME")]
        public string Nome { get; set; }
        
        [Column("DT_OFERTA")]
        public DateTime DataOferta { get; set; }

        public virtual List<Avaliacao> Avaliacoes { get; set; }
    }
}