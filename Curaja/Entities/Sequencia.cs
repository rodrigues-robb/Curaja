using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class Sequencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [Required]
        [MaxLength(75)]
        [DisplayName("Título")]
        public string Titulo { set; get; }

        public long FisioterapeutaId { set; get;}

        public virtual Fisioterapeuta Fisioterapeuta { set; get; }

        public virtual List<MovimentoSequencia> MovimentoSequencias { set; get; }

        public virtual List<Sessao> Sessoes { set; get; }
    }
}