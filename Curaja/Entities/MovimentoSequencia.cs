using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class MovimentoSequencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [Required]
        [DisplayName("Posição")]
        public int Posicao { set; get; }

        [Required]
        [DisplayName("Séries")]
        public int Series { set; get; }

        [Required]
        [DisplayName("Repetições")]
        public int Repeticoes { set; get; }

        [Required]
        public bool Status { set; get; }

        public long SequenciaId { set; get; }

        public virtual Sequencia Sequencia { set; get; }

        public long MovimentoId { set; get; }

        public virtual Movimento Movimento { set; get; }
    }
}