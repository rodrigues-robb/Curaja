using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        [DisplayName("Usuário")]
        public string Nome { set; get; }

        [Required]
        [MaxLength(64)]
        public string Senha { set; get; }

        [Required]
        [DisplayName("Permissão")]
        public int Permissao { set; get; }

        [Required]
        public bool Status { set; get; }

        public virtual List<Pessoa> Pessoas { set; get; }
    }
}