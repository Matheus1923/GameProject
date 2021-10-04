using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterHunter.Models
{
    [Table("Alatreon")]
    public class Alatreon
    {
        [Key]
        [Column("idalatreon")]
        [Required (ErrorMessage = "O campo é obrigatório")]

        public Int32 IdAlatreon { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O valor de caracteres deve ser entre 10 á 50")]
        [Column("nome")]
        
        public String Nome { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O valor de caracteres deve ser entre 10 á 50")]
        [Column("elemento")]

        public String Elemento { get; set; }

        [Column("Vida")]
        [Required (ErrorMessage = "O campo é obrigatório")]

        public decimal Vida { get; set; }
    }
}
