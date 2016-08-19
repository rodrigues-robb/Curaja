using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class EsqueletoResultadoSessao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [Required]
        [DisplayName("Resultado do Movimento")]
        public bool ResultadoMovimento { set; get; }

        [Required]
        [DisplayName("Série")]
        public int Serie { set; get; }

        [Required]
        [DisplayName("Repetição")]
        public int Repeticao { set; get; }

        public long SessaoId { set; get; }

        public virtual Sessao Sessao { set; get; }

        public virtual List<EstadoEsqueleto> EstadosEsqueleto { set; get; }
    }
}