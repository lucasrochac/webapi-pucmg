using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    [Serializable]
    [Table("T_AVALIACAO")]
    public class Avaliacao
    { 
        [Column("ID_AVALIA")]
        public int CodigoAvaliacao { get; set; }

        [Column("DT_AVALIA")]
        public DateTime DataAvaliacao { get; set; }
        
        [Column("TX_NOME")]
        public string NomeAvaliacao { get; set; }
        
        [Column("CD_CURSO")]
        public int CodigoCurso { get; set; }

        [NotMapped]
        public virtual Nota NotaAvaliacao { get; set; }
    }
} 