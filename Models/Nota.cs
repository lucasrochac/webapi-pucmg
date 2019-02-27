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
    [Table("T_NOTA")]
    public class Nota
    {
        [Column("ID_NOTA")]
        public int CodigoNota {get;set;}

        [Column("CD_ALUNO")]
        public string CodigoCpf { get; set; }

        [Column("CD_AVALIA")]
        public int CodigoAvaliacao { get; set; }

        [Column("VL_NOTA")]
        public decimal ValorNota { get; set; }
    }
}