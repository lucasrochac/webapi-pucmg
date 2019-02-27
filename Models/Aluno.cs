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
    [Table("T_ALUNO")]
    public class Aluno
    {
        [Column("CD_CPF")]
        public string Cpf { get; set; }

        [Column("TX_NOME")]
        public string Nome { get; set; }
        
        [Column("TX_SENHA")]
        public string Senha { get; set; }
        
        [Column("TX_END")]
        public string Endereco { get; set; }
        
        [Column("CD_UF")]
        public string Uf { get; set; }
        
        [Column("TX_MUNICIPIO")]
        public string Municipio { get; set; }
        
        [Column("NU_TEL")]
        public string Telefone { get; set; }
        
        [Column("TX_MAIL")]
        public string Mail { get; set; }
    }
}